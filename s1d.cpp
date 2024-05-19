#include <iostream>  
#include <vector>  
#include <string>  
#include "s1d.h"   // Подключение пользовательской библиотеки s1d.h
#include <omp.h>   // Подключение библиотеки OpenMP для параллельных вычислений
#include "color_console.h"

// Константы
const double dt = 0.1;  // Шаг по времени
const double dx = 0.1;  // Шаг по координате x
const double dy = 0.1;  // Шаг по координате y

// Функция для вывода значения температуры на одномерной сетке
void printTemperature1D(const std::vector<double>& temperature) {
    for (size_t i = 0; i < temperature.size(); ++i) {  // Цикл по всем элементам вектора температур
        std::cout << temperature[i] << " ";  // Вывод значения температуры
    }
    std::cout << std::endl;  // Переход на новую строку
}

// Функция для решения уравнения теплопроводности в одном измерении
void solveHeatEquation1D(double density, double specificHeat, double alpha) {
    // Размер сетки
    const int nx = 10;  // Количество узлов по x

    density *= 1000;  // Приведение плотности к г/см^3
    specificHeat *= 1000;  // Приведение удельной теплоемкости к Дж/град

    int highTempLocation = 5;  // Позиция высокой температуры по умолчанию
    float initialTemperature = 100.0;  // Начальная температура по умолчанию

    SetConsoleColor(White);
    // Запрос у пользователя начальной температуры
    std::cout << "Введите начальную температуру (%):";
    std::cin >> initialTemperature;  // Ввод начальной температуры

    // Запрос у пользователя позиции высокой температуры на стержне
    while (true) {  // Цикл запроса корректной позиции высокой температуры
        std::cout << "На каком участке стержня будет иметь высокую температуру (от 1 до 10)?: ";
        std::cin >> highTempLocation;  // Ввод позиции высокой температуры
        if (highTempLocation >= 1 && highTempLocation <= 10) {  // Проверка корректности введенной позиции
            break;  // Выход из цикла запроса позиции
        }
    }

    // Начальное распределение температуры на сетке
    std::vector<double> temperature(nx, 22);  // Создание вектора температур заданного размера 
    temperature[highTempLocation] = initialTemperature;  // Установка начальной температуры в указанной позиции стержня

    // Выполнение нескольких временных шагов
    const int numSteps = 1000;  // Количество временных шагов
    for (int step = 0; step < numSteps; ++step) {  // Цикл по временным шагам
        std::vector<double> newTemperature(nx, 0.0);  // Создание нового вектора для хранения обновленных значений температуры

#pragma omp parallel for  // Директива OpenMP для параллельного выполнения цикла
        // Применение явной схемы конечных разностей для вычисления следующего значения температуры
        for (int i = 1; i < nx - 1; ++i) {  // Цикл по узлам сетки, кроме крайних точек
            newTemperature[i] = temperature[i] + alpha * dt / (dx * dx) *
                (temperature[i - 1] - 2 * temperature[i] + temperature[i + 1]) /
                (density * specificHeat);  // Вычисление новой температуры по формуле явной схемы конечных разностей
        }

        temperature = newTemperature;  // Обновление значений температуры для следующего временного шага

        SetConsoleColor(People);
        // Вывод значений температуры после каждого временного шага
        std::cout << "Step " << step + 1 << ": ";  // Вывод номера временного шага
        printTemperature1D(temperature);  // Вывод текущего распределения температуры
    }
}
