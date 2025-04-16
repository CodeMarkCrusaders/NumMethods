public partial class Matrix<T>{
    public double LeftRectangle(Func<double, double> f, double a, double b, int n = 1000)
    {
        if(n<=0)
            throw new ArgumentException("Количество разбиений должно быть положительным числом.");
        if (a > b)
            throw new ArgumentException("Левая граница должна быть меньше правой границы.");
        double h = (b - a) / n;
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += f(a + i * h);
        }
        return sum * h;
    }
    public double RightRectangle(Func<double, double> f, double a, double b, int n = 1000)
    {
        if(n<=0)
            throw new ArgumentException("Количество разбиений должно быть положительным числом.");
        if (a > b)
            throw new ArgumentException("Левая граница должна быть меньше правой границы.");
        double h = (b - a) / n;
        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += f(a + i * h);
        }
        return sum * h;
    }
    public double MiddleRectangle(Func<double, double> f, double a, double b, int n = 1000)
    {
        if(n<=0)
            throw new ArgumentException("Количество разбиений должно быть положительным числом.");
        if (a > b)
            throw new ArgumentException("Левая граница должна быть меньше правой границы.");
        double h = (b - a) / n;
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += f(a + (i + 0.5) * h);
        }
        return sum * h;
    }
}