using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.ZooUtils.CustomException
{
    internal class AnimalDoesNotRelatedToException : Exception
    {
        public AnimalDoesNotRelatedToException(string message) : base(message) { }
    }
}
