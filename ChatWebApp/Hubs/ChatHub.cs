using ChatWebApp.Data;
using ChatWebApp.Models;
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _db;

    public ChatHub(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task SendMessage(string user, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        var msg = new Message
        {
            User = string.IsNullOrEmpty(user) ? "Anon" : user,
            Text = message,
            CreatedAt = DateTime.UtcNow,
            Sentiment = SentimentLabel.Neutral, // тимчасово Neutral
            SentimentScore = null
        };

        _db.Messages.Add(msg);
        await _db.SaveChangesAsync();

        // відправляємо на клієнт
        await Clients.All.SendAsync("ReceiveMessage", msg.User, msg.Text, "Neutral");
    }
}
