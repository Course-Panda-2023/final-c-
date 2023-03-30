using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Whale : Animal
{
    public Whale(string name)
    {
        Name = name;
        LivingZone = Zone.Water;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Whale {base.Name}: ee ee");
    }
}
