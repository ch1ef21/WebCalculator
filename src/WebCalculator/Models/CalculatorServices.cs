using System;

namespace WebCalculator.Models;

public class CalculatorService
{
    public double Calculate(double a, double b, string operation)
    {
        return operation.ToLower() switch
        {
            "add" => a + b,
            "subtract" => a - b,
            "multiply" => a * b,
            "divide" => b == 0 
                ? throw new DivideByZeroException("Деление на ноль невозможно!") 
                : a / b,
            "power" => Math.Pow(a, b),
            _ => throw new ArgumentException($"Неизвестная операция: {operation}")
        };
    }
}