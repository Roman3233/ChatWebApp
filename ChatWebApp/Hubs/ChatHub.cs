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
            User = user ?? "Anon",
            Text = message,
            CreatedAt = DateTime.UtcNow
        };

        _db.Messages.Add(msg);
        await _db.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
