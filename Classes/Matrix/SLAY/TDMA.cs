public partial class Matrix<T>{
    public double[] TDMA(T[] X)
    {
        if (NbColumns != NbLines) throw new ArgumentException("Matrix must be square");
        if (this.IsTridiagonal() == false) throw new ArgumentException("Matrix must be tridiagonal");

        double[] a = Array.ConvertAll(new T[1].Concat(this[Val.Diagonal, -1]).ToArray(), n => Convert.ToDouble(n));
        double[] b = Array.ConvertAll(this[Val.Diagonal, 0], n => Convert.ToDouble(n));
        double[] c = Array.ConvertAll(this[Val.Diagonal, 1].Concat(new T[1]).ToArray(), n => Convert.ToDouble(n));
        double[] dDouble = Array.ConvertAll(X, n => Convert.ToDouble(n));

        int n = X.Length;
        double[] cPrime = new double[n]; 
        double[] dPrime = new double[n];
        double[] x = new double[n];

        cPrime[0] = c[0] / b[0];
        dPrime[0] = dDouble[0] / b[0];

        for (int i = 1; i < n; i++)
        {
            cPrime[i] = c[i] / (b[i] - a[i] * cPrime[i - 1]);
            dPrime[i] = (dDouble[i] - a[i] * dPrime[i - 1]) / (b[i] - a[i] * cPrime[i - 1]);
        }

        x[n - 1] = dPrime[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            x[i] = dPrime[i] - cPrime[i] * x[i + 1];
        }

        return x;
    }
}