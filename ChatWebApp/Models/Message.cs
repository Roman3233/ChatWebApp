namespace ChatWebApp.Models
{
    // Sentiment categories used for UI coloring.
    public enum SentimentLabel
    {
        Negative = 0,
        Neutral = 1,
        Positive = 2
    }

    // Represents a message sent in chat and stored in the database.
    public class Message
    {
        public int Id { get; set; }
        public string User { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public double? SentimentScore { get; set; }
        public SentimentLabel Sentiment { get; set; } = SentimentLabel.Neutral;
    }
}
