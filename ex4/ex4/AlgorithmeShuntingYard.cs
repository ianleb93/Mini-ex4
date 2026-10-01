namespace ex4;

public class AlgorithmeShuntingYard()
{
    Stack<char> operandStack = new Stack<char>();
    
    public static Queue<char> ConvertirEnPostfix(string expressionInfix)
    {
        
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
