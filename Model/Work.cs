using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Model
{
    public class Work
    {
        [Key]
        public string WorkOrderId { get; set; } = System.Guid.NewGuid().ToString();
        public string Address { get; set; }
        public DateTime InterventionTime { get; set; }

        public virtual ICollection<WorkBoard> WorkBoardsWorkDetails { get; set; }
    }

}
