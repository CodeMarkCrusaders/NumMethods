using System.Diagnostics.CodeAnalysis;

public partial class Matrix<T>{

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is T[,] array)
        {
            if (array.GetLength(0) != NbLines || array.GetLength(1) != NbColumns) return false;
            for (int i = 0; i < NbLines; i++)
            {
                for (int j = 0; j < NbColumns; j++)
                {
                    if (typeof(T) == typeof(float) || typeof(T) == typeof(double))
                    {
                        if (Math.Abs(Convert.ToSingle(this[i, j]) - Convert.ToSingle(array[i, j])) > Accuracy) return false;
                    }
                    else
                    {
                        if (!EqualityComparer<T>.Default.Equals(this[i, j], array[i, j])) return false;
                    }
                }
            }
            return true;
        }
        if (obj is Matrix<T> matrix2){
            if (matrix2.NbLines != NbLines || matrix2.NbColumns != NbColumns) return false;
            for (int i = 0; i < NbLines; i++)
            {
                for (int j = 0; j < NbColumns; j++)
                {
                    if (typeof(T) == typeof(float) || typeof(T) == typeof(double))
                    {
                        if (Math.Abs(Convert.ToSingle(this[i, j]) - Convert.ToSingle(matrix2[i, j])) > Accuracy) return false;
                    }
                    else
                    {
                        if (!EqualityComparer<T>.Default.Equals(this[i, j], matrix2[i, j])) return false;
                    }
                }
            }
            return true;
        }

        return false;
    }

    public bool Equals(Matrix<T> matrix2){
        if (matrix2.NbLines != NbLines || matrix2.NbColumns != NbColumns) return false;
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                if ((dynamic)this[i,j] != (dynamic)matrix2[i, j]) return false;
            }
        }
        return true;
    }

    public bool Equal(T[,] array){
        if (array.GetLength(0) != NbLines || array.GetLength(1) != NbColumns) return false;
        bool inaccurate_comparison = (typeof(T) == typeof(float) || typeof(T) == typeof(double));
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {   
                if (inaccurate_comparison){
                    if (Math.Abs((dynamic)array[i, j] - (dynamic)this[i, j]) > Accuracy) return false;
                }
                else{
                    if ((dynamic)array[i, j] != (dynamic)this[i, j]) return false;
                }
            }
        }
        return true;
    }


    public static bool operator == (Matrix<T> matrix1, Matrix<T> matrix2) => matrix1.Equals(matrix2);
    public static bool operator != (Matrix<T> matrix1, Matrix<T> matrix2) => !matrix1.Equals(matrix2);
    public override int GetHashCode(){
        HashCode result = new HashCode();
        result.Add(NbLines);
        result.Add(NbColumns);
        return result.ToHashCode();
    }
}