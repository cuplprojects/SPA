using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SPA
{
    public class Absentee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbsenteeId { get; set; }
        public int ProjectId { get; set; }
        public string Absenteedata { get; set; }
    }
}
