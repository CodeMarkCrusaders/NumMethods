//Реализация базовых методов для класса Matrix
public partial class Matrix<T>: IMatrix<T> where T: struct{

    public override string ToString(){
        string result = "";
        for (int i=0; i < NbLines; i++){
            for (int j=0; j < NbColumns; j++){
                result += this[i,j].ToString() + " ";
            }
            result += "\n";
        }
        return result;
    }

    /// <summary>
    /// Складывает две матрицы, возможно, разных числовых типов и возвращает новую матрицу указанного результирующего типа.
    /// T1: Тип элементов в первой матрице.
    /// T2: Тип элементов в результирующей матрице.
    /// </summary>
    /// <returns>Новая матрица типа T2, содержащая сумму двух матриц.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если матрицы не имеют одинаковые размеры.</exception>
    public Matrix<T> Add(Matrix<T> matrix1){
        if (NbLines != matrix1.NbLines || NbColumns != matrix1.NbColumns) {
            throw new ArgumentException("Matrices must be of the same dimension");
        }

        for (int i = 0; i < matrix1.NbLines; i++) {
            for (int j = 0; j < matrix1.NbColumns; j++) {
                this[i, j] = (dynamic)this[i, j] + (dynamic)matrix1[i, j]; 
            }
        }

        return this;
    } 

    /// <summary>
    /// Находит разницу двух матриц, возможно, разных числовых типов и возвращает новую матрицу указанного результирующего типа.
    /// T1: Тип элементов в первой матрице.
    /// T2: Тип элементов в результирующей матрице.
    /// </summary>
    /// <returns>Новая матрица типа T2, содержащая разность двух матриц.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если матрицы не имеют одинаковые размеры.</exception>
    public Matrix<T> Substract(Matrix<T> matrix1){
        if (NbLines != matrix1.NbLines || NbColumns != matrix1.NbColumns) {
            throw new ArgumentException("Matrices must be of the same dimension");
        }

        for (int i = 0; i < matrix1.NbLines; i++) {
            for (int j = 0; j < matrix1.NbColumns; j++) {
                this[i, j] = (dynamic)this[i, j] - (dynamic)matrix1[i, j]; 
            }
        }

        return this;
    }

    public Matrix<T> Multiply(Matrix<T> matrix1){
        if (NbColumns != matrix1.NbLines) {
            throw new ArgumentException("Matrices must be of the same dimension");
        }
        Matrix<T> result = new Matrix<T>(NbLines, matrix1.NbColumns);

        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < matrix1.NbColumns; j++) {
                for (int k = 0; k < NbColumns; k++) {
                    result[i, j] += (dynamic)this[i, k] * (dynamic)matrix1[k, j];
                }
            }
        }

        return result;
    }

    public Matrix<T> Multiply(T scalar){
        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                this[i, j] = (dynamic)this[i, j] * (dynamic)scalar; 
            }
        }

        return this;
    }
    
    public Matrix<double> Divide<T1>(T1 scalar) where T1: struct{
        if (scalar.Equals(0)) {
            throw new ArgumentException("Division by zero");
        }
        Matrix<double> result = new Matrix<double>(NbLines, NbColumns);

        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                result[i, j] = (dynamic)this[i, j] / (dynamic)scalar;
            }
        }

        return result;
    }

    
}