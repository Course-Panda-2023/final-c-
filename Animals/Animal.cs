using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    public Zone LivingZone { get; protected set; }
    public string Name { get; protected set; }
    public abstract void MakeSound();
    public bool WorkedOn { get; set; }

}
