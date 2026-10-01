namespace ex4;

public class AlgorithmeShuntingYard
{
    public static Stack<char> operandStack = new Stack<char>();
    
    public static Queue<char> ConvertirEnPostfix(string expressionInfix)
    {
        Queue<char> local = new Queue<char>();

        foreach (char c in expressionInfix)
        {
            if (c is '+' or '-' or '*' or '/')
            {
                while (operandStack.Count > 0 && !(c is '*' or '/' && operandStack.Peek() is '+' or '-'))
                {
                    local.Enqueue(operandStack.Pop());
                }
                operandStack.Push(c);
            }
            else if (char.IsDigit(c))
            {
                local.Enqueue(c);
            }
        }

        while (operandStack.Count > 0)
        {
            local.Enqueue(operandStack.Pop());
        }
        return local;
    }

    public static int EvaluatePostfixExpression(Queue<char> postfixExpression)
    {

        Stack<int> stack = new Stack<int>();

        while (postfixExpression.Count > 0)
        {
            switch (postfixExpression.Peek())
            {
                case '/':
                    stack.Push(stack.Pop() / stack.Pop());
                    postfixExpression.Dequeue();
                    break;
                case '*':
                    stack.Push((stack.Pop() * stack.Pop()));
                    postfixExpression.Dequeue();
                    break;
                case '+':
                    stack.Push(stack.Pop() + stack.Pop());
                    postfixExpression.Dequeue();
                    break;
                case '-':
                    stack.Push(stack.Pop() - stack.Pop());
                    postfixExpression.Dequeue();
                    break;
                default:
                    int test = 0;
                    int.TryParse(postfixExpression.Dequeue().ToString(), out test);
                    stack.Push(test);
                    break;
            }
        }
        return stack.Pop();
    }
}
