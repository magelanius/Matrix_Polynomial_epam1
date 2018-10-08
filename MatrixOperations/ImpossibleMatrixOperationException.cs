using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    class ImpossibleMatrixOperationException : Exception
    {
        public ImpossibleMatrixOperationException() : 
            base("Operation over the matrix is invalid. Check dimensions or matrix type.")
        {
        }
        

    }
}
