using System;

namespace DZ_4_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int N; // столбцы матрицы
            int M; // строки матрицы
            int lowerLimit;
            int upperLimit;
            bool flag;
            int zeros = 0; // количество строк, содержащих нулевые элементы
            int max; // максимальное число в матрице
            int count; // сколько раз максимальное число встречается в матрице
            int r = 0; // количество повторений (для цикла while)
            do // строки матрицы
            {
                Console.Write("Введите количество строк матрицы: ");
                flag = Int32.TryParse(Console.ReadLine(), out N);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (N <= 0)
                {
                    Console.WriteLine("Ошибка! Введите целое число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            do // столбцы матрицы
            {
                Console.Write("Введите количество столбцов матрицы: ");
                flag = Int32.TryParse(Console.ReadLine(), out M);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (M <= 0)
                {
                    Console.WriteLine("Ошибка! Введите целое число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            do // получение нижней границы чисел в матрице
            {
                Console.Write("Введите нижнюю границу чисел в массиве: ");
                flag = Int32.TryParse(Console.ReadLine(), out lowerLimit);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (lowerLimit >= 1)
                {
                    Console.WriteLine("Ошибка! В условии задания требуется целое число меньше единицы!");
                    flag = false;
                }
            } while (!flag);
            do // получение верхней границы чисел в матрице
            {
                Console.Write("Введите верхнюю границу чисел в массиве: ");
                flag = Int32.TryParse(Console.ReadLine(), out upperLimit);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (upperLimit <= lowerLimit)
                {
                    Console.WriteLine("Ошибка! В условии задания требуется целое число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            int[,] arr = new int[N, M];
            int[,] X = new int[N, M];
            arr = MatrixGeneration(arr, N, M, lowerLimit, upperLimit);
            Console.WriteLine("\nМатрица:");
            PrintMatrix(arr, N, M, lowerLimit, upperLimit);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    X[i, j] = arr[i, j];
            for (int i = 0; i < N; i++) // поиск количества строк, не содержащих ни одного нулего элемента
                for (int j = 0; j < M; j++)
                    if (arr[i, j] == 0)
                    {
                        zeros += 1;
                        break;
                    }
            Console.WriteLine($"\nКоличество строк, не содержащих ни одного нулевого элемента: {N - zeros}");
            flag = false;
            if (N == 1 && M == 1)
                Console.WriteLine("\nВсе числа в матрице - разные.");
            else if (N == 2 && M == 1)
            {
                if (arr[0, 0] == arr[1, 0])
                    Console.WriteLine($"\nМаксимальное из чисел, встречающихся в заданной матрице более одного раза: {arr[1, 1]}");
                else
                    Console.WriteLine("\nВсе числа в матрице - разные.");
            }
            else
            {
                do
                {
                    r++;
                    max = X[0, 0];
                    count = 0;
                    for (int i = 0; i < N; i++) // поиск максимального элемента
                        for (int j = 0; j < M; j++)
                            if (X[i, j] > max)
                                max = X[i, j];
                    for (int i = 0; i < N; i++) // количество элементов 
                        for (int j = 0; j < M; j++)
                            if (X[i, j] == max)
                                count += 1;
                    if (count > 1) // если максимальный элемент встречается больше одного раза то конец цикла while 
                    {
                        flag = true;
                    }
                    else // иначе максимальное значение не подходит, 
                    {
                        for (int i = 0; i < N; i++) // количество элементов 
                            for (int j = 0; j < M; j++)
                                if (X[i, j] == max)
                                    X[i, j] = int.MinValue;
                    }
                } while (!flag || r != N * M);
                if (r == N * M && !flag)
                    Console.WriteLine("\nВсе числа в матрице - разные.");
                else
                    Console.WriteLine($"\nМаксимальное из чисел, встречающихся в заданной матрице более одного раза: {max}");
            }
        }
        static int[,] MatrixGeneration(int[,] arr, int N, int M, int lowerLimit, int upperLimit)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    arr[i, j] = rnd.Next(lowerLimit, upperLimit + 1);
            return arr;
        }
        static void PrintMatrix(int[,] arr, int N, int M, int lowerLimit, int upperLimit)
        {
            string format;
            if (upperLimit >= (-lowerLimit) && (int)Math.Log10(upperLimit) + 1 > 2)
                format = "{0," + ((int)Math.Log10(upperLimit) + 3) + "}";
            else if (upperLimit < (-lowerLimit) && (int)Math.Log10(-lowerLimit) + 1 > 2)
                format = "{0," + ((int)Math.Log10(-lowerLimit) + 3) + "}";
            else
                format = "{0,4}";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write(String.Format(format, arr[i, j]));
                Console.WriteLine();
            }
        }
    }
}
