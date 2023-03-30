using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Feeder : AnimalWorker
{
    public Feeder()
    {
        TotalWorkTime = 10;
        base.PriceChange = 100;
    }
    protected override string WorkingVerb { get { return "feeding"; } }
}
