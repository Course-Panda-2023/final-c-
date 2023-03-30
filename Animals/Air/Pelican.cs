using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Pelican : Animal
{
    public Pelican(string name)
    {
        Name = name;
        LivingZone = Zone.Air;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Pelican {base.Name}: Hoo Hoo");
    }
}
