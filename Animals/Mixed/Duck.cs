using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Duck : Animal
{
    public Duck(string name)
    {
        Name = name;
        LivingZone = Zone.Mixed;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Duck {base.Name}: ra");
    }
}
