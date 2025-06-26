using DevMindSpeedGame.Models.Models;

namespace DevMindSpeedGame.Services.IServices
{
    public interface ISubmitAnswerService
    {
        public SubmitResponse SubmitAnswer(int sessionId,float answer);
    }
}
