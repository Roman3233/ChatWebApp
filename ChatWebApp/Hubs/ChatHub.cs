using ChatWebApp.Data;
using ChatWebApp.Models;
using ChatWebApp.Services;
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _db;
    private readonly TextAnalysisService _textAnalysis;

    public ChatHub(ApplicationDbContext db, TextAnalysisService textAnalysis)
    {
        _db = db;
        _textAnalysis = textAnalysis;
    }

    public async Task SendMessage(string user, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        user = string.IsNullOrEmpty(user) ? "Anon" : user;

        var (sentimentValue, score) = _textAnalysis.Analyze(message);

        SentimentLabel label = (SentimentLabel)sentimentValue;

        var msg = new Message
        {
            User = user,
            Text = message,
            CreatedAt = DateTime.UtcNow,
            Sentiment = label,
            SentimentScore = score
        };

        _db.Messages.Add(msg);
        await _db.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", msg.User, msg.Text, (int)msg.Sentiment);
    }
}
