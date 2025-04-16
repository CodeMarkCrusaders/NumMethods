public partial class Matrix<T>{
    public double Trapezoid(Func<double, double> f, double a, double b, int n = 1000)
    {
        if(n<=0)
            throw new ArgumentException("Количество разбиений должно быть положительным числом.");
        if (a > b)
            throw new ArgumentException("Левая граница должна быть меньше правой границы.");
        double h = (b - a) / n;
        double sum = 0.5 * (f(a) + f(b));
        for (int i = 1; i < n; i++)
        {
            sum += f(a + i * h);
        }
        return sum * h;
    }
}