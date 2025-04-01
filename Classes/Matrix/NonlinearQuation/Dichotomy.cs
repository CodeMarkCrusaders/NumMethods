public partial class Matrix<T>{
    static public double DichotomyMethod(Func<double, double> f, double a, double b, double eps = 1e-9, int maxIterations = 1000){
        if (f(a) * f(b) > 0)
            throw new ArgumentException("Функция должна иметь разные знаки на концах отрезка [a, b].");

        for (int i = 0; i < maxIterations; i++)
        {
            double c = (a + b) / 2.0;
            if (Math.Abs(f(c)) < eps || Math.Abs(b - a) < eps)
                return c;

            if (f(a) * f(c) < 0)
                b = c;
            else
                a = c;
        }
        throw new Exception("Достигнуто максимальное число итераций, решение не найдено.");
    }
}