using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holdeplasser.Portable.Models;

namespace Holdeplasser.Portable.Services.Results
{
    public class TipsResult
    {
        public IEnumerable<Tip> Tips { get; set; }
        public long TotalTips { get; set; }
    }
}
