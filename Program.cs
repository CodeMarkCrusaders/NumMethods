class Program
{   
    static void Main(string[] args)
    {
        

        double f1(double[] x) => 2*Math.Pow(x[0],2)-x[0]*x[1]-5*x[0]+1;
        double d1(double[] x) => Math.Sin(2*x[0]-x[1])-1.2*x[0];

        double f2(double[] x) => x[0]+3*Math.Log(x[0])-Math.Pow(x[1],2);
        double d2(double[] x) => Math.Pow(x[0],2)*0.8+1.5*Math.Pow(x[1],2);

        double[] x = Matrix<double>.NewtonSNLY([d1, d2], [0.4, 1], [.15, -2], maxIterations: 1000);
        Console.WriteLine("Метод простой итерации:");
        Console.WriteLine($"x1 = {x[0]}, x2 = {x[1]}");

        double f3(double x) => 2*Math.Pow(x,2)-x*x-5*x+1;

        // Console.WriteLine("Метод деления отрезка:");
        // Console.WriteLine(Matrix<double>.DichotomyMethod(f, 0, 1));
        // Console.WriteLine("Метод простой итерации:");
        // Console.WriteLine(Matrix<double>.SimpleIterationMethod(f, 0.5));
        // Console.WriteLine("Метод ньютона:");
        // Console.WriteLine(Matrix<double>.NewtonMethod(f, 0.3));
        // Console.WriteLine("Метод секущих:");
        // Console.WriteLine(Matrix<int>.SecantMethod(f, 0.3));
        // Console.WriteLine("Хорд:");
        // Console.WriteLine(Matrix<int>.ChordMethod(f, 0, 1));
        // Console.WriteLine("Касательных");
        // Console.WriteLine(Matrix<int>.TangentMethod(f, 0, 1));
    }
}
