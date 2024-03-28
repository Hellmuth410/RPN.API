namespace RPN.Utils
{
    public static class Constants
    {
        public const char ADD = '+';
        public const char SUB = '-';
        public const char MUL = '*';
        public const char DIV = '/';
        public static IEnumerable<char> OPERANDS = new List<char> { ADD, SUB, MUL, DIV };
    }
}
