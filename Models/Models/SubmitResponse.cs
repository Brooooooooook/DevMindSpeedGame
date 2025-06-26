using DevMindSpeedGame.Models.Entites;

namespace DevMindSpeedGame.Models.Models
{
    public class SubmitResponse
    {
        public string Result { get; set; }
        public double TimeTaken { get; set; }
        public NextQuestionResponse NextQuestion { get; set; }
        public string CurrentScore { get; set; }
    }
}
