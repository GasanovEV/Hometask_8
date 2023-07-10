int size = GetNumberFromUser("Размер массива: ", "Ошибка ввода");
int[,] array = GenerateSpiralArray(size);

Console.WriteLine("Спиральный массив:");
PrintArray(array);

int[,] GenerateSpiralArray(int size)
{
    int[,] array = new int[size, size];
    int num = 1;
    int rowStart = 0;
    int rowEnd = size - 1;
    int colStart = 0;
    int colEnd = size - 1;

    while (num <= size * size)
    {
        // Заполняем верхнюю горизонтальную строку
        for (int i = colStart; i <= colEnd; i++)
        {
            array[rowStart, i] = num++;
        }
        rowStart++;

        // Заполняем правую вертикальную строку
        for (int i = rowStart; i <= rowEnd; i++)
        {
            array[i, colEnd] = num++;
        }
        colEnd--;

        // Заполняем нижнюю горизонтальную строку в обратном порядке
        for (int i = colEnd; i >= colStart; i--)
        {
            array[rowEnd, i] = num++;
        }
        rowEnd--;

        // Заполняем левую вертикальную строку в обратном порядке
        for (int i = rowEnd; i >= rowStart; i--)
        {
            array[i, colStart] = num++;
        }
        colStart++;
    }

    return array;
}

void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"{array[i, j]:D2} ");
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
