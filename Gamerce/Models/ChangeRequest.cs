using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class ChangeRequest
    {
        public int ChangeRequestID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string BriefDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date request made")]
        public DateTime DateOfRequest { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Request required by")]
        public DateTime RequiredBy { get; set; }
        [Required]
        public int PriorityID { get; set; }
        [Required]
        public int StatusID { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string OwnerID { get; set; }

    }
}
