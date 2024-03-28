using RPN.BO.Services;
using RPN.Utils.Exceptions;
using System.Linq;

namespace RPN.Tests
{
    [TestClass]
    public class OperandServiceTest
    {
        #region GetOperands
        [TestMethod]
        public void should_return_all_operands()
        {
            var expected = new List<char> { '+', '-', '*', '/' };
            Assert.IsTrue(expected.SequenceEqual(OperandService.GetOperands()));
        }
        #endregion

        #region Compute
        [TestMethod]
        public void should_add_last_values_in_stack()
        {
            decimal expected = 5;
            int countExpected = 1;
            char operand = '+';

            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(3);

            OperandService.Compute(operand, stack);
            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(countExpected, stack.Count);
        }
        [TestMethod]
        public void should_substract_last_values_in_stack()
        {
            decimal expected = 5;
            int countExpected = 1;
            char operand = '-';

            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(7);

            OperandService.Compute(operand, stack);
            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(countExpected, stack.Count);
        }
        [TestMethod]
        public void should_multiply_last_values_in_stack()
        {
            decimal expected = 14;
            int countExpected = 1;
            char operand = '*';

            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(7);

            OperandService.Compute(operand, stack);
            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(countExpected, stack.Count);
        }
        [TestMethod]
        public void should_divide_last_values_in_stack()
        {
            decimal expected = 7;
            int countExpected = 1;
            char operand = '/';

            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(14);

            OperandService.Compute(operand, stack);
            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(countExpected, stack.Count);
        }
        #region Exceptions
        [TestMethod]
        [ExpectedException(typeof(NotEnoughValuesException))]
        public void should_not_compute_and_throw_NotEnoughValuesException()
        {
            char operand = '+';
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            OperandService.Compute(operand, stack);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperandException))]
        public void should_not_compute_and_throw_InvalidOperandException()
        {
            char operand = '$';
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(2);
            stack.Push(3);
            OperandService.Compute(operand, stack);
        }
        [TestMethod]
        [ExpectedException(typeof(ComputeException))]
        public void should_not_compute_and_throw_ComputeException()
        {
            char operand = '/';
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(0);
            stack.Push(3);
            OperandService.Compute(operand, stack);
        }
        #endregion
        #endregion
    }
}