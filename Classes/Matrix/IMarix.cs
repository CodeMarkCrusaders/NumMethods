using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Интерфейс для работы с матрицами.
/// </summary>
/// <typeparam name="T">Тип элементов матрицы.</typeparam>
public interface IMatrix<T> where T : struct
{
    /// <summary>
    /// Преобразует матрицу в строку.
    /// </summary>
    /// <returns>Строковое представление матрицы.</returns>
    public string ToString();

    /// <summary>
    /// Складывает текущую матрицу с другой матрицей.
    /// </summary>
    /// <param name="matrix">Матрица для сложения.</param>
    /// <returns>Результат сложения матриц.</returns>
    public Matrix<T> Add(Matrix<T> matrix);

    /// <summary>
    /// Вычитает из текущей матрицы другую матрицу.
    /// </summary>
    /// <param name="matrix">Матрица для вычитания.</param>
    /// <returns>Результат вычитания матриц.</returns>
    public Matrix<T> Substract(Matrix<T> matrix);

    /// <summary>
    /// Умножает текущую матрицу на другую матрицу.
    /// </summary>
    /// <param name="matrix">Матрица для умножения.</param>
    /// <returns>Результат умножения матриц.</returns>
    public Matrix<T> Multiply(Matrix<T> matrix);

    /// <summary>
    /// Умножает текущую матрицу на скаляр.
    /// </summary>
    /// <param name="scalar">Скаляр для умножения.</param>
    /// <returns>Результат умножения матрицы на скаляр.</returns>
    public Matrix<T> Multiply(T scalar);

    /// <summary>
    /// Делит текущую матрицу на скаляр.
    /// </summary>
    /// <typeparam name="T1">Тип скаляра.</typeparam>
    /// <param name="scalar">Скаляр для деления.</param>
    /// <returns>Результат деления матрицы на скаляр.</returns>
    public Matrix<double> Divide<T1>(T1 scalar) where T1 : struct;

    /// <summary>
    /// Транспонирует текущую матрицу.
    /// </summary>
    /// <returns>Транспонированная матрица.</returns>
    public Matrix<T> Transpose();

    /// <summary>
    /// Инвертирует текущую матрицу.
    /// </summary>
    /// <returns>Инвертированная матрица.</returns>
    public Matrix<T> Invert();

    /// <summary>
    /// Вычисляет определитель текущей матрицы.
    /// </summary>
    /// <returns>Определитель матрицы.</returns>
    public double Determinant();
    
    // /// <summary>
    // /// Приводит матрицу к присоединенной.
    // /// </summary>
    // public void adjugate();

    // /// <summary>
    // /// Вычисляет кофактор матрицы.
    // /// </summary>
    // public void cofactor();

    /// <summary>
    /// Проверяет, является ли матрица симметричной.
    /// </summary>
    public bool IsSymetric(Val key);

    /// <summary>
    /// Проверяет, является ли матрица диагональной.
    /// </summary>
    public bool IsDiagonal();

    /// <summary>
    /// Проверяет, является ли матрица единичной.
    /// </summary>
    public bool IsIdentity();

    /// <summary>
    /// Проверяет, является ли матрица ортогональной.
    /// </summary>
    public bool IsOrthogonal();

    /// <summary>
    /// Проверяет, является ли матрица верхнетреугольной.
    /// </summary>
    public bool IsUpperTriangular();

    /// <summary>
    /// Проверяет, является ли матрица нижнетреугольной.
    /// </summary>
    public bool IsLowerTriangular();

    /// <summary>
    /// Проверяет, является ли матрица треугольной.
    /// </summary>
    public bool IsTriangular();

    /// <summary>
    /// Проверяет, является ли матрица квадратной.
    /// </summary>
    public bool IsSquare();

    /// <summary>
    /// Проверяет, является ли матрица вырожденной.
    /// </summary>
    public bool IsSingular();

    /// <summary>
    /// Проверяет, является ли матрица трехдиагональной.
    /// </summary>
    public bool IsTridiagonal();

    public bool IsDiagonallyDominant();


    // public void isPositiveDefinite();
    // public void isPositiveSemiDefinite();
    // public void isNegativeDefinite();
    // public void isNegativeSemiDefinite();
    // public void isIndefinite();
    // public void isOrthogonal();
    // public void isOrthonormal();
    // public void isNormal();
    // public void isHermitian();
    // public void isUnitary();
    // public void isSkewHermitian();
    // public void isSkewSymetric();
    // public void isSymetric();
    // public void isSymetricPositiveDefinite();
    // public void isSymetricPositiveSemiDefinite();
    // public void isSymetricNegativeDefinite();
    // public void isSymetricNegativeSemiDefinite();
    // public void isSymetricIndefinite();
    // public void isSymetricOrthogonal();
    // public void isSymetricOrthonormal();
    // public void isSymetricNormal();
    // public void isSymetricHermitian();
    // public void isSymetricUnitary();
    // public void isSymetricSkewHermitian();
    // public void isSymetricSkewSymetric();
    // public void isSymetricPositiveDefinite();
    // public void isSymetricPositiveSemiDefinite();
    // public void isSymetricNegativeDefinite();
    // public void isSymetricNegativeSemiDefinite();
    // public void isSymetricIndefinite();
    // public void isSymetricOrthogonal();
    // public void isSymetricOrthonormal();
    // public void isSymetricNormal();
    // public void isSymetricHermitian();
    // public void isSymetricUnitary();
    // public void isSymetricSkewHermitian();
    // public void isSymetricSkewSymetric();
    // public void isSkewSymetric();
    // public void isSkewSymetricPositiveDefinite();
}