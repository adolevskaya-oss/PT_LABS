using OOP_MATRIX;

// Создание двух матриц с помощью конструктора и заполнение случайными числами
Matrix m1 = new Matrix(2, 3);
m1.FillRandom(1, 10); // случайные числа от 1 до 10

Matrix m2 = new Matrix(2, 3);
m2.FillRandom(1, 10);


// Вывод матриц (проверка ToString)
Console.WriteLine("Матрица m1:");
Console.WriteLine(m1);
Console.WriteLine();

Console.WriteLine("Матрица m2:");
Console.WriteLine(m2);
Console.WriteLine();

// Поэлементное сложение 
Matrix sum = m1 + m2;
Console.WriteLine("Поэлементное сложение (m1 + m2):");
Console.WriteLine(sum);
Console.WriteLine();

// Поэлементное вычитание 
Matrix diff = m1 - m2;
Console.WriteLine("Поэлементное вычитание (m1 - m2):");
Console.WriteLine(diff);
Console.WriteLine();

// Умножение матрицы на число 
Matrix scaled = m1 * 2.0;
Console.WriteLine("Умножение матрицы на число (m1 * 2):");
Console.WriteLine(scaled);
Console.WriteLine();

// Деление матрицы на число 
Matrix divided = m1 / 2.0;
Console.WriteLine("Деление матрицы на число (m1 / 2):");
Console.WriteLine(divided);
Console.WriteLine();

// Создаём совместимые матрицы: mA (2x3), mB (3x2)
Matrix mA = new Matrix(2, 3);
mA.FillRandom(1, 5);

Matrix mB = new Matrix(3, 2);
mB.FillRandom(1, 5);

Console.WriteLine("Матрица A (2x3):");
Console.WriteLine(mA);
Console.WriteLine();

Console.WriteLine("Матрица B (3x2):");
Console.WriteLine(mB);
Console.WriteLine();

Matrix product = mA * mB; // матричное умножение 
Console.WriteLine("Матричное умножение (A * B):");
Console.WriteLine(product);
Console.WriteLine();

Matrix mC = new Matrix(2, 4); // 8 элементов
mC.FillRandom();
Matrix mD = new Matrix(4, 2); // 8 элементов
mD.FillRandom();
Matrix mE = new Matrix(3, 3); // 9 элементов
mE.FillRandom();

Console.WriteLine($"mC (2x4) и mD (4x2) имеют одинаковое число элементов? {mC.Equals(mD)}"); // True
Console.WriteLine($"mC (2x4) и mE (3x3) имеют одинаковое число элементов? {mC.Equals(mE)}"); // False


Console.WriteLine(mC == mD);
Console.WriteLine();


try
{
    // Сложение матриц разных размеров
    Matrix bad = m1 + new Matrix(1, 1);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка при сложении: {ex.Message}");
}

try
{
    // Деление на ноль
    Matrix bad = m1 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка при делении: {ex.Message}");
}

try
{
    // Матричное умножение несовместимых матриц (2x3 * 2x3)
    Matrix bad = m1 * m2;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка при матричном умножении: {ex.Message}");
}