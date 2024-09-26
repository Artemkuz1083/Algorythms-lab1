using System;
using System.Collections.Generic;
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

        }
    }

    class Tools
    {
        // Таймер


        // Генерация массива

    
    
    }

    public abstract class IResercheable
    {
        //Метод, описывающий алгоритм
        //array - набор данных, который будет тестироваться
        //value - значение, которое ищем в массиве
        protected IResercheable(int size, string name)
        {
            Name = name;
        }
                
        public abstract void Run(int[] array, int value = 0);

        public int[] TestArray { get; }
        //Имя, которое отображается в экспортном файле
        public string Name { get; }
    }
    
}
    