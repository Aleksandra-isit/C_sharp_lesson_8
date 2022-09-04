/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.*/

void NewTask()
{
    Console.Write("Для перехода к следующей задаче нажмите любую клавишу...");
    Console.ReadKey();
    Console.Clear();
}

Console.Clear();

int[,] CreateArray()
{
    int m, n, i, j;
    Console.Write("Введите количество строк: ");
    m = int.Parse(Console.ReadLine());
    Console.Write("Введите количество столбцов: ");
    n = int.Parse(Console.ReadLine());

    int[,] array = new int[m, n];
    for (i = 0; i < m; i++)
    {
        for (j = 0; j < n; j++)
        {
            array[i,j] =  new Random().Next(-100, 100)/10;
        }
    }
    return array;
}

void OutputArray(int[,] array)
{
    int i, j, m, n;
    m = array.GetLength(0);
    n = array.GetLength(1);
    Console.WriteLine("Исходная матрица:");
    for (i = 0; i < m; i++)
    {
        for (j = 0; j < n; j++)
        {
            Console.Write($"{array[i,j]}\t");
        }
        Console.WriteLine();
    }
}

void SortArray(int[,] array)
{
    int i, j, m, n, c;
    m = array.GetLength(0);
    n = array.GetLength(1);
    for (i = 0; i < m; i++)
    {
        for (j = 0; j < n; j++)
        {
            for (c = 0; c < n-1; c++)
            {
                if (array[i,c] < array[i, c+1])
                {
                    int tmp = array[i, c];
                    array[i, c] = array[i, c+1];
                    array[i, c+1] = tmp;
                }
            }
        }
    }
    OutputArray(array);
}

int[,] array = CreateArray();
OutputArray(array);
SortArray(array);
NewTask();

/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/

void MinRow(int[,] array)
{
    int i, j, m, n, sum, min_sum = 9999999, num_row = 0;
    m = array.GetLength(0);
    n = array.GetLength(1); 
    for (i = 0; i < m; i++)
    {
        sum = 0;
        for (j = 0; j < n; j++)
        {
            sum += array[i,j];
        }
        if (sum < min_sum)
        {
            min_sum = sum;
            num_row = i + 1;
        }
    }
    Console.WriteLine($"В строке номер {num_row} наименьшая сумма элементов = {min_sum}");
}

int[,] task_2 = CreateArray();
OutputArray(task_2);
MinRow(task_2);
NewTask();

/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
*/

bool check(int[,] A, int[,] B, int m1, int n1, int m2, int n2)
{
    if (n1 != m2)
    {
        Console.WriteLine("Невозможно перемножить данные матрицы");
        return false;
    }
    return true;
}

int[,] Multiplication(int[,] A, int[,] B)
{
    int m1, n1, m2, n2, i, j, k;
    m1 = A.GetLength(0);
    n1 = A.GetLength(1);
    m2 = B.GetLength(0);
    n2 = B.GetLength(1);
    while (check(A, B, m1, n1, m2, n2) == false)
    {
        Console.Clear();
        Console.WriteLine("Некорректно заданы матрицы!");
        Console.WriteLine("matrix A:");
        A = CreateArray(); m1 = A.GetLength(0); n1 = A.GetLength(1);
        OutputArray(A);
        Console.WriteLine("Matrix B:");
        B = CreateArray(); m2 = B.GetLength(0); n2 = B.GetLength(1);
        OutputArray(B);
    }
    int [,] resultMatrix = new int[m1, n2];
    for (i = 0; i < m1; i++)
    {
        for (j = 0; j < n2; j++)
        {
            int sum = 0;
            for (k = 0; k < n1; k++)
            {
                sum += A[i, k] * B[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }
    Console.WriteLine("\nРезультирующая матрица:");
    OutputArray(resultMatrix);
    return resultMatrix;
}

int[,] A, B;
Console.WriteLine("Matrix A:");
A = CreateArray(); 
OutputArray(A);

Console.WriteLine("Matrix B:");
B = CreateArray(); 
OutputArray(B);
Multiplication(A, B);
NewTask();

/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2*/


void CreateTA(int[,,] task_4)
{
    int i, j, num, k;
    int[] array = new int[task_4.GetLength(0) * task_4.GetLength(1) * task_4.GetLength(2)];
    for (i = 0; i < array.GetLength(0); i++)
    {
        array[i] = new Random().Next(10, 100);
        num = array[i];
        if (i >= 1)
        {
            for (j = 0; j < i; j++)
            {
                while (array[i] == array[j])
                {
                    array[i] = new Random().Next(10, 100);
                    j = 0;
                    num = array[i];
                }
                num = array[i];
            }
        }
    }
    k = 0;
    for (int x = 0; x < task_4.GetLength(0); x++)
    {
        for (int y = 0; y < task_4.GetLength(1); y++)
        {
            for (int z = 0; z < task_4.GetLength(2); z++)
            {
                task_4[x, y, z] = array[k];
                k++;
            }
        }
   }
}

void WriteTA(int[,,] task_4)
{
    for (int i = 0; i < task_4.GetLength(0); i++)
    {
        for ( int j = 0; j < task_4.GetLength(1); j++)
        {
            for (int k = 0; k < task_4.GetLength(2); k++)
            {
                Console.Write( $"{task_4[i,j,k]}({i}{j}{k})\t");
            }
            Console.WriteLine();
        }
    }
}

int[,,] task_4 = new int[2,2,2];
CreateTA(task_4);
WriteTA(task_4);
NewTask();

/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
*/

void SpiralFilledArray(int[,] task_5)
{
    int i = 0, j = 0, m, n, value = 1;
    m = task_5.GetLength(0); n = task_5.GetLength(1);
    int iStart = 0, iFinish = 0, jStart = 0, jFinish = 0;

    while (value <= m*n)
    {
        task_5[i,j] = value;
        if (i == iStart && j < m - jFinish - 1) ++j;
        else if (j == m - jFinish - 1 && i < n - iFinish -1) ++i;
        else if ( i == n - iFinish - 1 && j > jStart) --j;
        else --i;

        if ((i == iStart + 1) && (j == jStart) && (jStart != m - jFinish - 1))
        {
            ++iStart; ++iFinish; ++jStart; ++jFinish;
        }
        ++value;
    }

    for (i = 0; i < m; i++)
    {
        for (j = 0; j < n; j++)
        {
            string res = string.Format("{0:d2}", task_5[i,j]);
            Console.Write($"{res} ");
        }
        Console.WriteLine();
    }
}

int[,] task_5 = new int[4,4];
SpiralFilledArray(task_5);