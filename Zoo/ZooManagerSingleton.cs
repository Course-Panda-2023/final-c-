using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class ZooManagerSingleton
    {
        private static ZooManagerSingleton mInstance = null;

        private ZooManagerSingleton() { }

        public static ZooManagerSingleton Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new ZooManagerSingleton();
                }

                return mInstance;
            }
        }
    }
}
