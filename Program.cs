class Program
{
    static void Main(string[] args)
    {
        Matrix<int>matrix = new Matrix<int>(new int[,]{
            {2, 4, -1},
            {-1, 2, 4},
            {5, 1, -1}
        });

        matrix = matrix.MakeDiagonallyDominant();
        Console.WriteLine(matrix);
        
        foreach (var item in matrix.Zeidel(new int[]{5, 5, 5}, 0.01))
        {
            Console.WriteLine(item);
        }
    }
}
