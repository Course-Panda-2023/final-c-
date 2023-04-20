using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class AreaType
    {
        public Area Area;

        public AreaType(Area area)
        {
            this.Area = area;
        }
    }
    public enum Area
    {
        Land,
        Air,
        Sea,
        Mix
    }
}
