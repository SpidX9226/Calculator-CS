namespace Calculator_CS;
static class Calculator {
    private static double _result;
    public static double Add(double a, double b) {
        _result = a + b;
        return _result;
    }
    public static double Substract(double a, double b) {
        _result = a - b;
        return _result;
    }
    public static double Multiply(double a, double b) {
        _result = a * b;
        return _result;
    }
    public static double Divide(double a, double b) {
        if (b == 0) {
            throw new DivideByZeroException();
        } else {
            _result = a / b;
            return _result;
        }
    }

    public static double Fraction(double a)
    {
        double result = Divide(1, a);
        return result;
    }

    public static double Percent(double a, double b) {
        if (b == 0) {
            throw new DivideByZeroException();
        }

        double result = (a / b) * 100.0;
        return result;
    }
    public static double Squaring(double a) {
        _result = a * a;
        return _result;
    }
    public static double SquareRoot(double a) {
        _result = Math.Sqrt(a);
        return _result;
    }

    public static double MPlus(double a) => _result += a;
    public static double MSub(double a) => _result -= a;
    public static double Mr() => _result;
}