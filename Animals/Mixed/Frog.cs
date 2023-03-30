using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Frog : Animal
{
    public Frog(string name)
    {
        Name = name;
        LivingZone = Zone.Mixed;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Frog {base.Name}: ra");
    }
}
