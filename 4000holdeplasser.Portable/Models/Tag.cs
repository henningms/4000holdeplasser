using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdeplasser.Portable.Models
{
    public class Tag
    {
        public long Id { get; set; }
    }

    public enum Tags
    {
        Sports = 1,
        Culture = 2,
        EatAndDrink = 3,
        WorthToLookAt = 4,
        Nature = 5,
        ThingsToBuy = 6,
        FunAndGames = 7,
        SmallPleasures = 8
    }
}
