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
            
        }
    }

    public class Tools
    {
        public static List<DataPoint> Export(IResercheable algorythm, int minN, int maxN)
        {
            List<(int, double)> results = new List<(int, double)>();

            // Генерация массива и экспорт данных
            for (int j = minN; j <= maxN; j++)
            {
                var array = GenerateArray(j);
                for (int i = 0; i < 5; i++)
                {
                    results.Add((
                    j,
                    Timer(array, algorythm)));
                }
            }

            var res = new List<DataPoint> { };
            for (int i = minN; i <= maxN; i++)
            {
                double average = results.Where(x => x.Item1 == i).Average(x => x.Item2);
                res.Add(new DataPoint(i, average));
            }

            return res;
        }


        // Таймер
        public static double Timer(int[] array, IResercheable algorythm)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            algorythm.Run(array);
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
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