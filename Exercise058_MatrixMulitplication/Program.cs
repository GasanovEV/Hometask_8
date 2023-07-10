int rows1 = GetNumberFromUser("Введите количество строк 1 матрицы: ", "Ошибка ввода");
int columns1 = GetNumberFromUser("Введите количество столбцов 1 матрицы: ", "Ошибка ввода");

int rows2 = GetNumberFromUser("Введите количество строк 2 матрицы: ", "Ошибка ввода");
int columns2 = GetNumberFromUser("Введите количество столбцов 2 матрицы: ", "Ошибка ввода");

int[,] matrix1 = GetArray(rows1, columns1);
int[,] matrix2 = GetArray(rows2, columns2);

Console.WriteLine("Первая матрица:");
PrintMatrix(matrix1);
Console.WriteLine("Вторая матрица:");
PrintMatrix(matrix2);

int[,] result = MultiplyMatrices(matrix1, matrix2);

Console.WriteLine("Результат произведения матриц:");
PrintMatrix(result);

int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
{
    int rows1 = matrix1.GetLength(0);
    int cols1 = matrix1.GetLength(1);
    int rows2 = matrix2.GetLength(0);
    int cols2 = matrix2.GetLength(1);

    if (cols1 != rows2)
    {
        throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы.");
    }

    int[,] result = new int[rows1, cols2];

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            int sum = 0;
            for (int k = 0; k < cols1; k++)
            {
                sum += matrix1[i, k] * matrix2[k, j];
            }
            result[i, j] = sum;
        }
    }

    return result;
}

void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userNumber))
            return userNumber;

        Console.WriteLine(errorMessage);
    }
}
int[,] GetArray (int m, int n)
{
    int[,] result = new int [m,n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i,j] = new Random().Next(1, 100);
        }
    }
    return result;
}

