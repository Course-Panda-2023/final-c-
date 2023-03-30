using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Shark : Animal
{
    public Shark(string name)
    {
        Name = name;
        LivingZone = Zone.Water;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Shark {base.Name}: ee ee");
    }
}
