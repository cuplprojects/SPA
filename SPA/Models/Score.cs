using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
namespace SPA.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int ScoreId { get; set; }
        public string ScoreData { get; set; }
        public int CorrectedId { get; set; }
        public int ProjectId { get; set; }
    }
}
