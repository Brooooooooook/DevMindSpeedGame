using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevMindSpeedGame.Models.Entites
{
    public class MathQuestion
    {
        [Key]   
        public int Id { get; set; }
        public string CurrentQuestion { get; set; }
        public float Answer { get; set; }
        public DateTime Time { get; set; }

        
    }
}
