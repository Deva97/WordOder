using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Model
{
    public class AssignTechnician
    {
        public string TechnicianId { get; set; }
        public string WorkId { get; set; }
        public bool IsWorkDone { get; set; }
        public bool IsWorkOrderActive { get; set; }
    }
}
