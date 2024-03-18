#include <iostream>
#include <vector>
#include <string>
#include "s2d.h"

// Константы
const double alpha = 401; // Коэффициент теплопроводности
const double dt = 0.1;     // Шаг по времени
const double dx = 0.1;     // Шаг по координате x
const double dy = 0.1;     // Шаг по координате y

// Функция для вывода 2D-матрицы температуры
void printTemperature2D(const std::vector<std::vector<double>>& temperature) {
    for (size_t i = 0; i < temperature.size(); ++i) {
        for (size_t j = 0; j < temperature[i].size(); ++j) {
            std::cout << temperature[i][j] << " ";
        }
        std::cout << std::endl;
    }
}


// Функция для решения уравнения теплопроводности в 2D с учетом плотности и удельной теплоемкости
void solveHeatEquation2D(double density, double specificHeat) {
    // Размеры сетки
    const int nx = 10; // Количество узлов по x
    const int ny = 10; // Количество узлов по y

    // Начальное распределение температуры
    std::vector<std::vector<double>> temperature(nx, std::vector<double>(ny, 0.0));
    temperature[nx / 2][ny / 2] = 100.0; // Устанавливаем высокую температуру в центре

    // Выполняем несколько временных шагов
    const int numSteps = 100;
    for (int step = 0; step < numSteps; ++step) {
        std::vector<std::vector<double>> newTemperature(nx, std::vector<double>(ny, 0.0));

        // Применяем явную схему конечных разностей для вычисления следующего значения температуры
        for (int i = 1; i < nx - 1; ++i) {
            for (int j = 1; j < ny - 1; ++j) {
                newTemperature[i][j] = temperature[i][j] + alpha * dt / (dx * dx) *
                    (temperature[i - 1][j] - 2 * temperature[i][j] + temperature[i + 1][j]) /
                    (density * specificHeat) +
                    alpha * dt / (dy * dy) * (temperature[i][j - 1] - 2 * temperature[i][j] + temperature[i][j + 1]) /
                    (density * specificHeat);
            }
        }

        // Обновляем значения температуры для следующего временного шага
        temperature = newTemperature;

        // Выводим значения температуры после каждого временного шага (для наглядности)
        std::cout << "Step " << step + 1 << ":" << std::endl;
        printTemperature2D(temperature);
        std::cout << std::endl;
    }
}