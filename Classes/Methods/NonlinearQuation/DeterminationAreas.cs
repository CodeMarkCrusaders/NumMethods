public partial class Matrix<T> : IMatrix<T>
{
    static public (double a, double b)[] DeterminationAreas(Func<double, double> f, int numberRoots,  int a = -100, int b = 100, double eps = 1e-1, int maxIterations = 1000)
    {
        double h = 10;
        int i = 0;
        do
        {
            double x = a;
            List<(double, double)> intervals = new List<(double, double)>();
            while (x < b)
            {
                if (f(x) * f(x + h) < 0)
                {
                    intervals.Add((x, x + h));
                }
                x += h;
                i++;
            }
            if (intervals.Count == numberRoots)
            {
                return intervals.ToArray();
            }
            h /= 5;
        } while (h > eps && i++ < maxIterations);
        throw new Exception("Достигнуто максимальное число итераций, решение не найдено.");
    }
}