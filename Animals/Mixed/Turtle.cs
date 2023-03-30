using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Turtle : Animal
{
    public Turtle(string name)
    {
        Name = name;
        LivingZone = Zone.Mixed;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Turtle {base.Name}: Sound");
    }
}
