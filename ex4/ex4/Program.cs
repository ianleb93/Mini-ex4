// Auteurs : Alexandre Goddard et Ian Leblanc

using System;
using System.Collections.Generic;

namespace ex4;

internal static class Program
{
    private static void TestCalculatrice(string expressionInfix)
    {
        Console.WriteLine($"Expression infixee : {expressionInfix}");
        
        var expressionPostfix = AlgorithmeShuntingYard.ConvertirEnPostfix(expressionInfix);
        Console.WriteLine($"Expression postfixee : {string.Join(" ", expressionPostfix)}");
        
        var result = AlgorithmeShuntingYard.EvaluatePostfixExpression(expressionPostfix);
        Console.WriteLine($"Resultat : {result}");
        
        Console.WriteLine();
    }
    private static void Main()
    {
        TestCalculatrice("3 + 4");
        TestCalculatrice("3 + 4 * 2");
        TestCalculatrice("3 + 4 * 2 + 6 + 8");
        
    }
}
