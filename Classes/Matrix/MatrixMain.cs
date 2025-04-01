
// Определение класса Matrix
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
public enum Val: int{
    Diagonal,
    Horizontal,
    Vertical,
}
public partial class Matrix<T> : IMatrix<T>/*, IEquatable<T>, IComparable<T>, IFormattable*/ {

    private T[,] _matrix;
    public double Accuracy { get; init; }
    public uint NbLines { get; init; }
    public uint NbColumns { get; init; }

    public Matrix(uint nbLines, uint nbColumns, double accuracy = 1e-4){
        _matrix = new T[nbLines, nbColumns];
        NbLines = nbLines;
        NbColumns = nbColumns;
        Accuracy = accuracy;
    }
    public Matrix(List<List<T>> matrix, double accuracy = 1e-4){
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
        Accuracy = accuracy;
    }
    public Matrix(T[,] matrix, double accuracy = 1e-4){
        _matrix = (T[,])matrix.Clone();
        NbLines = (uint)matrix.GetLength(0);
        NbColumns = (uint)matrix.GetLength(1);
        Accuracy = accuracy;
    }

    public T this[int row, int col]  // Индексатор для двумерного массива
    {
        get => _matrix[row, col];
        private set => _matrix[row, col] = value;
    }

    public T[] this[Val key, int number]  // Индексатор для двумерного массива
    {
        get => SmartGet(key, number);
        set => SmartSet(key, number, value);
    }

    private T[] SmartGet(Val key, int number){
        switch (key){
            case Val.Diagonal:
                if ((number <= 0) ? 0 >= NbLines - Math.Abs(number): 0 >= NbColumns - Math.Abs(number))
                    throw new ArgumentException("Выход за пределы матрицы");
                
                T[] diagonal = new T[(number <= 0) ? NbLines - Math.Abs(number): NbColumns - Math.Abs(number)];
                for (int i = 0; i < diagonal.Length; i++)
                {
                    int rowIndex = (number <= 0) ? (i + Math.Abs(number)) : i;
                    int colIndex = (number <= 0) ? i : (i + Math.Abs(number));
                    diagonal[i] = _matrix[rowIndex, colIndex];
                }
                return diagonal;
                
            case Val.Horizontal:
                if (number >= NbLines){
                    throw new ArgumentException("Number must be less than the number of lines");
                }
                T[] lineH = new T[NbColumns];
                for (int i=0; i < NbColumns; i++){
                    lineH[i] = _matrix[number,i];
                }
                return lineH;

            case Val.Vertical:
                if (number >= NbColumns){
                    throw new ArgumentException("Number must be less than the number of columns");
                }
                T[] lineV = new T[NbLines];
                for (int i=0; i < NbLines; i++){
                    lineV[i] = _matrix[i,number];
                }
                return lineV;

            default:
                throw new ArgumentException("Invalid key");
        }
    }
    private Matrix<T> SmartSet(Val key, int number, T[] value){
        switch (key){
            case Val.Diagonal:
                if ((number <= 0) ? 0 >= NbLines - Math.Abs(number): 0 >= NbColumns - Math.Abs(number))
                    if (value.Length != ((number <= 0) ? NbLines - Math.Abs(number): NbColumns - Math.Abs(number)))
                        throw new ArgumentException("Number must be within the bounds of the matrix dimensions");
                
                for (int i = 0; i < value.Length; i++)
                {
                    int rowIndex = (number <= 0) ? (i + Math.Abs(number)) : i;
                    int colIndex = (number <= 0) ? i : (i + Math.Abs(number));
                    _matrix[rowIndex, colIndex] = value[i];
                }
                return this;

            case Val.Horizontal:
                if (number >= NbLines || value.Length != NbColumns){
                    throw new ArgumentException("Number must be less than the number of lines");
                }
                for (int i=0; i < NbColumns; i++){
                    _matrix[number,i] = value[i];
                }
                return this;

            case Val.Vertical:
                if (number >= NbColumns || value.Length != NbLines){
                    throw new ArgumentException("Number must be less than the number of columns");
                }
                for (int i=0; i < NbLines; i++){
                    _matrix[i,number] = value[i];
                }
                return this;
            default:
                throw new ArgumentException("Invalid key");
        }
    }
}