using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Vulture : Animal
{
    public Vulture(string name)
    {
        Name = name;
        LivingZone = Zone.Air;
    }
    public override void MakeSound()
    {
        Console.WriteLine($"Vulture {base.Name}: Sound");
    }
}
