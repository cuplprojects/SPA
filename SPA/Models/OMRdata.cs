using System.Text.Json;

namespace SPA
{
    public class OMRdata
    {
        public int OmrDataId { get; set; }
        public JsonDocument OmrData { get; set; }
        public int Barcode { get; set; }
        public int ProjectId { get; set; }
        public string csvfile { get; set; }
    }
}
