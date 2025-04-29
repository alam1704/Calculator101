using Calculator.Core.Interfaces;
using Calculator.Core.Models;
using Calculator.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Factories
{
    public static class OperationFactory
    {
        public static IOperation Create(MathsOperation data)
        {
            IOperation operation = null;
            switch (data.ID)
            {
                case OperationType.Plus:
                    operation = new AddOperation();
                    break;
                case OperationType.Subtract:
                    operation = new SubtractOperation();
                    break;
                case OperationType.Multiplication:
                    operation = new MultiplyOperation();
                    break;
                case OperationType.Divide:
                    operation = new DivideOperation();
                    break;
                default:
                    throw new NotImplementedException($"Operation {data} is not implemented.");
            }
            operation.Values = data.Values.Select(double.Parse).ToList();

            if (data.SubOperation != null)
            {
                //operation.Values.Add(Create(data.SubOperation));
                operation.SubOperations.Add(Create(data.SubOperation));
            }

            return operation;
        }
    }
}
