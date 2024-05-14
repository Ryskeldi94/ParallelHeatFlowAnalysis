#include <iostream>
#include <vector>
#include "s1d.h"
#include "s2d.h"

int main() {
    // Запрашиваем данные о плотности и удельной теплоемкости
    double density = 8930, specificHeat = 385;
    /*std::cout << "Enter density: ";
    std::cin >> density;
    std::cout << "Enter specific heat: ";
    std::cin >> specificHeat;*/
    
    // Запрашиваем у пользователя выбор между 1D и 2D решением уравнения теплопроводности
    std::cout << "Choose dimensionality (1D or 2D): ";
    std::string dimensionality;
    std::cin >> dimensionality;

    // Выполняем соответствующее решение в зависимости от выбора пользователя
    if (dimensionality == "1D") {
        solveHeatEquation1D(density, specificHeat);
    }
    else if (dimensionality == "2D") {
        solveHeatEquation2D(density, specificHeat);
    }
    else {
        std::cout << "Invalid dimensionality! Please choose 1D or 2D." << std::endl;
    }

    return 0;
}
