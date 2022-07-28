using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Model
{
    public class Technician
    {
        [Key]
        public string TechnicianId { get; set; } = System.Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<WorkBoard> WorkBoardsTechnicainDetails { get; set; }
    }
}
