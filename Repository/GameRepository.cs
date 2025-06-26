using DevMindSpeedGame.Data;
using DevMindSpeedGame.Models.Entites;
using DevMindSpeedGame.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DevMindSpeedGame.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _db;
        public GameRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateGameSession(GameSession session)
        {
            _db.Add(session);
            _db.SaveChanges();
        }

        public GameSession? GetGameSessionById(int sessionId)
        {
            var session = _db.GameSessions.Include(s => s.Question).Include(h => h.History).FirstOrDefault(g => g.SessionId == sessionId);
            return session;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
