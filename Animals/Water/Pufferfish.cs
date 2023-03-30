using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Pufferfish : Animal
{
    public Pufferfish(string name)
    {
        Name = name;
        LivingZone = Zone.Water;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Pufferfish {base.Name}: ee ee");
    }
}
