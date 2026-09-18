using System;

namespace Task2.InputSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Запрос количества элементов с проверкой N > 0
            int n;
            while (true)
            {
                Console.Write("Введите количество элементов: ");
                try
                {
                    n = int.Parse(Console.ReadLine() ?? "");
                    if (n > 0)
                        break;
                    Console.WriteLine("Количество элементов должно быть больше 0. Попробуйте снова.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено не целое число. Попробуйте снова.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: число выходит за пределы допустимого диапазона. Попробуйте снова.");
                }
            }

            // 2. Заполнение массива с клавиатуры
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Элемент [{i}]: ");
                    try
                    {
                        array[i] = int.Parse(Console.ReadLine() ?? "");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: введено не целое число. Попробуйте снова.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ошибка: число выходит за пределы допустимого диапазона. Попробуйте снова.");
                    }
                }
            }

            Console.WriteLine();

            // 3. Вывод в прямом порядке
            Console.WriteLine("Исходный массив:  " + string.Join(", ", array));

            // 4. Вывод в обратном порядке
            Console.Write("Обратный порядок: ");
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i]);
                if (i > 0)
                    Console.Write(", ");
            }
            Console.WriteLine();

            // 5. Сортировка по возрастанию
            int[] sorted = (int[])array.Clone();
            Array.Sort(sorted);
            Console.WriteLine("Отсортированный:  " + string.Join(", ", sorted));

            // 6. Поиск максимума и минимума без LINQ
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
                if (array[i] < min) min = array[i];
            }

            Console.WriteLine($"Максимум: {max}");
            Console.WriteLine($"Минимум: {min}");
        }
    }
}