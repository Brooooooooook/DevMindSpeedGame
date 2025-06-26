using DevMindSpeedGame.Models.Entites;

namespace DevMindSpeedGame.Services.IServices
{
    public interface IGameEndService
    {
        public GameSession EndGame(int sessionId);
    }
}
