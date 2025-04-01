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
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
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
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
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
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
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
            throw new ArgumentException("Деление на ноль");
        }
        Matrix<double> result = new Matrix<double>(NbLines, NbColumns);

        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                result[i, j] = (dynamic)this[i, j] / (dynamic)scalar;
            }
        }

        return result;
    }

    public Matrix<T> Join(Val key, T[] value, int index){
        if (index == -1) index = key == Val.Horizontal? (int)NbColumns : (int)NbLines;
        if (index < 0 && key != Val.Diagonal) {
            throw new ArgumentException("Индекс должен быть больше или равен нулю");
        }
        switch (key){
            case Val.Vertical:
                if (value.Length != NbLines) {
                    throw new ArgumentException("Длина массива должна быть равна количеству строк");
                }

                Matrix<T> result1 = new Matrix<T>(NbLines, NbColumns+1);

                for (int i = 0; i < NbLines; i++) {
                    for (int j = 0; j < NbColumns+1; j++) {
                        if (j == index) {
                            result1[i, j] = value[i];
                        } else if (j < index) {
                            result1[i, j] = this[i, j];
                        } else {
                            result1[i, j] = this[i, j-1];
                        }
                    }
                }
                return result1;

            case Val.Horizontal:
                if (value.Length != NbColumns) {
                    throw new ArgumentException("Длина массива должна быть равна количеству столбцов");
                }
                
                Matrix<T> result2 = new Matrix<T>(NbLines+1, NbColumns);

                for (int i = 0; i < NbLines+1; i++) {
                    for (int j = 0; j < NbColumns; j++) {
                        if (i == index) {
                            result2[i, j] = value[j];
                        } else if (i < index) {
                            result2[i, j] = this[i, j];
                        } else {
                            result2[i, j] = this[i-1, j];
                        }
                    }
                }
                return result2;

            default:
                throw new ArgumentException("Недопустимый параметр");
        }
    }
}