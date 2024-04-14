using System;
using System.Collections.Generic;
using System.Numerics;

class GFG
{
    // Функция для вычисления НОДа двух чисел
    static BigInteger gcd(BigInteger num1, BigInteger num2)
    {
        BigInteger a = BigInteger.Abs(num1);
        BigInteger b = BigInteger.Abs(num2);
        while ((a != 0) && (b != 0) && (a != b))
        {
            if (a > b)
            {
                a -= b;
            }
            else
            {
                b -= a;
            }
        }
        return BigInteger.Max(a, b);
    }
    public static BigInteger NewtonSqrt(BigInteger n)
    {
        if (n <= 0) return 0;

        BigInteger x = n;
        BigInteger prevX = BigInteger.Zero;

        while (true)
        {
            prevX = x;
            x = (x + n / x) / 2;

            if (x >= prevX)
                break;
        }

        return x;
    }
    // Функция для факторизации числа по алгоритму Диксона
    static (BigInteger, BigInteger) factor(BigInteger n)
    {
        // Факторная база для заданного числа
        int[] base1 = { 2, 3, 5, 7 };

        // Начиная с целой части квадратного корня заданного числа N
        BigInteger start = NewtonSqrt(n);

        // Список пар квадратов, связанных с каждым числом из факторной базы
        List<(BigInteger, BigInteger)> pairs = new List<(BigInteger, BigInteger)>();

        // Для каждого числа от квадратного корня до N
        foreach (int baseNumber in base1)
        {
            // Находим квадраты, связанные с текущим числом и числами из факторной базы
            for (BigInteger i = start; i < n; i++)
            {
                BigInteger lhs = BigInteger.ModPow(i, 2, n);
                BigInteger rhs = BigInteger.ModPow(baseNumber, 2, n);
                if (lhs == rhs)
                {
                    pairs.Add((i, baseNumber));
                }
            }
        }

        // Проверяем каждую пару на НОД с числом N и добавляем найденные делители в список
        List<BigInteger> factors = new List<BigInteger>();
        foreach (var pair in pairs)
        {
            BigInteger factor = gcd(pair.Item1 - pair.Item2, n);
            if (factor != 1)
                factors.Add(factor);
        }

        // Убираем дубликаты из списка делителей
        HashSet<BigInteger> uniqueFactors = new HashSet<BigInteger>(factors);

        // Преобразуем HashSet в массив для удобства использования
        BigInteger[] uniqueFactorsArray = new BigInteger[uniqueFactors.Count];
        uniqueFactors.CopyTo(uniqueFactorsArray);

        // Возвращаем первые два уникальных делителя
        return (uniqueFactorsArray[0], uniqueFactorsArray[1]);
    }

    // Точка входа в программу
    public static void Main(string[] args)
    {
        // Вызываем функцию факторизации с заданным числом
        BigInteger n = 23449;
        var (factor1, factor2) = factor(n);
        Console.WriteLine($"Factors of {n}: {factor1}, {factor2}");
    }
}
