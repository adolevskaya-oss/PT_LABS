using System;

namespace OOP_MATRIX
{
    public class Matrix
    {
        private int rows;
        public int Rows
        {
            get => rows;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество строк должно быть больше 0");
                rows = value;
                ResizeMatrix();
            }
        }

        private int columns;
        public int Columns
        {
            get => columns;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество столбцов должно быть больше 0");
                columns = value;
                ResizeMatrix();
            }
        }

        private double[,] data;

        // Конструктор: создаёт пустую матрицу заданного размера
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Размеры матрицы должны быть больше 0");
            this.rows = rows;
            this.columns = columns;
            this.data = new double[rows, columns];
        }

        // Индексатор для доступа к элементам
        public double this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= rows || col < 0 || col >= columns)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы матрицы");
                return data[row, col];
            }
            set
            {
                if (row < 0 || row >= rows || col < 0 || col >= columns)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы матрицы");
                data[row, col] = value;
            }
        }

        // Метод для заполнения случайными числами
        
        public void FillRandom(double minValue = 0, double maxValue = 10)
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Генерируем целое число от 1 до 10
                    data[i, j] = rand.Next(1, 11); 
                }
            }
        } 


        // Переопределение ToString
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                result += "[ ";
                for (int j = 0; j < columns; j++)
                {
                    result += $"{data[i, j], 8:0} ";
                }
                result += "]\n";
            }
            return result.TrimEnd();
        }

        // Поэлементное сложение
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Матрицы должны иметь одинаковые размеры для поэлементного сложения");
            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        // Поэлементное вычитание
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new ArgumentException("Матрицы должны иметь одинаковые размеры для поэлементного вычитания");
            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            return result;
        }

        // Матричное умножение (A * B, где количество столбцов A == количеству строк B)
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы для матричного умножения");
            Matrix result = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        // Умножение матрицы на число (поэлементно)
        public static Matrix operator *(Matrix m, double scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Columns);
            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Columns; j++)
                    result[i, j] = m[i, j] * scalar;
            return result;
        }

        // Умножение числа на матрицу
        public static Matrix operator *(double scalar, Matrix m)
        {
            return m * scalar;
        }

        // Деление матрицы на число (поэлементно)
        public static Matrix operator /(Matrix m, double scalar)
        {
            if (Math.Abs(scalar) < double.Epsilon)
                throw new DivideByZeroException("Невозможно разделить матрицу на ноль");
            Matrix result = new Matrix(m.Rows, m.Columns);
            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Columns; j++)
                    result[i, j] = m[i, j] / scalar;
            return result;
        }

        // Equals: сравнение по количеству элементов (а не по содержимому!)
        public override bool Equals(object obj)
        {
            if (obj is Matrix other)
            {
                return (this.Rows * this.Columns) == (other.Rows * other.Columns);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Rows * Columns;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (ReferenceEquals(m1, m2)) return true;
            if (m1 is null || m2 is null) return false;
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }

        // Вспомогательный метод для изменения размера матрицы при изменении Rows/Columns
        private void ResizeMatrix()
        {
            if (rows > 0 && columns > 0)
            {
                double[,] newData = new double[rows, columns];
                int minRows = data != null ? Math.Min(rows, data.GetLength(0)) : 0;
                int minCols = data != null ? Math.Min(columns, data.GetLength(1)) : 0;
                for (int i = 0; i < minRows; i++)
                    for (int j = 0; j < minCols; j++)
                        newData[i, j] = data[i, j];
                data = newData;
            }
        }
    }
}