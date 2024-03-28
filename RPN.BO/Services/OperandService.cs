using RPN.Utils;
using RPN.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPN.BO.Services
{
    public class OperandService
    {
        /// <summary>
        /// Get all operands
        /// </summary>
        public static IEnumerable<char> GetOperands() { return Constants.OPERANDS; }

        /// <summary>
        /// Compute the last 2 values depending the operand
        /// </summary>
        /// <exception cref="ComputeException">Error during the compute</exception>
        public static void Compute(char operand, Stack<decimal> stack)
        {
            ComputeControls(operand, stack);
            // Get last 2 elements
            decimal first = stack.Pop();
            decimal second = stack.Pop();
            try
            {
                // Compute depending the operand
                decimal? result = Compute(operand, first, second);
                // push the result in stack
                stack.Push(result.Value);
            }
            catch (Exception ex)
            {
                stack.Push(second);
                stack.Push(first);
                throw ex;
            }
        }

        /// <summary>
        /// Controls before compute
        /// </summary>
        /// <exception cref="NotEnoughValuesException">2 values are required to compute</exception>
        /// <exception cref="InvalidOperandException">the operand is not valid</exception>
        private static void ComputeControls(char operand, Stack<decimal> stack)
        {
            // Controls
            if (stack.Count < 2)
            {
                throw new NotEnoughValuesException();
            }
            if (!GetOperands().Contains(operand))
            {
                throw new InvalidOperandException();
            }
        }

        /// <summary>
        /// Compute first and second depending the operand
        /// </summary>
        private static decimal? Compute(char operand, decimal first, decimal second)
        {
            decimal? result = null;
            switch (operand)
            {
                case Constants.ADD:
                    result = first + second;
                    break;
                case Constants.SUB:
                    result = first - second;
                    break;
                case Constants.MUL:
                    result = first * second;
                    break;
                case Constants.DIV:
                    if (second == 0) { throw new ComputeException("Impossible to divide by 0."); }
                    result = first / second;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
