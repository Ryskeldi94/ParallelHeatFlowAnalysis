#include <iostream>
#include "JSN/include/nlohmann/json.hpp"
#include "FindMetal.h"
#include <fstream>

using json = nlohmann::json; // Псевдоним для удобства использования

json FindMetal() {
    // Загружаем JSON из файла
    std::string filename = "metals.json";
    std::ifstream file(filename);
    if (!file.is_open()) {
        std::cerr << "Ошибка при открытии файла." << std::endl;
        return json(nullptr);
    }

    json j;
    try {
        file >> j;
    }
    catch (const std::exception& e) {
        std::cerr << "Ошибка при парсинге JSON: " << e.what() << std::endl;
        return json(nullptr);
    }
    int count = 0;
    // Проверяем наличие массива "металлы"
    if (j.find("металлы") != j.end() && j["металлы"].is_array()) {
        // Перебираем объекты в массиве "металлы" и выводим их названия
        for (const auto& metal : j["металлы"]) {
            count += 1;
            std::cout << count << metal["название"] << std::endl;
        }
    }
    
    while (true) {
    // Запрашиваем у пользователя номер выбранного металла
    int chosenMetalNumber;
    std::cout << "Введите номер выбранного металла: ";
    std::cin >> chosenMetalNumber;
    count = 0;
    // Проверяем, что введенный номер находится в допустимом диапазоне
       if (chosenMetalNumber >= 1 && chosenMetalNumber <= j["металлы"].size()) {
        // Выводим информацию о выбранном металле
           std::cout << "\033[2J\033[1;1H"; // Очистка экрана
           return j["металлы"][chosenMetalNumber - 1];
        } else {
           std::cout << "\033[2J\033[1;1H"; // Очистка экрана
           for (const auto& metal : j["металлы"]) {
               count += 1;
               std::cout << count << metal["название"] << std::endl;
           }
           std::cout << "Неверный выбор. Пожалуйста, ";
        } 
    }
}
