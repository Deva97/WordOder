using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Model
{
    public class WorkBoard
    {
        [Key]
        public string JobId { get; set; } = System.Guid.NewGuid().ToString();
        public string TechnicianId { get; set; }
        public string WorkId { get; set; }
        public bool IsWorkDone { get; set; }
        public bool IsWorkOrderActive { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public virtual Work Work { get; set; }  
        public virtual Technician Technician { get; set; }



    }
}
