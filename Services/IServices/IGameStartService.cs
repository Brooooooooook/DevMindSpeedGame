using DevMindSpeedGame.Models.Models;

namespace DevMindSpeedGame.Services.IServices
{
    public interface IGameStartService
    {
        public GameResponse StartGame(string name, int difficulty);
        
        
    }
}
