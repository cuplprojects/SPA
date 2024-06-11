using System.Text.Json;

namespace SPA
{
    public class RegistrationData
    {
        public int RegistrationId { get; set; }
        public JsonDocument RegistrationsData { get; set; }
        public int ProjectId { get; set; }
    }
}
