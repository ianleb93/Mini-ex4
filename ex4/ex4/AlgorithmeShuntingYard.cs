namespace ex4;

public class AlgorithmeShuntingYard
{
    public static Stack<char> operandStack = new Stack<char>();
    
    public static Queue<char> ConvertirEnPostfix(string expressionInfix)
    {
         Queue<char> local = new Queue<char>();
            
        expressionInfix = expressionInfix.Trim();
        
        foreach (char c in expressionInfix)
        {
            if (c is '+' or '-' or '*' or '/')
            {
                if (operandStack.Count > 0)
                {
                    if ((operandStack.Peek() == '*' || operandStack.Peek() == '/') && c is '-' or '+')
                    {
                        local.Enqueue(operandStack.Peek());
                        operandStack.Pop();
                    }
                    else
                    {
                        local.Enqueue(c); 
                        
                    }
               
                    
                }
                operandStack.Push(c);
            }
            else
            {
                if (char.IsDigit(c))
                {
                    local.Enqueue(c);       
                }
            }
        }
        return local;
    }
}
