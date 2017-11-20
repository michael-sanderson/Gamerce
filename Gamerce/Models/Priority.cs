using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Priority
    {
        public int PriorityID { get; set; }
        [Required]
        [DisplayName("Priority level")]
        public string PriorityLevel { get; set; }
        public ICollection<ChangeRequest> ChangeRequests { get; set; }
}
}
