using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.IO;

namespace AlgorytmsLibrary
{
    public class Program
    {
        public static void Test()
        {
            List<IResercheable> algorythmList = new List<IResercheable>()
            {
                /*
                new BubbleSort(2000, "BubbleSort"),
                
                new TimSort(20000, "TimSort"),
                new Linal(50000, "Linal"),
                new Sum(50000, "Summ"),
                new Gorner(10000, "Gorner"),
                new Gorner0(10000,"Direct"),
                new QuickSort(12000, "QuickSort")
                */
            };

            foreach (IResercheable algorythm in algorythmList)
            {
                Export(algorythm);
            }
        }
    }

    public class Tools
    {
        public static List<DataPoint> Export(IResercheable algorythm, int minN, int maxN)
        {
            List<(int, long)> results = new List<(int, long)>();

            // Генерация массива и экспорт данных
            for (int j = minN; j <= maxN; j++)
            {
                for (int i = 0; i < 30; i++)
                {
                    results.Add((
                    j,
                    Timer(GenerateArray(j), algorythm)));
                }
            }

            var res = new List<DataPoint> { };
            for (int i = minN; i <= maxN; i++)
            {
                double average = results.Where(x => x.Item1 == i).Average(x => x.Item2);
                res.Add(new DataPoint(i, (long)average));
            }

            return res;
        }


        // Таймер
        public static long Timer(int[] array, IResercheable algorythm)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            algorythm.Run(array);
            stopwatch.Stop();

            return stopwatch.ElapsedTicks / 100;
        }


        // Генерация массива
        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 100000);
            }
            return array;
        }

        //Запуск массива и экспорт данных(кол-во данных и время затраченного времени) для wpf
        public static List<DataPoint> Export(IResercheable algorythm)
        {
            List<(int, long)> results = new List<(int, long)>();

            // TestArray = GenerateArray(size);
            for (int j = 1; j <= algorythm.TestArray.Length; j++)
            {
                for (int i = 0; i < 30; i++)
                {
                    results.Add((
                    j,
                    Timer(GenerateArray(j), algorythm)));
                }
            }


            var res = new List<DataPoint> { };
            for (int i = 1; i <= algorythm.TestArray.Length; i++)
            {
                double average = results.Where(x => x.Item1 == i).Average(x => x.Item2);
                res.Add(new DataPoint(i, (long)average));
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

        public int Size { get; }
    }
}