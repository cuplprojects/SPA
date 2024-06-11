using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SPA
{
    public class ResponseConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
        public JsonDocument Section { get; set; }
        public JsonDocument Response { get; set; }
        public int ProjectId { get; set; }
    }
}
