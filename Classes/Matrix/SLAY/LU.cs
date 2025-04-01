public partial class Matrix<T>{
    
    public (Matrix<double>, Matrix<double>) LUDecomposition(){
        if (!this.IsSquare()) throw new ArgumentException("Matrix must be square");

        Matrix<double> L = new Matrix<double>(NbLines, NbColumns);
        Matrix<double> U = new Matrix<double>(NbLines, NbColumns);

        for (int i = 0; i < NbLines; i++)
        {
            L[i, i] = 1;
        }
        
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                if (i <= j) {
                    U[i, j] = (dynamic)this[i, j] -  Matrix<double>.MultiplyRowByColumn(L, i, U, j);
                }
                else{
                    L[i, j] = ((dynamic)this[i, j] - Matrix<double>.MultiplyRowByColumn(L, i, U, j)) / U[j, j];
                }
            }
        }

        return (L, U);
    }

    public double[] SLAYLUDecomposition(T[] X){
        if (NbColumns != NbLines) throw new ArgumentException("Matrix must be square");

        (Matrix<double> L, Matrix<double> U) = LUDecomposition();
        double[] y = new double[NbLines];
        double[] x = new double[NbLines];

        for (int i = 0; i < NbLines; i++)
        {
            y[i] = (dynamic)X[i] - Matrix<double>.MultiplyRowByColumn(L, i, y);
        }

        for (int i = (int)NbLines - 1; i >= 0; i--)
        {
            x[i] = (y[i] - Matrix<double>.MultiplyRowByColumn(U, i, x)) / U[i, i];
        }

        return x;
    }
}