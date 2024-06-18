using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SPA
{
    public class FieldConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldConfigurationId {  get; set; }
        public string attribute { get; set; }
        public int ProjectId { get; set; }
        public int FieldId { get; set; }
    }
}
