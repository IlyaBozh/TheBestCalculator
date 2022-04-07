namespace Calculator
{
    public class Calculator
    {
        public string TranslatePostfixNotation(string expression)
        {
            string result = "";
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDelimiter(expression[i]))
                {
                    continue;
                }
                else if (Char.IsDigit(expression[i]))
                {
                    while (!IsDelimiter(expression[i]))
                    {
                        result += expression[i];
                        i++;
                    }
                }
                else
                {

                }
            }

            return result;
        }

        private bool IsDelimiter(char simbol)
        {
            bool isDelimiter = false;

            if (simbol == ' ')
            {
                isDelimiter = true;
            }

            return isDelimiter;
        }

        private bool IsOperator(char simbol)
        {
            bool isOperator = false;

            if ("*/+-()".IndexOf(simbol) != -1)
            {
                isOperator = true;
            }

            return isOperator;
        }

    }
}