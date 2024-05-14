#include <iostream> // Подключение заголовочного файла для стандартного ввода/вывода
#include <vector> // Подключение заголовочного файла для работы с векторами
#include "s1d.h" // Подключение заголовочного файла для функций одномерного решения
#include "s2d.h" // Подключение заголовочного файла для функций двумерного решения
#include "FindMetal.h" // Подключение заголовочного файла для поиска металла
#include "color_console.h" // Подключение заголовочного файла для работы с цветом в консоли

double density, specificHeat, alpha; // Объявление переменных для плотности, удельной теплоемкости и коэффициента теплопроводности металла

char chooseOption() {
    char choice;
    while (true) {
        std::cout << "Выберите опцию:" << std::endl;
        std::cout << "1. Выбрать металл из списка" << std::endl;
        std::cout << "2. Ввести свои свойства металла" << std::endl;
        std::cout << "Введите номер опции: ";
        std::cin >> choice;
       
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
    char option = chooseOption(); // Вызов функции выбора опции и сохранение результата в переменной

    if (option == '1') { // Проверка выбора опции на выбор металла из списка
        json chosenMetal = FindMetal(); // Вызов функции поиска металла и сохранение результата в переменной типа json
        if (!chosenMetal.is_null()) {
            std::cout << "Выбранный металл: " << chosenMetal["название"] << std::endl;
            std::cout << "Плотность: " << chosenMetal["плотность (г/см³)"] << std::endl;
            std::cout << "Удельная теплоемкость: " << chosenMetal["удельная теплоемкость (Дж/г·°C)"] << std::endl;
            std::cout << "Коэффициент теплопроводности: " << chosenMetal["коэффициент теплопроводности (Вт/м·°C)"] << std::endl << std::endl;

            density = chosenMetal["плотность (г/см³)"];
            specificHeat = chosenMetal["удельная теплоемкость (Дж/г·°C)"];
            alpha = chosenMetal["коэффициент теплопроводности (Вт/м·°C)"];
        }
    }
    else { // Ввод пользовательских свойств металла
        std::cout << "Введите плотность (г/см³): ";
        std::cin >> density;
        std::cout << "Введите удельную теплоемкость (Дж/г·°C) ";
        std::cin >> specificHeat;
        std::cout << "Введите коэффициент теплопроводности (Вт/м·°C): ";
        std::cin >> alpha;
    }

    while (true) { // Бесконечный цикл запроса размерности решения
        std::cout << "Выберите размерность решения (1D или 2D): ";
        std::string dimensionality;
        std::cin >> dimensionality; // Чтение выбранной размерности из стандартного ввода

        // Выполнение соответствующего решения в зависимости от выбора пользователя
        if (dimensionality == "1D") {
            solveHeatEquation1D(density, specificHeat, alpha);
            break;
        }
        else if (dimensionality == "2D") {
            solveHeatEquation2D(density, specificHeat, alpha);
            break;
        }
        else {
            std::cout << "Неверная размерность! Пожалуйста, ";
        }
    }

    return 0; // Возврат нуля, указывающего на успешное завершение программы
}
