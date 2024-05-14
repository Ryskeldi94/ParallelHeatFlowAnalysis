#include <iostream>  
#include <vector>  
#include <string>  
#include "s2d.h"   // Подключение пользовательской библиотеки s2d.h
#include <omp.h>   // Подключение библиотеки OpenMP для параллельных вычислений
#include "color_console.h"

// Константы
const double dt = 0.1;  // Шаг по времени
const double dx = 0.1;  // Шаг по координате x
const double dy = 0.1;  // Шаг по координате y

// Функция для вывода 2D-матрицы температуры
void printTemperature2D(const std::vector<std::vector<double>>& temperature) {
    for (size_t i = 0; i < temperature.size(); ++i) {  // Цикл по строкам матрицы температуры
        for (size_t j = 0; j < temperature[i].size(); ++j) {  // Цикл по столбцам матрицы температуры
            std::cout << temperature[i][j] << " ";  // Вывод текущего значения температуры
        }
        std::cout << std::endl;  // Переход на новую строку после вывода строки матрицы
    }
}

// Функция для решения уравнения теплопроводности в 2D с учетом плотности и удельной теплоемкости
void solveHeatEquation2D(double density, double specificHeat, double alpha) {
    // Размеры сетки
    const int nx = 10;  // Количество узлов по x
    const int ny = 10;  // Количество узлов по y

    density *= 1000;  // Приведение плотности к г/см^3
    specificHeat *= 1000;  // Приведение удельной теплоемкости к Дж/град

    int highTempLocationX = 5;  // Позиция высокой температуры по X
    int highTempLocationY = 5;  // Позиция высокой температуры по Y
    float initialTemperature = 100.0;  // Начальная температура

    std::cout << "Введите начальную температуру (%):";  // Запрос ввода начальной температуры
    std::cin >> initialTemperature;  // Считывание начальной температуры с клавиатуры

    while (true) {  // Цикл для ввода позиции высокой температуры по X
        std::cout << "На каком участке стержня будет иметь высокую температуру по X (от 1 до 10)?: ";
        std::cin >> highTempLocationX;
        if (highTempLocationX >= 1 && highTempLocationX <= 10) {
            break;
        }
    }

    while (true) {  // Цикл для ввода позиции высокой температуры по Y
        std::cout << "На каком участке стержня будет иметь высокую температуру по Y (от 1 до 10)?: ";
        std::cin >> highTempLocationY;
        if (highTempLocationY >= 1 && highTempLocationY <= 10) {
            break;
        }
    }

    // Начальное распределение температуры на сетке
    std::vector<std::vector<double>> temperature(nx, std::vector<double>(ny, 0.0));
    temperature[highTempLocationX][highTempLocationY] = initialTemperature;  // Установка высокой температуры в заданных координатах

    // Выполнение нескольких временных шагов
    const int numSteps = 100;  // Количество временных шагов
#pragma omp parallel for  // Директива OpenMP для параллельного выполнения внешнего цикла
    for (int step = 0; step < numSteps; ++step) {  // Цикл по временным шагам
        std::vector<std::vector<double>> newTemperature(nx, std::vector<double>(ny, 0.0));  // Создание новой матрицы температуры

        // Применение явной схемы конечных разностей для вычисления следующего значения температуры
        for (int i = 1; i < nx - 1; ++i) {  // Цикл по строкам
            for (int j = 1; j < ny - 1; ++j) {  // Цикл по столбцам
                newTemperature[i][j] = temperature[i][j] + alpha * dt / (dx * dx) *
                    (temperature[i - 1][j] - 2 * temperature[i][j] + temperature[i + 1][j]) /
                    (density * specificHeat) +
                    alpha * dt / (dy * dy) * (temperature[i][j - 1] - 2 * temperature[i][j] + temperature[i][j + 1]) /
                    (density * specificHeat);
            }
        }

        // Обновление значений температуры для следующего временного шага
#pragma omp critical  // Директива для безопасного доступа к общей переменной temperature
        temperature = newTemperature;  // Обновление значений температуры

        // Вывод значений температуры после каждого временного шага
        std::cout << "Step " << step + 1 << ":" << std::endl;  // Вывод номера временного
        printTemperature2D(temperature);
        std::cout << std::endl;
    }
}