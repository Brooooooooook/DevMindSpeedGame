using DevMindSpeedGame.Models.Entites;
using DevMindSpeedGame.Models.Models;
using DevMindSpeedGame.Repository.IRepository;
using DevMindSpeedGame.Services.IServices;

namespace DevMindSpeedGame.Services
{
    public class GameEndService : IGameEndService
    {
        private readonly IGameRepository _gameRepository;
        public GameEndService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameSession EndGame(int sessionId)
        {
            var session = _gameRepository.GetGameSessionById(sessionId);
            int difficulty = session.Difficulty;
            int total = session.TotalQuestions;
            int Score = session.score;
            double totaltime = session.History.Sum(h => h.TimeTaken);
            var best = session.History.Where(h => Math.Abs(h.PlayerAnswer - h.CorrectAnswer) < 0.01f)
                                           .OrderByDescending(h => h.TimeTaken)
                                           .FirstOrDefault();
            var bestScore = best == null ? null : new BestScore
            {
                Question = best.Question,
                Answer = best.CorrectAnswer,
                TimeTaken = best.TimeTaken,
            };
            return new GameSession
            {
                PlayerName = session.PlayerName,
                Difficulty = difficulty,
                StartTime = session.StartTime,
                score = Score,
                TotalQuestions = total,
                History = session.History,
                _BestScore = bestScore
            };
        }
    }
}
