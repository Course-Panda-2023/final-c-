﻿using CSharp_Zoo.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.ZooWorkers
{
    public class Doctor : ZooWorker
    {
        private const int _workingTime = 5;

        public override void TreatAnimal(Animal animal)
        {
            if (animal.WorkedBy == null)
            {
                animal.WorkedBy = this;
                //Treating...
                Thread.Sleep(300);
                Console.WriteLine("Treated");
                animal.WorkedBy = null;
            }
            else
            {
                Console.WriteLine("Animal is already being worked on.");
            }
        }
        public override int WorkingTime() => _workingTime;
        public override ZooPositions GetPosition() => ZooPositions.Doctor;
    }
}

