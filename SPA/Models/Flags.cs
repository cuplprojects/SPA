using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPA
{
    public class Flags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlagId { get; set; }
        public string Remarks { get; set; }
        public JsonDocument FieldNameValue { get; set; }
        public int ProjectId { get; set; }
    }
}
