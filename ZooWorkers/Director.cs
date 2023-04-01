using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.ZooWorkers
{
    public class Director
    {
        private static Director instance = null;

        private Director()
        {
        }

        public static Director Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Director();
                }

                return instance;
            }
        }
    }
}