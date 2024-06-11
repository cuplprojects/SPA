using System.Text.Json;

namespace SPA
{
    public class Absentee
    {
        public int AbsenteeId { get; set; }
        public int ProjectId { get; set; }
        public JsonDocument Absenteedata { get; set; }
    }
}
