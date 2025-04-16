public partial class Matrix<T>
{
    static public double TangentMethod(Func<double, double> f, double a, double b, double eps = 1e-9, int maxIterations = 1000)
    {
        double x0 = a;
        double x1 = x0 - f(x0) / Derivative(f, x0);
        int iterations = 0;

        while (Math.Abs(x1 - x0) > eps && iterations < maxIterations)
        {
            x0 = x1;
            x1 = x0 - f(x0) / Derivative(f, x0);
            iterations++;
        }

        if (iterations >= maxIterations)
            throw new Exception("Method did not converge");

        return x1;
    }

    static double Derivative(Func<double, double> f, double x, double h = 1e-6)
    {
        return (f(x + h) - f(x)) / h;
    }
}