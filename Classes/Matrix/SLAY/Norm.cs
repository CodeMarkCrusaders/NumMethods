public partial class Matrix<T>{
    private double Norm(double[] x, double[] xPrev){
        double norm = 0;
        for (int i = 0; i < x.Length; i++){
            norm += Math.Pow(x[i] - xPrev[i], 2);
        }
        return Math.Sqrt(norm);
    }
}