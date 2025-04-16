public partial class Matrix<T>{
    public double Hommer(Func<double, double> f, double a, double b, int n = 1000)
    {
        if(n<=0)
            throw new ArgumentException("Количество разбиений должно быть положительным числом.");
        if (a > b)
            throw new ArgumentException("Левая граница должна быть меньше правой границы.");
        double h = (b - a) / n;
        double sum = f(a) + f(b);
        for (int i = 1; i < n; i++)
        {
            if (i % 2 == 0)
                sum += 2 * f(a + i * h);
            else
                sum += 4 * f(a + i * h);
        }
        return sum * h / 3;
    }
}