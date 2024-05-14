#include <iostream>
#include <vector>
#include <string>
#include "s1d.h"
#include <omp.h> // Добавляем заголовочный файл OpenMP
#include <chrono>

// Константы
const double dt = 0.1;     // Шаг по времени
const double dx = 0.1;     // Шаг по координате x
const double dy = 0.1;     // Шаг по координате y

void printTemperature1D(const std::vector<double>& temperature) {
    for (size_t i = 0; i < temperature.size(); ++i) {
        std::cout << temperature[i] << " ";
    }
    std::cout << std::endl;
}

void solveHeatEquation1D(double density, double specificHeat, double alpha) {
    // Размер сетки
    const int nx = 1000; // Количество узлов по x

    // Начальное распределение температуры
    std::vector<double> temperature(nx, 0.0);
    temperature[nx / 2] = 100.0; // Устанавливаем высокую температуру в середине стержня
    auto start = std::chrono::steady_clock::now();

    // Выполняем несколько временных шагов
    const int numSteps = 10000000;

    for (int step = 0; step < numSteps; ++step) {
        std::vector<double> newTemperature(nx, 0.0);
//#pragma omp parallel for 
        // Применяем явную схему конечных разностей для вычисления следующего значения температуры
        for (int i = 1; i < nx - 1; ++i) {
            newTemperature[i] = temperature[i] + alpha * dt / (dx * dx) *
                (temperature[i - 1] - 2 * temperature[i] + temperature[i + 1]) /
                (density * specificHeat);
        }

        // Обновляем значения температуры для следующего временного шага
        temperature = newTemperature;

        // Выводим значения температуры после каждого временного шага (для наглядности)
        //std::cout << "Step " << step + 1 << ": ";
        //printTemperature1D(temperature);
    }

    auto end = std::chrono::steady_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start);

    // Выводим продолжительность выполнения кода
    std::cout << "Execution time: " << duration.count() << " milliseconds\n";
}

