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
            string format; // для красивого вывода
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
            if (upperLimit >= (-lowerLimit) && (int)Math.Log10(upperLimit) + 1 > 2)
                format = "{0," + ((int)Math.Log10(upperLimit) + 3) + "}";
            else if (upperLimit < (-lowerLimit) && (int)Math.Log10(-lowerLimit) + 1 > 2)
                format = "{0," + ((int)Math.Log10(-lowerLimit) + 3) + "}";
            else
                format = "{0,4}";
            Console.WriteLine("\nМатрица:");
            for (int i = 0; i< N; i++) // заполнение и вывод матрицы
            {
                for (int j = 0; j < M; j++)
                {
                    arr[i, j] = rnd.Next(lowerLimit, upperLimit + 1);
                    Console.Write(String.Format(format, arr[i, j]));
                    X[i, j] = arr[i, j];
                }
                Console.WriteLine();
            }
            for (int i = 0; i < N; i++) // поиск количества строк, не содержащих ни одного нулего элемента
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        zeros += 1;
                        break;
                    }
                }
            }
            Console.WriteLine($"\nКоличество строк, не содержащих ни одного нулевого элемента: {N - zeros}");
            flag = false;
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
}
