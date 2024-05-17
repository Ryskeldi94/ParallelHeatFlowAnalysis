#ifndef HEAT_EQUATION_H
#define HEAT_EQUATION_H

extern "C" {
    // Экспортируемая функция для решения уравнения теплопроводности в одном измерении
    __declspec(dllexport) double* solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature);

    // Экспортируемая функция для освобождения памяти, выделенной для хранения результатов
    __declspec(dllexport) void freeMemory(double* ptr);
}

#endif // HEAT_EQUATION_H
