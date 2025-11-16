using Azure;
using Azure.AI.TextAnalytics;

namespace ChatWebApp.Services
{
    public class TextAnalysisService
    {
        private readonly TextAnalyticsClient _client;

        // Initializes the service using configuration values.
        public TextAnalysisService(IConfiguration config)
        {
            var endpoint = config["TextAnalytics:Endpoint"];
            var key = config["TextAnalytics:ApiKey"];

            _client = new TextAnalyticsClient(
                new Uri(endpoint),
                new AzureKeyCredential(key)
            );
        }

        // Analyzes given text and returns sentiment label and confidence score.
        public (int sentiment, double score) Analyze(string text)
        {
            var result = _client.AnalyzeSentiment(text);
            double confidence = 0.0;
            int value = 1; // neutral by default

            switch (result.Value.Sentiment)
            {
                case TextSentiment.Positive:
                    value = 2;
                    confidence = result.Value.ConfidenceScores.Positive;
                    break;

                case TextSentiment.Negative:
                    value = 0;
                    confidence = result.Value.ConfidenceScores.Negative;
                    break;

                default:
                    value = 1;
                    confidence = result.Value.ConfidenceScores.Neutral;
                    break;
            }

            return (value, confidence);
        }
    }
}
