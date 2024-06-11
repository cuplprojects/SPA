using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
namespace SPA.Models
{
    public class AmbiguousQues
    {
        public int AmbiguousId { get; set; }
        public int ProjectId { get; set; }
        public int MarkingId { get; set; }
        public JsonDocument SetQuesAns { get; set; }
    }
}
