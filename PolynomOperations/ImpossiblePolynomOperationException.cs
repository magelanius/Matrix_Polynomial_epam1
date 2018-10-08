using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomOperations
{
    class ImpossiblePolynomOperationException : Exception
    {
        public ImpossiblePolynomOperationException() : 
            base ("Operation over the polynomial is invalid. Check the polynomial type.")
        {

        }
    }
}
