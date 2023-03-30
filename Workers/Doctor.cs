using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Doctor : AnimalWorker
{
    public Doctor()
    {
        base.TotalWorkTime = 5;
        base.PriceChange = 20;
    }
    protected override string WorkingVerb { get { return "doctoring"; } }
}