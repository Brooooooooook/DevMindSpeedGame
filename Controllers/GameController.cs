using DevMindSpeedGame.Models.Models;
using DevMindSpeedGame.Repository.IRepository;
using DevMindSpeedGame.Services;
using DevMindSpeedGame.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevMindSpeedGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameStartService _gameStart;
        private readonly ISubmitAnswerService _submit;
        private readonly IGameEndService _gameEnd;

        public GameController(IGameStartService game, ISubmitAnswerService submit, IGameEndService gameEnd)
        {
            _gameStart = game;
            _submit = submit;
            _gameEnd = gameEnd;
        }

        [HttpPost("Start")]
        public IActionResult Start([FromBody] GameRequest request)
        {
            return Ok(_gameStart.StartGame(request.PlayerName, request.Difficulty));
        }

        [HttpPost("{sessionId}/Submit")]
        public IActionResult Submit(int sessionId, [FromBody] SubmitRequest request)
        {
            return Ok(_submit.SubmitAnswer(sessionId, request.Answer));
        }

        [HttpGet("{sessionId}/End")]
        public IActionResult End(int sessionId)
        {
            return Ok(_gameEnd.EndGame(sessionId));
        }
    }
}
