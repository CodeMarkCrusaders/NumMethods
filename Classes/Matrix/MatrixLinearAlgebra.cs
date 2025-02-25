public partial class Matrix<T> 
{

    public Matrix<T> Minor(int row, int col){
        if (NbLines != NbColumns) {
            throw new ArgumentException("Matrix must be square");
        }
        Matrix<T> result = new Matrix<T>(NbLines - 1, NbColumns - 1);

        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                if (i != row && j != col) {
                    result[i < row ? i : i - 1, j < col ? j : j - 1] = this[i, j];
                }
            }
        }

        return result;
    }
    public Matrix<T> Transpose(){
        Matrix<T> result = new Matrix<T>(NbColumns, NbLines);

        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                result[j, i] = this[i, j];
            }
        }

        return result;
    }
    
    public double Determinant(){
        if (NbLines != NbColumns) 
            throw new ArgumentException("Matrix must be square");
        
        if (NbLines == 1) 
            return (dynamic)this[0, 0];
    
        if (NbLines == 2) 
            return (dynamic)this[0, 0] * (dynamic)this[1, 1] - (dynamic)this[0, 1] * (dynamic)this[1, 0];

        double det = 0;
        for (int i = 0; i < NbLines; i++) {
            det += Math.Pow(-1, i) * (dynamic)this[0, i] * this.Minor(0, i).Determinant();
        }

        return det;
    }

    public Matrix<T> Invert(){
        if (NbLines != NbColumns) 
            throw new ArgumentException("Matrix must be square");
        
        double det = this.Determinant();
        if (det == 0) 
            throw new ArgumentException("Matrix must be regular");
        
        Matrix<T> result = new Matrix<T>(NbLines, NbColumns);
        for (int i = 0; i < NbLines; i++) {
            for (int j = 0; j < NbColumns; j++) {
                result[i, j] = Math.Pow(-1, i + j) * (dynamic)this.Minor(j, i).Determinant() / det;
            }
        }

        return result;
    }
}