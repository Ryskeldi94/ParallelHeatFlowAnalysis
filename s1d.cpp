#include "s1d.h"
#include <vector>
#include <omp.h>
#include <algorithm>

// Константы
const double dt = 0.1;  // Шаг по времени
const double dx = 0.1;  // Шаг по координате x

// Функция для решения уравнения теплопроводности в одном измерении и возврата результата
double* solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature) {
    const int nx = 10;  // Количество узлов по x

    // Приведение плотности и удельной теплоемкости к нужным единицам измерения
    density *= 1000;  // Приведение плотности к г/см^3
    specificHeat *= 1000;  // Приведение удельной теплоемкости к Дж/град

    // Проверка и установка значений по умолчанию
    if (highTempLocation == 0 || highTempLocation >= nx) highTempLocation = 5;
    if (initialTemperature == 0) initialTemperature = 100.0;
    if (ambientTemperature == 0) ambientTemperature = 25;

    // Создание и инициализация вектора температур
    std::vector<double> temperature(nx, ambientTemperature);
    temperature[highTempLocation] = initialTemperature;

    const int numSteps = 1000;  // Количество временных шагов
    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx, 0.0);  // Создание нового вектора для хранения обновленных значений температуры
#pragma omp parallel for
        for (int i = 1; i < nx - 1; ++i) {
            newTemperature[i] = temperature[i] + alpha * dt / (dx * dx) *
                (temperature[i - 1] - 2 * temperature[i] + temperature[i + 1]) /
                (density * specificHeat);
        }
        temperature = newTemperature;  // Обновление значений температуры для следующего временного шага
    }

    // Копирование результата в массив для возврата в C#
    double* result = new double[nx];
    std::copy(temperature.begin(), temperature.end(), result);

    return result;  // Возврат указателя на массив с результатами
}

// Функция для освобождения памяти, выделенной для хранения результатов
void freeMemory(double* ptr) {
    delete[] ptr;
}
