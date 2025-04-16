public partial class Matrix<T>{
    public double[] Gauss(T[] X){
        if (!this.IsSquare()) throw new ArgumentException("Матрица должна быть квадратной");
        int n = X.Length; 
        // Инициализация рабочих копий: a для коэффициентов и b для правой части.
        double[,] a = new double[n, n];
        double[] b = new double[n];

        for (int i = 0; i < n; i++)
        {
            b[i] = Convert.ToDouble(X[i]);
            for (int j = 0; j < n; j++)
            {
                a[i, j] = Convert.ToDouble(this[i, j]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            // Поиск опорного элемента. Если нулевой, поменять со строкой ниже, где в текущем столбце стоит ненулевое значение.
            int pivotRow = i;
            while (pivotRow < n && Math.Abs(a[pivotRow, i]) < Accuracy)
                pivotRow++;
            if (pivotRow == n)
                throw new InvalidOperationException("Система не имеет единственного решения.");

            if (pivotRow != i)
            {
                for (int j = 0; j < n; j++)
                {
                    double temp = a[i, j];
                    a[i, j] = a[pivotRow, j];
                    a[pivotRow, j] = temp;
                }
                double tempB = b[i];
                b[i] = b[pivotRow];
                b[pivotRow] = tempB;
            }

            // Нормализация строки с опорным элементом.
            double pivot = a[i, i];
            for (int j = 0; j < n; j++)
                a[i, j] /= pivot;
            b[i] /= pivot;

            // Обнуление элемента i в остальных строках.
            for (int r = 0; r < n; r++)
            {
                if (r == i)
                    continue;
                double factor = a[r, i];
                for (int j = 0; j < n; j++)
                    a[r, j] -= factor * a[i, j];
                b[r] -= factor * b[i];
            }
        }

        return b;
    }
}