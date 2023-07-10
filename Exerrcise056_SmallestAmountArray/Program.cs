Console.Clear();

int rows = GetNumberFromUser("Введите количество строк массива: ", "Ошибка ввода");
int columns = GetNumberFromUser("Введите количество столбцов массива: ", "Ошибка ввода");

int[,] array = GetArray(rows, columns);
PrintArray(array);
Console.WriteLine();
FindSmallestRow(array);


void FindSmallestRow(int[,] array)
{
    int minIndex = 0;
    int minValue = GetRowSum(array, 0);

    for (int i = 1; i < array.GetLength(0); i++)
    {
        int rowSum = GetRowSum(array, i);
        if (rowSum < minValue)
        {
            minValue = rowSum;
            minIndex = i;
        }
    }

    Console.WriteLine("Строка с наименьшей суммой элементов: " + (minIndex + 1));
}

int GetRowSum(int[,] array, int rowIndex)
{
    int sum = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        sum += array[rowIndex, j];
    }
    return sum;
}


int[,] GetArray(int m, int n)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(1, 20);
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