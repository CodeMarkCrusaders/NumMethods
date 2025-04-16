public partial class Matrix<T>{
    public static double[] NewtonSNLY(Func<double[], double>[] f, double[] X, double[] x0, double eps = 1e-9, int maxIterations = 1000)
    {
        {
            double[] x = (double[])x0.Clone();
            int n = x.Length;
            int m = f.Length;
            const double h = 1e-6;

            for (int iter = 0; iter < maxIterations; iter++)
            {
                // Evaluate the system of equations F(x)
                double[] F = new double[m];
                for (int i = 0; i < m; i++)
                    F[i] = f[i](x);

                // Check if the current solution is good enough
                double normF = 0;
                for (int i = 0; i < m; i++)
                    normF += F[i] * F[i];
                if (Math.Sqrt(normF) < eps)
                    return x;

                // Approximate the Jacobian matrix using finite differences
                double[,] J = new double[m, n];
                for (int j = 0; j < n; j++)
                {
                    double temp = x[j];
                    x[j] += h;
                    for (int i = 0; i < m; i++)
                        J[i, j] = (f[i](x) - F[i]) / h;
                    x[j] = temp;
                }

                // Solve the linear system: J * delta = -F
                double[] negF = new double[m];
                for (int i = 0; i < m; i++)
                    negF[i] = -F[i];
                double[] delta = SolveLinearSystem(J, negF);

                // Update x and check for convergence
                double normDelta = 0;
                for (int i = 0; i < n; i++)
                {
                    x[i] += delta[i];
                    normDelta += delta[i] * delta[i];
                }
                if (Math.Sqrt(normDelta) < eps)
                    return x;
            }
            return x;

            // Local function: Gaussian elimination with partial pivoting
            double[] SolveLinearSystem(double[,] A, double[] b)
            {
                int n = b.Length;
                double[,] M = new double[n, n + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        M[i, j] = A[i, j];
                    M[i, n] = b[i];
                }

                // Forward elimination
                for (int k = 0; k < n; k++)
                {
                    // Partial pivoting
                    int maxRow = k;
                    for (int i = k + 1; i < n; i++)
                    {
                        if (Math.Abs(M[i, k]) > Math.Abs(M[maxRow, k]))
                            maxRow = i;
                    }
                    for (int j = k; j < n + 1; j++)
                    {
                        double tmp = M[k, j];
                        M[k, j] = M[maxRow, j];
                        M[maxRow, j] = tmp;
                    }
                    if (Math.Abs(M[k, k]) < 1e-12)
                        throw new Exception("Jacobian matrix is singular.");

                    for (int i = k + 1; i < n; i++)
                    {
                        double factor = M[i, k] / M[k, k];
                        for (int j = k; j < n + 1; j++)
                            M[i, j] -= factor * M[k, j];
                    }
                }

                // Back substitution
                double[] xSol = new double[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    double sum = M[i, n];
                    for (int j = i + 1; j < n; j++)
                        sum -= M[i, j] * xSol[j];
                    xSol[i] = sum / M[i, i];
                }
                return xSol;
            }
        }
    }
}