public partial class Matrix<T>{
    static public double SimpleIterationMethod(Func<double, double> f, double x0 = 0, double eps = 1e-9, int maxIterations = 1000){
        double x = x0;
        double delta = 1e-6;
        for (int i = 0; i < maxIterations; i++){
            double xNew = x-f(x)/Derivative(f,x,delta);
            if (Math.Abs(xNew - x) < eps)
                return xNew;
            x = xNew;
        }
        throw new Exception("Достигнуто максимальное число итераций, решение не найдено.");
    }
}