using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SPA
{
    public class Keys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyId { get; set; }
        public JsonDocument KeyData { get; set; }
        public int ProjectId { get; set; }
        public string KeyFile { get; set; }
    }
}
