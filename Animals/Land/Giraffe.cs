using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Giraffe : Animal
{
    public Giraffe(string name)
    {
        Name = name;
        LivingZone = Zone.Land;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Giraffe {base.Name}: Roar");
    }
}
