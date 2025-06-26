using System.ComponentModel.DataAnnotations.Schema;

namespace DevMindSpeedGame.Models.Entites
{
    public class QuestionHistory
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public float CorrectAnswer { get; set; }
        public float PlayerAnswer { get; set; }
        public double TimeTaken { get; set; }

        [ForeignKey("GameSession")]
        public int GameSessionId { get; set; }
        public GameSession GameSession { get; set; }
    }
}
