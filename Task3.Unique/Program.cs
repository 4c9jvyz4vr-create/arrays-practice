using System;

namespace Task3.Unique
{
    class Program
    {
        /// <summary>
        /// Возвращает массив уникальных элементов из source,
        /// сохраняя порядок первого появления.
        /// Без LINQ и без HashSet — только циклы и вспомогательный массив.
        /// </summary>
        public static int[] GetUnique(int[] source)
        {
            if (source == null || source.Length == 0)
                return new int[0];

            // Вспомогательный массив максимально возможного размера
            int[] buffer = new int[source.Length];
            int count = 0; // сколько уникальных уже нашли

            for (int i = 0; i < source.Length; i++)
            {
                int current = source[i];
                bool alreadySeen = false;

                // Проверяем, встречался ли current ранее среди найденных
                for (int j = 0; j < count; j++)
                {
                    if (buffer[j] == current)
                    {
                        alreadySeen = true;
                        break;
                    }
                }

                if (!alreadySeen)
                {
                    buffer[count] = current;
                    count++;
                }
            }

            // Обрезаем буфер до реального количества уникальных
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
                result[i] = buffer[i];

            return result;
        }

        static void Main(string[] args)
        {
            int[] source = { 1, 2, 2, 3, 4, 4, 4, 5 };

            Console.WriteLine("Исходный:  " + string.Join(", ", source));

            int[] unique = GetUnique(source);

            Console.WriteLine("Уникальные: " + string.Join(", ", unique));

            // Дополнительный ручной ввод для проверки (опционально)
            Console.WriteLine();
            Console.WriteLine("Проверим на своём массиве.");
            int n;
            while (true)
            {
                Console.Write("Введите количество элементов: ");
                try
                {
                    n = int.Parse(Console.ReadLine() ?? "");
                    if (n > 0) break;
                    Console.WriteLine("N должно быть больше 0.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено не целое число.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: число выходит за пределы int.");
                }
            }

            int[] custom = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Элемент [{i}]: ");
                    try
                    {
                        custom[i] = int.Parse(Console.ReadLine() ?? "");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: введено не целое число.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ошибка: число выходит за пределы int.");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Исходный:   " + string.Join(", ", custom));
            Console.WriteLine("Уникальные: " + string.Join(", ", GetUnique(custom)));
        }
    }
}