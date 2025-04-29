using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Interfaces
{
    public interface IOperation
    {
        List<double> Values { get; set; }

        List<IOperation> SubOperations { get; set; }

        double Execute(); // Method to perform operation
    }
}
