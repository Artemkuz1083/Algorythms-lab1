using System.Collections.Generic;

namespace PowAlgorythms
{
    // Интерфейс для степенных алгоритмов
    public interface IPowAlgorithm
    {
        List<(int, int)> Steps { get; }  // Список шагов (степень, количество шагов)
        void Run();                      // Метод для выполнения алгоритма
        string GetName();                // Имя алгоритма
    }
}