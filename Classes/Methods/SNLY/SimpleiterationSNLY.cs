public partial class Matrix<T>{
    public static double[] SimpleIterationSNLY(Func<double[], double>[] f, double[] x0, double eps = 1e-9, int maxIterations = 1000)
    {
        double[] xOld = new double[f.Length];
        double[] xNew = new double[f.Length];

        Array.Copy(x0, xOld, x0.Length);

        int iteration = 0;
        while (iteration < maxIterations)
        {
            for (int i = 0; i < f.Length; i++)
            {
                xNew[i] = f[i](xOld);
            }
            Console.WriteLine($"Iteration {iteration + 1}: x = [{string.Join(", ", xNew)}]");
            double norm = 0;
            for (int i = 0; i < f.Length; i++)
            {
                norm = Math.Max(norm, Math.Abs(xNew[i] - xOld[i]));
            }

            if (norm < eps)
            {
                break;
            }

            Array.Copy(xNew, xOld, xNew.Length);
            iteration++;
        }
        return new double[] { }; 
    }
}