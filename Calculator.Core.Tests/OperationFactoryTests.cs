using Calculator.Core.Factories;
using Calculator.Core.Models;
using Calculator.Core.Operations;
using Calculator.Service.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Calculator.Core.Tests
{
    [TestClass]
    public class OperationFactoryTests
    {
        [TestMethod]
        public void Calculate_Test_Add()
        {
            // Arrange
            var request = new CalculationResponse();
            var operation = new MathsOperation
            {
                ID = OperationType.Plus,
                Values = new List<string> { "1", "2", "3" }
            };
            request.Operation = operation;

            // Act
            var response = OperationFactory.Create(request.Operation);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(6, response.Execute());
        }
        [TestMethod]
        public void Calculate_Test_Subtract()
        {
            var request = new CalculationResponse();
            var operation = new MathsOperation
            {
                ID = OperationType.Subtract,
                Values = new List<string> { "5", "2", "1" }
            };
            request.Operation = operation;

            var response = OperationFactory.Create(request.Operation);

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Execute());
            //Assert.AreEqual(OperationType.Subtract.ToString(), response.Content.Operation);
        }
        [TestMethod]
        public void Calculate_Test_Multiply()
        {
            var request = new CalculationResponse();
            var operation = new MathsOperation
            {
                ID = OperationType.Multiplication,
                Values = new List<string> { "2", "3", "4" }
            };
            request.Operation = operation;

            var response = OperationFactory.Create(request.Operation);
            Assert.IsNotNull(response);
            Assert.AreEqual(24, response.Execute());
            //Assert.AreEqual(OperationType.Multiply.ToString(), response.Content.Operation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Calculate_Test_InvalidOperation()
        {
            var request = new CalculationResponse();
            var operation = new MathsOperation
            {
                ID = OperationType.Plus,
                Values = new List<string> { "1", "2", "3" }
            };
            request.Operation = operation;

            var response = OperationFactory.Create(request.Operation);
            Assert.IsNotNull(response);
            Assert.AreEqual(10, response.Execute());
        }
    }
}
