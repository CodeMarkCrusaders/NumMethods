
public partial class Matrix<T>{
    public double[] SimpleIteration(T[] X, double eps = 1e-9){
        if (!this.IsDiagonallyDominant()) throw new ArgumentException("Матрица должна быть диагонально доминирующей");
        double[] xPrev = new double[X.Length];
        double[] x = new double[X.Length];

        do
        {
            Array.Copy(x, xPrev, x.Length);
            for (int i = 0; i < (int)NbLines; i++)
            {
                double sum = 0;
                for (int j = 0; j < (int)NbColumns; j++)
                {
                    if (j == i) continue;
                    sum += (double)(dynamic)_matrix[i, j] * (double)(dynamic)xPrev[j];
                }
                double aii = (double)(dynamic)_matrix[i, i];
                double bi = (double)(dynamic)X[i];
                double xi = (bi - sum) / aii;
                x[i] = xi;
            }
        } while (Norm(x, xPrev) > eps);

        return x;
    }

    public Matrix<T> MakeDiagonallyDominant(){
        if (this.IsDiagonallyDominant()) return this;
        if (NbLines != NbColumns)
            throw new ArgumentException("Матрица должна быть квадратной");

        int n = (int)NbLines;
        int[] permutation = new int[n];
        bool[] used = new bool[n];

        bool FindPermutation(int col)
        {
            if (col == n)
                return true;
            for (int r = 0; r < n; r++)
            {
                if (used[r])
                    continue;
                double diag = Math.Abs((double)(dynamic)this[r, col]);
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != col)
                        sum += Math.Abs((double)(dynamic)this[r, j]);
                }
                if (diag >= sum)
                {
                    used[r] = true;
                    permutation[col] = r;
                    if (FindPermutation(col + 1))
                        return true;
                    used[r] = false;
                }
            }
            return false;
        }

        if (!FindPermutation(0))
            throw new Exception("Невозможно сделать матрицу диагонально доминирующей");

        // Create new matrix with rows reordered according to the found permutation.
        T[,] newMatrix = new T[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                newMatrix[i, j] = this[permutation[i], j];
            }
        }
        _matrix = newMatrix;
        return this;   
    }

    public bool IsSimpleIterationConvergent()
    {
        if (NbLines != NbColumns) throw new ArgumentException("Матрица должна быть квадратной для проверки сходимости.");

        int n = (int)NbLines;
        for (int i = 0; i < n; i++)
        {
            double diag = Math.Abs((double)(dynamic)this[i, i]);
            if (diag == 0)
                return false;
            double sum = 0;
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                sum += Math.Abs((double)(dynamic)this[i, j]) / diag;
            }
            if (sum >= 1)
                return false;
        }
        return true;
    }
}