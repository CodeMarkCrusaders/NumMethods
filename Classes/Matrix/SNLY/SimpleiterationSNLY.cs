public partial class Matrix<T>{
    public double[] SimpleIterationSNLY(T[] X, double eps = 1e-9){
        if (!this.IsSquare()) throw new ArgumentException("Матрица должна быть квадратной");
        double[] xPrev = new double[X.Length];
        double[] x = new double[X.Length];

        do {    
            Array.Copy(x, xPrev, x.Length);
            for (int i = 0; i < (int)NbLines; i++) {
                double sum = 0;
                for (int j = 0; j < (int)NbColumns; j++) {
                    if (j == i) continue;
                    sum += (double)(dynamic)_matrix[i, j] * xPrev[j];
                }
                x[i] = ((double)(dynamic)X[i] - sum) / (double)(dynamic)_matrix[i, i];
            }
        } while (Math.Sqrt(x.Zip(xPrev, (a, b) => (a - b) * (a - b)).Sum()) > eps);

        return x;
    }
}