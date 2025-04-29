using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Core.Interfaces;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Models;

namespace Calculator.Core.Operations
{
    public class MultiplyOperation : BaseOperation
    {
        protected override double PerformOperation(List<double> values)
        {
            if (values == null || values.Count == 0)
                return 0;

            double result = 1;
            foreach (var value in values)
            {
                result *= value;
            }
            return result;
        }
    }
}
