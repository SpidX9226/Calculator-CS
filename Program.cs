namespace Calculator_CS;

internal static class Program
{
    private static readonly string[] BinaryOps = ["+", "-", "*", "/", "%"];
    private static readonly string[] UnaryOps = ["1/x", "x^2", "sqrt(x)", "M+", "M-", "Mr"];
    private static readonly string[] AllOps = BinaryOps.Concat(UnaryOps).ToArray();

    public static void Main(string[] args)
    {
        do
        {
            ShowOperators();
            string opr = (Console.ReadLine() ?? "+").ToLower().Trim();

            if (Array.IndexOf(BinaryOps, opr) >= 0)
            {
                double x = ReadDouble("Enter first variable: ");
                double y = ReadDouble("Enter second variable: ");
                double res = HandleBinary(opr, x, y);
                Console.WriteLine($"{x} {opr} {y} = {res}");
            } else if (string.Equals(opr, "Mr", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(Calculator.Mr());
            }
            else if (Array.IndexOf(UnaryOps, opr) >= 0)
            {
                double x = ReadDouble("Enter variable: ");
                double res = HandleUnary(opr, x);
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("Unknow operation.");
            }
        } while (ConfirmExit());
    }

    private static void ShowOperators()
    {
        Console.Write("Operators: ");
        
        foreach (var op in AllOps)
            Console.Write(op);
        
        Console.WriteLine(); Console.Write("Choose operator: ");
    }

    private static double ReadDouble(string prompt)
    {
        do
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double result)) 
                return result;
        } while (true);
    }

    private static double HandleBinary(string opr, double x, double y)
    {
        try
        {
            return opr switch
            {
                "+" => Calculator.Add(x, y),
                "-" => Calculator.Substract(x, y),
                "*" => Calculator.Multiply(x, y),
                "/" => Calculator.Divide(x, y),
                "%" => Calculator.Percent(x, y),
                _ => throw new InvalidOperationException("Invalid operator")
            };
        }
        catch (DivideByZeroException)
        {
            WriteError("You cannot divide by zero!");
            return double.NaN;
        }
    }

    private static double HandleUnary(string opr, double x)
    {
        try
        {
            return opr switch
            {
                "1/x" => Calculator.Fraction(x),
                "x^2" => Calculator.Squaring(x),
                "sqrt(x)" => Calculator.SquareRoot(x),
                "M+" => Calculator.MPlus(x),
                "M-" => Calculator.MSub(x),
                "Mr" => Calculator.Mr(),
                _ => throw new InvalidOperationException("Unknown unary operator")
            };
        }
        catch (DivideByZeroException)
        {
            WriteError("You cannot divide by zero!");
            return double.NaN;
        }
    }

    private static bool ConfirmExit()
    {
        Console.WriteLine("Do you want to exit? (y/n)");
        return Console.ReadLine()?.ToLower() == "n";
    }

    private static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(message);
        Console.ResetColor();
    }
}