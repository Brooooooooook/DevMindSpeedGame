using DevMindSpeedGame.Data;
using DevMindSpeedGame.Models.Entites;
using DevMindSpeedGame.Repository.IRepository;

namespace DevMindSpeedGame.Repository
{
    public class MathRepository : IMathRepository
    {
        private readonly ApplicationDbContext _db;
        public MathRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void CreateMathQuestion(MathQuestion question)
        {
            _db.Add(question);
            _db.SaveChanges();
        }
    }
}
