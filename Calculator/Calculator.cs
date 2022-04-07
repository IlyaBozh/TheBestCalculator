namespace Calculator
{
    public static class Calculator
    {
        public static string TranslatePostfixNotation(string expression)
        {
            string postfixExpresion = "";
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDelimiter(expression[i]))
                {
                    continue;
                }
                else if (Char.IsDigit(expression[i]))
                {
                    while (!IsDelimiter(expression[i]) && expression[i] != ')')
                    {
                        postfixExpresion += expression[i];
                        i++;
                    }

                    postfixExpresion += " ";  
                }
                
                if (!IsDelimiter(expression[i]) && !Char.IsDigit(expression[i]))
                {
                    if (expression[i] == '(')
                    {
                        stack.Push(expression[i]);
                    }
                    else if (expression[i] == ')')
                    {
                        char tmp = stack.Pop();

                        while (tmp != '(')
                        {
                            postfixExpresion += tmp + " ";
                            tmp = stack.Pop();
                        }
                    }
                    else
                    {
                        if (stack.Count > 0 && GetPriority(expression[i]) >= GetPriority(stack.Peek()))
                        {
                            while (stack.Count != 0 && stack.Peek() != '(' && GetPriority(expression[i]) >= GetPriority(stack.Peek()))
                            {
                                postfixExpresion += stack.Pop() + " ";
                            }

                            stack.Push(expression[i]);
                           
                        }
                        else
                        {
                            stack.Push(expression[i]);
                        }
                    }

                }
            }

            while(stack.Count > 0)
            {
                postfixExpresion += stack.Pop() + " ";
            }

            return postfixExpresion;
        }

        private static bool IsDelimiter(char simbol)
        {
            bool isDelimiter = false;

            if (simbol == ' ')
            {
                isDelimiter = true;
            }

            return isDelimiter;
        }

        private static int GetPriority(char simbol)
        {
            int priority = 0;

            switch (simbol)
            {
                case '*':
                    priority = 3;
                    break;
                case '/':
                    priority = 3;
                    break;
                case '+':
                    priority = 2;
                    break;
                case '-':
                    priority = 2;
                    break;
                case '(':
                    priority = 1;
                    break;

            }

            return priority;
        }

    }
}