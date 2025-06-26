using DevMindSpeedGame.Models.Entites;

namespace DevMindSpeedGame.Repository.IRepository
{
    public interface IGameRepository
    {
        void CreateGameSession(GameSession session);
        GameSession? GetGameSessionById(int sessionId);
        public void Save();
    }
}
