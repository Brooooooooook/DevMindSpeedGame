using DevMindSpeedGame.Models.Entites;
using DevMindSpeedGame.Models.Models;
using DevMindSpeedGame.Repository.IRepository;
using DevMindSpeedGame.Services.IServices;
using System.Data;

namespace DevMindSpeedGame.Services
{
    public class GameStartService : IGameStartService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMathRepository _mathRepository;
        public GameStartService(IGameRepository gameRepository, IMathRepository mathRepository)
        {
            _gameRepository = gameRepository;
            _mathRepository = mathRepository;
        }
        public GameResponse StartGame(string name, int difficulty)
        {
            int sessionId = Guid.NewGuid().GetHashCode();

            var message = $"Hello {name}, find your submit API URL below";
            var submitUrl = $"/game/{sessionId}/submit";
            var math = GenerateMathQuestion.GenerateQuestion(difficulty);
            var mathQuestion = new MathQuestion
            {
                CurrentQuestion = math.CurrentQuestion,
                Answer = math.Answer,
                Time = DateTime.Now
            };
            _mathRepository.CreateMathQuestion(mathQuestion);

            var question = math.CurrentQuestion;
            var timeStarted = DateTime.Now;
            var respone = new GameResponse
            {
                Message = message,
                SubmitUrl = submitUrl,
                Question = question,
                TimeStarted = timeStarted,
            };


            var session = new GameSession
            {
                SessionId = sessionId,
                PlayerName = name,
                Difficulty = difficulty,
                StartTime = DateTime.Now,
                score = 0,
                QuestionId = mathQuestion.Id,
            };
            _gameRepository.CreateGameSession(session);
            return respone;
        }

    }
}
