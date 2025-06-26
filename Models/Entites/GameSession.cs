using DevMindSpeedGame.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevMindSpeedGame.Models.Entites
{
    public class GameSession
    {
        [Key]
        public int SessionId { get; set; }
        public string PlayerName { get; set; }
        public int Difficulty { get; set; }
        public DateTime StartTime { get; set; }
        public int score { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public MathQuestion Question { get; set; }
        public int TotalQuestions { get; set; }
        public List<QuestionHistory> History { get; set; } = new List<QuestionHistory>();

        [ForeignKey("_BestScore")]
        public int BestScoreId { get; set; }
        public BestScore _BestScore { get; set; }
    }
}
