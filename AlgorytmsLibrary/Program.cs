using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IResercheable> algorythmList = new List<IResercheable>()
            {
                new BubbleSort(2000, "BubbleSort"),
                new TimSort(20000, "TimSort"),
                new Linal(50000, "Linal"),
                new Sum(50000, "Summ"),
                new Gorner(10000, "Gorner"),
                new Gorner0(10000,"Direct"),
                new QuickSort(12000, "QuickSort")
            };

            foreach (IResercheable algorythm in algorythmList)
            {
                Export(algorythm);
            }
        }
    }

    class Tools
    {
        // Таймер
        public static long Timer(int[] array, IResercheable algorythm)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            algorythm.Run(array);
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }


        // Генерация массива
        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 1000000);
            }
            return array;
        }

        //Запуск массива и экспорт данных(кол-во данных и время затраченного времени) для wpf
        public static List<(int, long)> Export(IResercheable algorythm)
        {
            List<(int, long)> results = new List<(int, long)>();

            // TestArray = GenerateArray(size);
            foreach (int dimension in algorythm.TestArray)
            {
                for (int i = 0; i < 5; i++)
                {
                    results.Add((dimension,
                    Timer(GenerateArray(dimension), algorythm)));
                }
            }

            List<(int, long)> res = new List<(int, long)>();
            for (int i = 1; i <= algorythm.TestArray.Length; i++)
            {
                var average = results.Where(x => x.Item1 == i).Average(x => x.Item2);
                res.Add((i, (long)average));
            }

            return res;
        }
    }

    public abstract class IResercheable
    {
        //Метод, описывающий алгоритм
        //array - набор данных, который будет тестироваться
        //value - значение, которое ищем в массиве
        protected IResercheable(int size, string name)
        {
            TestArray = GenerateArray(size);
            Name = name;
        }
                
        public abstract void Run(int[] array, int value = 0);

        public int[] TestArray { get; }
        
        public string Name { get; }
    }  
}
    