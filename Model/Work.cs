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
        public Address Address { get; set; }
        public DateTime InterventionTime { get; set; }

        public virtual ICollection<WorkBoard> WorkBoardsWorkDetails { get; set; }
    }

    public class Address
    {
        [Required]
        public string? LineOne { get; set; }
        public string LineTwo { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string District { get; set; }
        [Key]
        public string Pincode { get; set; }
        public string? LandMark { get; set; }
    }
}
