//Реализация базовых методов для класса Matrix
public partial class Matrix<T>: IMatrix<T> where T: struct{

    // Метод сложения матриц (Может приводить к ошибкам, если int + double)
    public Matrix<T> Add(Matrix<T> matrix){
        if (NbLines != matrix.NbLines || NbColumns != matrix.NbColumns){
            throw new ArgumentException("Matrices must be of the same dimension");
        }
        for (int i=0; i < NbLines; i++){
            for (int j=0; j < NbColumns; j++){
                this[i,j] = (dynamic)this[i,j] + (dynamic)matrix[i,j];
            }
        }
        return this;
    }

    public Matrix<T> Substract(Matrix<T> matrix){
        if (NbLines != matrix.NbLines || NbColumns != matrix.NbColumns){
            throw new ArgumentException("Matrices must be of the same dimension");
        }
        for (int i=0; i < NbLines; i++){
            for (int j=0; j < NbColumns; j++){
                this[i,j] = (dynamic)this[i,j] - (dynamic)matrix[i,j];
            }
        }
        return this;
    }

    public  Matrix<T> Multiply(Matrix<T> matrix){
        if (NbColumns != matrix.NbLines){
            throw new ArgumentException("The number of columns of the first matrix must be equal to the number of lines of the second matrix");
        }
        Matrix<T> result = new Matrix<T>(NbLines, matrix.NbColumns);
        for (int i=0; i < NbLines; i++){
            for (int j=0; j < matrix.NbColumns; j++){
                for (int k=0; k < NbColumns; k++){
                    result[i,j] += (dynamic)this[i,k] * (dynamic)matrix[k,j];
                }
            }
        }
        return result;
    }

    public Matrix<T> Multiply<P>(P scalar) where P : struct{
        for (int i=0; i < NbLines; i++){
            for (int j=0; j < NbColumns; j++){
                this[i,j] = (dynamic)this[i,j] * (dynamic)scalar;
            }
        }
        return this;
    }
}