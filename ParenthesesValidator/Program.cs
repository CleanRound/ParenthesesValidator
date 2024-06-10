namespace ParenthesesValidator
{
    public static class StringExtensions
    {
        public static bool IsValidParentheses(this string str)
        {
            var stack = new Stack<char>();
            var parenthesesPairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            foreach (var ch in str)
            {
                if (parenthesesPairs.ContainsValue(ch))
                {
                    stack.Push(ch);
                }
                else if (parenthesesPairs.ContainsKey(ch))
                {
                    if (stack.Count == 0 || stack.Pop() != parenthesesPairs[ch])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}

namespace ParenthesesValidator
{
    class Program
    {
        static void Main()
        {
            string[] testLines =
            {
                "{}[]",
                "(())",
                "[{}]",
                "[}",
                "[[{]}]",
                "({[]})",
                "({[)]}",
                "",
                "((()))",
                "((({{{[[[]]]}}})))"
            };

            foreach (var line in testLines)
            {
                Console.WriteLine($"\"{line}\" is a valid parentheses string: {line.IsValidParentheses()}");
            }
        }
    }
}

