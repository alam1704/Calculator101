using Calculator.Core.Interfaces;
using Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public class AddOperation : BaseOperation
    {
        protected override double PerformOperation(List<double> values)
        {
            return values.Sum();
        }
    }
}
