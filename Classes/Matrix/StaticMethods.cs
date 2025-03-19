public partial class Matrix<T>{
    static public double MultiplyRowByColumn<T1, T2>(Matrix<T1> matrix1, int row, Matrix<T2> matrix2, int column) where T1 : struct where T2 : struct
    {
        if (matrix1.NbColumns != matrix2.NbLines) throw new ArgumentException("Matrix1 NbLines must be equal to Matrix2 NbColumns");

        double result = 0;
        for (int i = 0; i < matrix1.NbLines; i++)
        {
            result += (dynamic)matrix1[row, i] * (dynamic)matrix2[i, column];
        }
        return result;
    }

    static public double MultiplyRowByColumn<T1, T2>(T1[,] matrix1, int row, T2[,] matrix2, int column) where T1 : struct where T2 : struct
    {
        if (matrix1.GetUpperBound(0) != matrix2.GetUpperBound(1)) throw new ArgumentException("Matrix1 NbLines must be equal to Matrix2 NbColumns");

        double result = 0;
        for (int i = 0; i < matrix1.GetUpperBound(0)+1; i++)
        {
            result += (dynamic)matrix1[row, i] * (dynamic)matrix2[i, column];
        }
        return result;
    }

    static public double MultiplyRowByColumn<T1, T2>(T1[,] matrix1, int row, T2[] column) where T1 : struct where T2 : struct
    {
        if (matrix1.GetUpperBound(0) + 1!= column.Length) throw new ArgumentException("Matrix1 NbLines must be equal to Column");

        double result = 0;
        for (int i = 0; i < matrix1.GetUpperBound(0)+1; i++)
        {
            result += (dynamic)matrix1[row, i] * (dynamic)column[i];
        }
        return result;
    }

    static public double MultiplyRowByColumn<T1, T2>(Matrix<T1> matrix1, int row, T2[] column) where T1 : struct where T2 : struct
    {
            if (matrix1.NbLines != column.Length) throw new ArgumentException("Matrix1 NbLines must be equal to Matrix2 NbColumns");

        double result = 0;
        for (int i = 0; i < matrix1.NbLines; i++)
        {
            result += (dynamic)matrix1[row, i] * (dynamic)column[i];
        }
        return result;
    }
}