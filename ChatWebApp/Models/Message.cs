using System;

namespace ChatWebApp.Models
{
    public enum SentimentLabel { Unknown = 0, Positive = 1, Neutral = 2, Negative = 3 }

    public class Message
    {
        public int Id { get; set; }           
        public string User { get; set; } = "";   
        public string Text { get; set; } = "";   
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public double? SentimentScore { get; set; }
        public SentimentLabel Sentiment { get; set; } = SentimentLabel.Unknown;
    }
}
