using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Dolphin : Animal
{
    public Dolphin(string name)
    {
        Name = name;
        LivingZone = Zone.Water;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Dolphin {base.Name}: ee ee");
    }
}
