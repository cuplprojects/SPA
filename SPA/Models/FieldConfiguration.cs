using System.Text.Json;
using System.Text.Json.Nodes;

namespace SPA
{
    public class FieldConfiguration
    {
        public int FieldConfigurationId {  get; set; }
        public JsonDocument attribute { get; set; }
        public int ProjectId { get; set; }
        public int FieldId { get; set; }
    }
}
