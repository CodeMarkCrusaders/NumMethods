public partial class Matrix<T> 
{
    public bool IsSymetric(Val key = Val.Diagonal){
        if (NbColumns != NbLines && key == Val.Diagonal) return false;

        switch (key){
            case Val.Horizontal:
                return IsSymetricHorizontal();

            case Val.Vertical:
                return IsSymetricVertical();

            case Val.Diagonal:
                return IsSymetricDiagonal();

            default:
                return false;
        }
        

    }

    private bool IsSymetricHorizontal(){
        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < (int)(NbColumns/2); j++){
                if ((dynamic)this[i,j] != (dynamic)this[(int)(NbLines-1-i), j]) return false;
            }
        }
        return true;
    }

    private bool IsSymetricVertical(){
        for (int i = 0; i < (int)(NbLines/2); i++){
            for (int j = 0; j < NbColumns; j++){
                if ((dynamic)this[i,j] != (dynamic)this[i, (int)(NbColumns-1-j)]) return false;
            }
        }
        return true;
    }

    private bool IsSymetricDiagonal(){
        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if ((dynamic)this[i,j] != (dynamic)this[j, i]) return false;
            }
        }
        return true;
    }

    public bool IsDiagonal(){
        if (NbColumns != NbLines) return false;

        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if (i != j && (dynamic)this[i,j] != 0) return false;
            }
        }
        return true;
    }
    
    public bool IsIdentity(){
        if (NbColumns != NbLines) return false;

        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if (i == j && (dynamic)this[i,j] != 1) return false;
                if (i != j && (dynamic)this[i,j] != 0) return false;
            }
        }
        return true;
    }

    public bool IsOrthogonal(){
        if (NbColumns != NbLines) return false;

        Matrix<T> transposed = this.Transpose();
        Matrix<T> product = this * transposed;

        return product.IsIdentity();
    }

    public bool IsTriangular(){
        return IsUpperTriangular() || IsLowerTriangular();
    }

    public bool IsUpperTriangular(){
        if (NbColumns != NbLines) return false;

        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if (i > j && (dynamic)this[i,j] != 0) return false;
            }
        }
        return true;
    }

    public bool IsLowerTriangular(){
        if (NbColumns != NbLines) return false;

        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if (i < j && (dynamic)this[i,j] != 0) return false;
            }
        }
        return true;
    }

    public bool IsSquare(){
        return NbColumns == NbLines;
    }

    public bool IsSingular(){
        return this.Determinant() == 0;
    }

    public bool IsTridiagonal(){
        if (NbColumns != NbLines) return false;

        for (int i = 0; i < NbLines; i++){
            for (int j = 0; j < NbColumns; j++){
                if (Math.Abs(i-j) > 1 && (dynamic)this[i,j] != 0) return false;
            }
        }
        return true;
    }

    public bool IsDiagonallyDominant(){
        if (NbColumns != NbLines) throw new ArgumentException("Matrix must be square");

        for (int i = 0; i < NbLines; i++){
            double[] _dline = Array.ConvertAll(this[Val.Horizontal, i], n => Convert.ToDouble(n));
            if (_dline.Max<double>() == _dline.Sum() - (dynamic)this[i,i]){
                return false;
            }
        }

        for (int i = 0; i < NbLines; i++){
            if ((dynamic)this[i,i] <= Array.ConvertAll(this[Val.Horizontal, i], n => Convert.ToDouble(n)).Sum() - (dynamic)this[i,i]){
                return false;
            }
        }
        
        return true;
    }
}