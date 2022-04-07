namespace Calculator
{
    public class CalculatorController
    {
        public string TranslatePostfixNotation(string expression)
        {
            string postfixExpresion = "";
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {

                if (Char.IsDigit(expression[i]))
                {
                    while (!IsOperator(expression[i]) && expression[i] != ')')
                    {
                        postfixExpresion += expression[i];
                        i++;

                        if(i == expression.Length)
                        {
                            break;
                        }
                    }

                    postfixExpresion += " ";
                    i--;
                }
                
                if (!Char.IsDigit(expression[i]))
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

        public double SolveExpression(string postfixExpresion)
        {
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < postfixExpresion.Length; i++)
            {
                if (IsDelimiter(postfixExpresion[i]))
                {
                    continue;
                }
                else if (Char.IsDigit(postfixExpresion[i]))
                {
                    string tmp = "";

                    while (!IsDelimiter(postfixExpresion[i]))
                    {
                        tmp += postfixExpresion[i];
                        i++;
                    }
                    stack.Push(Convert.ToDouble(tmp));

                }
                else
                {
                    double resultOperation = 0;
                    double numberOne = stack.Pop();
                    double numberTwo = stack.Pop();

                    switch (postfixExpresion[i])
                    {
                        case '*':
                            resultOperation = numberTwo * numberOne;
                            break;
                        case '/':
                            resultOperation = numberTwo / numberOne;
                            break;
                        case '+':
                            resultOperation = numberTwo + numberOne;
                            break;
                        case '-':
                            resultOperation = numberTwo - numberOne;
                            break;

                    }
                    stack.Push(resultOperation);

                }


            }

            return stack.Pop();
        }

        private bool IsOperator(char simbol)
        {
            bool result;

            switch (simbol)
            {
                case '*':
                    result = true;
                    break;
                case '+':
                    result = true;
                    break;
                case '-':
                    result = true;
                    break;
                case '/':
                    result = true;
                    break;
                case '(':
                    result = true;
                    break;
                case ')':
                    result = true;
                    break;
                default:
                    result = false;
                    break;
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

        private int GetPriority(char simbol)
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