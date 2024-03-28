using RPN.Utils.Exceptions;

namespace RPN.BO.Services
{
    public static class StackService
    {
        /// <summary>
        /// Create a new stack
        /// </summary>
        public static void AddStack(IDictionary<int, Stack<decimal>> allStacks)
        {
            int newKey = allStacks.Any() ? allStacks.Keys.Max() + 1 : 0;
            allStacks.Add(newKey, new Stack<decimal>());
        }

        /// <summary>
        /// Delete an existing stack
        /// </summary>
        /// <exception cref="KeyNotFoundException">stackId does not exist in allStacks</exception>
        public static void RemoveStack(int stackId, IDictionary<int, Stack<decimal>> allStacks)
        {
            if (!allStacks.ContainsKey(stackId)) { throw new KeyNotFoundException(); }
            allStacks.Remove(stackId);
        }

        /// <summary>
        /// Get a stack from its id
        /// </summary>
        /// <exception cref="KeyNotFoundException">stackId does not exist in allStacks</exception>
        public static Stack<decimal> GetStack(int stackId, IDictionary<int, Stack<decimal>> allStacks)
        {
            if (!allStacks.TryGetValue(stackId, out Stack<decimal> stack)) { throw new KeyNotFoundException(); }
            return stack;
        }

        /// <summary>
        /// Push a value in a stack
        /// </summary>
        /// <exception cref="KeyNotFoundException">stackId does not exist in allStacks</exception>
        public static Stack<decimal> PushInStack(int stackId, decimal value, IDictionary<int, Stack<decimal>> allStacks)
        {
            if (!allStacks.TryGetValue(stackId, out Stack<decimal> stack)) { throw new KeyNotFoundException(); }
            stack.Push(value);
            return stack;
        }

        /// <summary>
        /// Pop the last value from a stack
        /// </summary>
        /// <exception cref="NotEnoughValuesException">stackId does not exist in allStacks</exception>
        public static Stack<decimal> PopFromStack(int stackId, IDictionary<int, Stack<decimal>> allStacks)
        {
            if (!allStacks.TryGetValue(stackId, out Stack<decimal> stack)) { throw new KeyNotFoundException(); }
            if (stack.Count == 0) { throw new NotEnoughValuesException(); }
            stack.Pop();
            return stack;
        }
    }
}
