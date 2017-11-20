using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        [Required]
        [DisplayName("Status")]
        public string RequestStatus { get; set; }
        public ICollection<ChangeRequest> ChangeRequests { get; set; }
    }
}
