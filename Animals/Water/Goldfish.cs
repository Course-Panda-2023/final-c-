using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Goldfish : Animal
{
    public Goldfish(string name)
    {
        Name = name;
        LivingZone = Zone.Water;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Goldfish {base.Name}: ee ee");
    }
}
