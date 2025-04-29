using Calculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public abstract class BaseOperation : IOperation
    {
        public List<double> Values { get; set; } = new List<double>();
        public List<IOperation> SubOperations { get; set; } = new List<IOperation>();

        public double Execute()
        {
           if (Values == null || Values.Count == 0)
                return 0;

            var allValues = new List<double>(Values);

            foreach (var subOperation in SubOperations)
            {
                allValues.Add(subOperation.Execute());
            }

            return PerformOperation(allValues);
        }

        protected abstract double PerformOperation(List<double> values);
    }
}
