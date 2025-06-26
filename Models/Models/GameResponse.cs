using DevMindSpeedGame.Models.Entites;

namespace DevMindSpeedGame.Models.Models
{
    public class GameResponse
    {
        public string Message { get; set; }
        public string SubmitUrl { get; set; }
        public string Question { get; set; }
        public DateTime TimeStarted { get; set; }
    }
}
