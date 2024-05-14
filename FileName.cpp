#include <iostream>
#include <vector>
#include "s1d.h"
#include "s2d.h"
#include "FindMetal.h"

//плотности,  удельной теплоемкости, коэффициент теплопроводности
double density, specificHeat, alpha;

// Функция для выбора опции (выбор из списка или ввод свойств)
char chooseOption() {
    char choice;
    while (true) {
        std::cout << "Выберите опцию:" << std::endl;
        std::cout << "1. Выбрать металл из списка" << std::endl;
        std::cout << "2. Ввести свои свойства металла" << std::endl;
        std::cout << "Введите номер опции: ";
        std::cin >> choice;
        std::cin.clear(); // Очистка буфера ввода
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); // Очистка оставшихся символов в буфере

        if (choice == '1' || choice == '2') {
            std::cout << "\033[2J\033[1;1H"; // Очистка экрана
            break; // Выход из цикла, если выбрана корректная опция
        }
        else {
            std::cout << "\033[2J\033[1;1H"; // Очистка экрана
            std::cout << "Неверный выбор. Пожалуйста, выберите одну из доступных опций." << std::endl;
        }
    }
    return choice;
}

int main() {
    //Запрашиваем выбор 
    char option = chooseOption();

    if (option == '1') {
        json chosenMetal = FindMetal();
        if (!chosenMetal.is_null()) {
            std::cout << "Выбранный металл: " << chosenMetal["название"] << std::endl;
            std::cout << "Плотность: " << chosenMetal["плотность (г/см³)"] << std::endl;
            std::cout << "Удельная теплоемкость: " << chosenMetal["удельная теплоемкость (Дж/г·°C)"] << std::endl;
            std::cout << "Коэффициент теплопроводности: " << chosenMetal["коэффициент теплопроводности (Вт/м·°C)"] << std::endl << std::endl ;

            density = chosenMetal["плотность (г/см³)"];
            specificHeat = chosenMetal["удельная теплоемкость (Дж/г·°C)"];
            alpha = chosenMetal["коэффициент теплопроводности (Вт/м·°C)"];
        }
    } else { // Запрашиваем данные о плотности и удельной теплоемкости
        std::cout << "Введите плотность (г/см³): ";
        std::cin >> density;
        std::cout << "Введите удельную теплоемкость (Дж/г·°C) ";
        std::cin >> specificHeat;
        std::cout << "Введите коэффициент теплопроводности (Вт/м·°C): ";
        std::cin >> alpha;
    }
    
    while (true) { // Запрашиваем у пользователя выбор между одномерным (1D) и двумерным (2D) решением уравнения теплопроводности
        std::cout << "Выберите размерность решения (1D или 2D): ";
        std::string dimensionality;
        std::cin >> dimensionality;

        // Выполняем соответствующее решение в зависимости от выбора пользователя
        if (dimensionality == "1D") {
            solveHeatEquation1D(density, specificHeat, alpha);
        }
        else if (dimensionality == "2D") {
            solveHeatEquation2D(density, specificHeat, alpha);
        }
        else {
            std::cout << "Неверная размерность! Пожалуйста, ";
        }
    }

    return 0;
}
