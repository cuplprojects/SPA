using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
namespace SPA
{
    public class CorrectedOMRData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CorrectedId { get; set; }
        public JsonDocument CorrectedOmrData { get; set; }
        public int ProjectId { get; set; }
        public string OmrData { get; set; }
    }
}
