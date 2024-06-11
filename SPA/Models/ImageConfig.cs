using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SPA
{
    public class ImageConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public JsonDocument FieldAnnotation { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }
    }
}
