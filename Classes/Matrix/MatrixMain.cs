
// Определение класса Matrix

using System.Collections.Generic;
public partial class Matrix<T> : IMatrix<T> where T: struct{

    private T[,] _matrix;
    public uint NbLines { get; init; }
    public uint NbColumns { get; init; }

    public Matrix(uint nbLines, uint nbColumns){
        _matrix = new T[nbLines, nbColumns];
        NbLines = nbLines;
        NbColumns = nbColumns;
    }
    public Matrix(List<List<T>> matrix){
        _matrix = new T[matrix.Count, matrix[0].Count];
        for (int i=0; i < matrix.Count; i++){
            if (matrix[i].Count != matrix[0].Count){
                throw new ArgumentException("All lines must have the same number of columns");
            }
            for (int j=0; j < matrix[i].Count; j++){
                _matrix[i,j] = matrix[i][j];
            }
        }

        NbLines = (uint)matrix.Count;
        NbColumns = (uint)matrix[0].Count;
    }
    public Matrix(T[,] matrix){
        _matrix = (T[,])matrix.Clone();
        NbLines = (uint)matrix.GetLength(0);
        NbColumns = (uint)matrix.GetLength(1);
    }

    public T this[int row, int col]  // Индексатор для двумерного массива
    {
        get => _matrix[row, col];
        private set => _matrix[row, col] = value;
    }
}