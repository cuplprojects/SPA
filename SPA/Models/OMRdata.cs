using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SPA
{
    public class OMRdata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OmrDataId { get; set; }
        public string OmrData { get; set; }
        public int Barcode { get; set; }
        public int ProjectId { get; set; }
        public string csvfile { get; set; }
    }
}
