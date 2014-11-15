using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdeplasser.Portable.Models
{
    public class Tip
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public DateTimeOffset Created { get; set; }
        public long Likes { get; set; }
        public long Shares { get; set; }
        public string Author { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Coordinate Coords { get; set; }
        public string Comment { get; set; }

        public long StopId { get; set; }
        public string StopName { get; set; }
    }
}
