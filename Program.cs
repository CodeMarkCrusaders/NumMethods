class Program
{   
    static void Main(string[] args)
    {
        // Matrix<int>matrix = new Matrix<int>(new int[,]{
        //     {2, 4, -1},
        //     {-1, 2, 4},
        //     {5, 1, -1}
        // });

        double f(double x) => Math.Pow(x,2)-0.5;
        Console.WriteLine(f(0.865474033102));
        // matrix = matrix.MakeDiagonallyDominant();
        // Console.WriteLine(matrix);
        
        // foreach (var item in matrix.D(new int[]{5, 5, 5}, 0.0001))
        // {
        //     Console.WriteLine(item);
        // }

        Console.WriteLine("Метод деления отрезка:");
        Console.WriteLine(Matrix<double>.DichotomyMethod(f, 0, 1));
        Console.WriteLine("Метод простой итерации:");
        Console.WriteLine(Matrix<double>.SimpleIterationMethod(f, 0.5));
        Console.WriteLine("Метод ньютона:");
        Console.WriteLine(Matrix<double>.NewtonMethod(f, 0.3));
        Console.WriteLine("Метод секущих:");
        Console.WriteLine(Matrix<int>.SecantMethod(f, 0.3));
        Console.WriteLine("Хорд:");
        Console.WriteLine(Matrix<int>.ChordMethod(f, 0, 1));
        Console.WriteLine("Касательных");
        Console.WriteLine(Matrix<int>.TangentMethod(f, 0, 1));
    }
}
