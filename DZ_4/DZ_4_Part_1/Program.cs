using System;

namespace DZ_4_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int randomInt; // целая часть для генерации случайных вещественных чисел
            double negativeSum = 0; // сумма отрицательных элементов массива
            double multiply = 1; // произведение элементов массива, расположенных между максимальным и минимальным элементами
            double min; // минимальный элемент массива
            double max; // максимальный элемент массива
            int minI = 0; // индекс минимального элемента массива
            int maxI = 0; // инедкс максимального элемента массива
            int arrSize;
            int lowerLimit;
            int upperLimit;
            bool flag;
            do // получение размера массива 
            {
                Console.Write("Введите размер массива: ");
                flag = Int32.TryParse(Console.ReadLine(), out arrSize);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (arrSize <= 0)
                {
                    Console.WriteLine("Ошибка! Введите целое число больше нуля!");
                    flag = false;
                }
            } 
            while (!flag);
            do // получение нижней границы чисел в массиве
            {
                Console.Write("Введите нижнюю границу чисел в массиве: ");
                flag = Int32.TryParse(Console.ReadLine(), out lowerLimit);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (lowerLimit >= 0)
                {
                    Console.WriteLine("Ошибка! В условии задания требуется целое число меньше нуля!");
                    flag = false;
                }
            } while (!flag);
            do // получение верхней границы чисел в массиве
            {
                Console.Write("Введите верхнюю границу чисел в массиве: ");
                flag = Int32.TryParse(Console.ReadLine(), out upperLimit);
                if (!flag)
                    Console.WriteLine("Ошибка! Введите целое число!");
                else if (upperLimit <= 0)
                {
                    Console.WriteLine("Ошибка! В условии задания требуется целое число больше нуля!");
                    flag = false;
                }
            } while (!flag);
            double[] arr = new double[arrSize];
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < arr.Length; i++)
            {
                randomInt = rnd.Next(lowerLimit, upperLimit + 1);
                if (randomInt < 0)
                    arr[i] = randomInt + Math.Round(rnd.NextDouble(), 2);
                else
                    arr[i] = randomInt - Math.Round(rnd.NextDouble(), 2);
                Console.Write($"{arr[i]:0.00}" + " ");
            }
            Console.WriteLine("");
            max = lowerLimit;
            min = upperLimit;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    negativeSum += arr[i];
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxI = i;
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                    minI = i;
                }
            }
            Console.WriteLine($"\nСумма отрицательных элементов массива: {negativeSum:0.##}");
            if (minI + 1 == maxI || minI - 1 == maxI)
                Console.WriteLine("\nМинимальный и максимальный элемент - соседние.\n" +
                    "Hевозможно вывести произведение элементов массива,\n" +
                    "расположенных между максимальным и минимальным элементами.\n");
            else if (minI + 2 == maxI || minI - 2 == maxI)
                Console.WriteLine($"\nМинимальный и максимальный элемент находятся слева и справа от элемента {arr[(maxI + minI)/2]}.\n" +
                    "Невозможно вывести произведение элементов массива,\n" +
                    "расположенных между максимальным и минимальным элементами.\n");
            else
            {
                if (maxI > minI)
                {
                    for (int i = minI + 1; i < maxI; i++)
                        multiply *= arr[i];
                }
                else
                {
                    for (int i = maxI + 1; i < minI; i++)
                        multiply *= arr[i];
                }
                Console.WriteLine($"Произведение элементов массива,\n" +
                    $"расположенных между максимальным и минимальным элементами: {multiply:0.##}\n");
            }
            Array.Sort(arr);
            Console.WriteLine("Отсортированный по возрастанию массив: ");
            foreach (var i in arr)
                Console.Write($"{i:0.00} ");
            Console.WriteLine("");
        }
    }
}
