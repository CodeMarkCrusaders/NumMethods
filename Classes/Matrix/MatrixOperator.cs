public partial class Matrix<T>{
    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        return a.Add(b);
    }

    public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
    {
        return a.Substract(b);
    }

    public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
    {
        return a.Multiply(b);
    }

    public static Matrix<T> operator *(T a, Matrix<T> b)
    {
        return b.Multiply(a);
    }

    public static Matrix<T> operator *(Matrix<T> a, T b)
    {
        return a.Multiply(b);
    }
}