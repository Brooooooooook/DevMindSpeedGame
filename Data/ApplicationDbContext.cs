using DevMindSpeedGame.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace DevMindSpeedGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<MathQuestion> MathQuestions { get; set; }
    }
}
