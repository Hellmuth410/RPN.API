using RPN.BO.Services;
using RPN.Utils.Exceptions;
using System.Linq;

namespace RPN.Tests
{
    [TestClass]
    public class StackServiceTest
    {
        #region AddStack
        [TestMethod]
        public void should_create_new_stack()
        {
            int expected = 1;

            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>();
            StackService.AddStack(allStacks);

            Assert.AreEqual(allStacks.Count, expected);
        }
        #endregion

        #region RemoveStack
        [TestMethod]
        public void should_remove_stack()
        {
            int expected = 0;

            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.RemoveStack(0, allStacks);

            Assert.AreEqual(allStacks.Count, expected);
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void should_not_remove_stack_and_throw_KeyNotFoundException()
        {
            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.RemoveStack(1, allStacks);
        }
        #endregion

        #region GetStack
        [TestMethod]
        public void should_get_stack()
        {
            decimal expected = 123;

            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>();
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(expected);
            allStacks.Add(0, stack);

            Stack<decimal> result = StackService.GetStack(0, allStacks);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Pop(), expected);
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void should_not_get_stack_and_throw_KeyNotFoundException()
        {
            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.GetStack(1, allStacks);
        }
        #endregion

        #region PushInStack
        [TestMethod]
        public void should_push_value_in_stack()
        {
            decimal expected = 123;
            int countExpected = 1;

            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.PushInStack(0, expected, allStacks);

            Stack<decimal> result = allStacks[0];
            Assert.AreEqual(result.Count, countExpected);
            Assert.AreEqual(result.Pop(), expected);
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void should_not_push_value_in_stack_and_throw_KeyNotFoundException()
        {
            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.PushInStack(1, 123, allStacks);
        }
        #endregion

        #region PopFromStack
        [TestMethod]
        public void should_pop_from_stack()
        {
            decimal expected = 123;
            int countExpected = 0;

            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>();
            Stack<decimal> stack = new Stack<decimal>();
            stack.Push(expected);
            allStacks.Add(0, stack);

            Stack<decimal> result = allStacks[0];
            Assert.AreEqual(result.Pop(), expected);
            Assert.AreEqual(result.Count, countExpected);
        }
        [TestMethod]
        [ExpectedException(typeof(NotEnoughValuesException))]
        public void should_not_pop_from_stack_and_throw_NotEnoughValuesException()
        {
            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.PopFromStack(0, allStacks);
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void should_not_pop_from_stack_and_throw_KeyNotFoundException()
        {
            IDictionary<int, Stack<decimal>> allStacks = new Dictionary<int, Stack<decimal>>() { { 0, new Stack<decimal>() } };
            StackService.PopFromStack(1, allStacks);
        }
        #endregion
    }
}