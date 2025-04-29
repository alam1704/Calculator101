using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Core.Interfaces;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core.Models;

namespace Calculator.Core.Operations
{
    public class SubtractOperation : BaseOperation
    {
        protected override double PerformOperation(List<double> values)
        {
            if (values == null || values.Count == 0)
                return 0;

            double result = values[0];

            // Iterate through the values starting from the second one
            for (int i = 1; i < values.Count; i++)
            {
                result -= values[i];
            }

            return result;
        }
    }
}
