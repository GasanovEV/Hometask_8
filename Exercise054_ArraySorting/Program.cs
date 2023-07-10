Console.Clear();

int rows = GetNumberFromUser("Введите количество строк массива: ", "Ошибка ввода");
int columns = GetNumberFromUser("Введите количество столбцов массива: ", "Ошибка ввода");

int[,] array = GetArray(rows, columns);
PrintArray(array);
Console.WriteLine();
SortArray(array);

Console.WriteLine($"Отсортированный массив  ->");
PrintArray(array);

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

void PrintArray(int[,] array)
{
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
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

void SortArray(int[,] array)
{
    int n = array.GetLength(0);
    int m = array.GetLength(1);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m - 1; j++)
        {
            for (int k = 0; k < m - j - 1; k++)
            {
                if (array[i, k] > array[i, k + 1])
                {
                    // Перестановка элементов, если текущий больше следующего
                    int temp = array[i, k];
                    array[i, k] = array[i, k + 1];
                    array[i, k + 1] = temp;
                }
            }
        }
    }
}