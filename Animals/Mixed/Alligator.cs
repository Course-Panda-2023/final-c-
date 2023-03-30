using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Hippo : Animal
{
    public Hippo(string name)
    {
        Name = name;
        LivingZone = Zone.Mixed;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Hippo {base.Name}: Sound");
    }
}
