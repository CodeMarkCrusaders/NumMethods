public partial class Matrix<T>{
    static public double NewtonMethod(Func<double, double> f, double x0 = 0, double eps = 1e-9, int maxIterations = 1000)
    {
        double delta = 1e-6;
        double x = x0;
        for (int i = 0; i < maxIterations; i++)
        {
            double fValue = f(x);
            if (Math.Abs(fValue) < eps)
                return x;

            double derivative = Derivative(f, x, delta);
            if (Math.Abs(derivative) < eps)
                throw new Exception("Производная равна нулю, решение не найдено.");

            x = x - fValue / derivative;
        }
        throw new Exception("Достигнуто максимальное число итераций, решение не найдено.");
    }
}