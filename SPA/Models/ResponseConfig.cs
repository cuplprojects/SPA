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
        public string Section { get; set; }
        public string Response { get; set; }
        public int ProjectId { get; set; }
    }
}
