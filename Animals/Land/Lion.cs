using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Lion : Animal
{
    public Lion(string name)
    {
        Name = name;
        LivingZone = Zone.Land;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Lion {base.Name}: Roar");
    }
}
