using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdeplasser.Portable.Models
{
    public class Stop
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int TotalTips { get; set; }
        public Coordinate Coords { get; set; }
    }
}
