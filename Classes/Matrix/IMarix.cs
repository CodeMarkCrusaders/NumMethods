<<<<<<< HEAD
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public interface IMatrix<T> where T: struct {
    public string ToString();


    public Matrix<T> Add(Matrix<T> matrix);
    public Matrix<T> Substract(Matrix<T> matrix);
    public Matrix<T> Multiply(Matrix<T> matrix);
    public Matrix<T> Multiply(T scalar);
    public Matrix<double> Divide<T1>(T1 scalar) where T1: struct;
    public Matrix<T> Transpose();
    public Matrix<T> Invert();
    public double Determinant();
=======
public interface IMatrix<T> where T: struct{
    public Matrix<T> Add(Matrix<T> matrix);
    public Matrix<T> Substract(Matrix<T> matrix);
    public Matrix<T> Multiply(Matrix<T> matrix);
    public Matrix<T> Multiply<P>(P scalar) where P : struct;
    // public void divide(double scalar);
    // public void transpose();
    // public void invert();
    // public void determinant();
>>>>>>> 8b237687868b2fb6c3bbadcf5d7becfa53f127c6
    // public void adjugate();
    // public void cofactor();
    // public void isSymetric();
    // public void isDiagonal();
    // public void isIdentity();
    // public void isOrthogonal();
    // public void isUpperTriangular();
    // public void isLowerTriangular();
    // public void isTriangular();
    // public void isSquare();
    // public void isSingular();
    // public void isRegular();
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