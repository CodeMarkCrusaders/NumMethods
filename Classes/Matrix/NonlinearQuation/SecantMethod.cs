public partial class Matrix<T>{
    static public double SecantMethod(Func<double, double> f, double x0 = 0, double eps = 1e-9, int maxIterations = 1000)
    {
        double delta = 1e-6;
        double x1 = x0;
        double x2 = x0 + delta;

        for (int i = 0; i < maxIterations; i++)
        {
            double f1 = f(x1);
            double f2 = f(x2);
            
            if (Math.Abs(f2) < eps)
                return x2;
                
            double derivative = (f2 - f1) / (x2 - x1);
            if (Math.Abs(derivative) < eps)
                throw new Exception("Производная равна нулю, решение не найдено.");
                
            double xNext = x2 - f2 * (x2 - x1) / (f2 - f1);
            x1 = x2;
            x2 = xNext;
        }

        throw new Exception("Достигнуто максимальное число итераций, решение не найдено.");
    }
}