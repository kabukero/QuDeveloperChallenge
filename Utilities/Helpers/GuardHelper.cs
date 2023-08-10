using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public class GuardHelper
    {
        public static void ThrowIfNull<TArgument>(TArgument argumentValue, string message, string parameterName)
        {
            if (argumentValue == null)
                throw new ArgumentException(message, parameterName);
        }
    }
}
