using System;

namespace Task1.Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 10;
            const int minValue = 1;
            const int maxValue = 100;

            var random = new Random();
            var numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(minValue, maxValue + 1); // +1, чтобы 100 входило в диапазон
            }

            Console.WriteLine($"Массив: {string.Join(", ", numbers)}");

            // Сумма
            long sum = 0;
            foreach (var n in numbers) sum += n;

            // Произведение (может быть большим — используем long)
            long product = 1;
            foreach (var n in numbers) product *= n;

            // Количество чётных
            int evenCount = 0;
            foreach (var n in numbers)
                if (n % 2 == 0) evenCount++;

            // Среднее арифметическое
            double average = (double)sum / size;

            // Количество чисел, больших среднего
            int aboveAverage = 0;
            foreach (var n in numbers)
                if (n > average) aboveAverage++;

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Чётных чисел: {evenCount}");
            Console.WriteLine($"Больше среднего ({average:F1}): {aboveAverage}");
        }
    }
}
