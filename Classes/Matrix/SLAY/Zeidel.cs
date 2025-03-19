public partial class Matrix<T>{
    public double[] Zeidel(T[] X, double eps = 1e-9){
        if (!this.IsDiagonallyDominant()) throw new ArgumentException("Matrix must be diagonally dominant to use Zeidel method.");
        double[] xPrev = new double[X.Length];
        double[] x = new double[X.Length];

        do
        {
            Array.Copy(x, xPrev, x.Length);
            for (int i = 0; i < (int)NbLines; i++)
            {
                double sum1 = 0;
                double sum2 = 0;
                for (int j = 0; j < i; j++)
                {
                    sum1 += (double)(dynamic)_matrix[i, j] * (double)(dynamic)x[j];
                }
                for (int j = i + 1; j < (int)NbColumns; j++)
                {
                    sum2 += (double)(dynamic)_matrix[i, j] * (double)(dynamic)xPrev[j];
                }
                double aii = (double)(dynamic)_matrix[i, i];
                double bi = (double)(dynamic)X[i];
                double xi = (bi - sum1 - sum2) / aii;
                x[i] = xi;
            }
        } while (Norm(x, xPrev) > eps);

        return x;
    }

    public bool IsZeidelConvergent()
    {
        int n = (int)NbLines;
        var A = new double[n, n];
        // Build full double matrix from _matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i, j] = (double)(dynamic)_matrix[i, j];
            }
        }
        
        // Build (D+L) and U from A
        var lower = new double[n, n];
        var upper = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j <= i)
                    lower[i, j] = A[i, j];
                else
                    upper[i, j] = A[i, j];
            }
        }
        
        // Invert lower triangular matrix (D+L)
        var lowerInv = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            if (Math.Abs(lower[i, i]) < 1e-12)
                throw new InvalidOperationException("Zero on diagonal while computing inverse.");
            for (int j = 0; j <= i; j++)
            {
                if (i == j)
                {
                    lowerInv[i, j] = 1.0 / lower[i, i];
                }
                else
                {
                    double sum = 0;
                    for (int k = j; k < i; k++)
                    {
                        sum += lower[i, k] * lowerInv[k, j];
                    }
                    lowerInv[i, j] = -sum / lower[i, i];
                }
            }
        }
        
        // Compute iteration matrix G = -(D+L)^(-1) * U
        var G = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                double sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum += lowerInv[i, k] * upper[k, j];
                }
                G[i, j] = -sum;
            }
        }
        
        // Estimate spectral radius using power iteration
        const int maxIter = 1000;
        const double tol = 1e-9;
        var v = new double[n];
        for (int i = 0; i < n; i++) v[i] = 1.0;
        double eigenEstimate = 0.0;

        for (int iter = 0; iter < maxIter; iter++)
        {
            var w = new double[n];
            // Compute w = G * v
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    w[i] += G[i, j] * v[j];
                }
            }
            
            // Compute norm of w
            double norm = 0.0;
            for (int i = 0; i < n; i++)
            {
                norm += w[i] * w[i];
            }
            norm = Math.Sqrt(norm);
            if (Math.Abs(norm) < tol)
                break;
            
            // Normalize w and update eigenvalue estimate (using any component)
            double newEstimate = Math.Abs(w[0]) / Math.Abs(v[0]);
            for (int i = 0; i < n; i++)
            {
                v[i] = w[i] / norm;
            }
            
            if (Math.Abs(newEstimate - eigenEstimate) < tol)
            {
                eigenEstimate = newEstimate;
                break;
            }
            eigenEstimate = newEstimate;
        }
        
        return eigenEstimate < 1.0;
    }
}