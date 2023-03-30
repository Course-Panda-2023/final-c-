using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Utils.CustomException
{
    internal class CannotMakeIllegalToursException : Exception
    {
        public CannotMakeIllegalToursException(string message) : base(message) { }
    }
}
