using DevMindSpeedGame.Models.Entites;
using DevMindSpeedGame.Models.Models;
using DevMindSpeedGame.Repository.IRepository;
using DevMindSpeedGame.Services.IServices;

namespace DevMindSpeedGame.Services
{
    public class SubmitAnswerService : ISubmitAnswerService
    {
        private readonly IGameRepository _gameRepository;
        public SubmitAnswerService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public SubmitResponse SubmitAnswer(int sessionId, float answer)
        {
            var session = _gameRepository.GetGameSessionById(sessionId);
            DateTime timeNow = DateTime.Now;
            if (session.Question == null)
            {
                throw new Exception("Question not found");
            }
            double timeTaken = (timeNow - session.Question.Time).TotalSeconds;
            var correct = Math.Round(session.Question.Answer, 2);
            var playerAnswer = Math.Round(answer, 2);
            bool isCorrect = Math.Abs(correct - playerAnswer) < 0.01;

            if (isCorrect)
            {
                session.score += 1;
                
            }
            session.TotalQuestions += 1;


            string message = isCorrect ? $"Good job {session.PlayerName}, your answer is correct!" : $"Sorry {session.PlayerName}, your answer is incorrect.";
            MathQuestion newQuestion = GenerateMathQuestion.GenerateQuestion(session.Difficulty);
            session.Question = new MathQuestion
            {
                CurrentQuestion = newQuestion.CurrentQuestion,
                Answer = newQuestion.Answer,
                Time = DateTime.Now
            };
            _gameRepository.Save();

            var submit = new SubmitResponse
            {
                Result = message,
                TimeTaken = timeTaken,
                NextQuestion = new NextQuestionResponse
                {
                    SubmitUrl = $"/game/{sessionId}/submit",
                    Question = newQuestion.CurrentQuestion,
                },
                CurrentScore = $"{session.score} / {session.TotalQuestions}",

            };
            return submit;
        }
    }
}

