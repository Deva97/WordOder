using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Model
{
    public class AddWorkCommand
    {
        public string Address { get; set; }
        public DateTime time { get; set; }
    }
}
