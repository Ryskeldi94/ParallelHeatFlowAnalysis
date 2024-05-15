#include <iostream> // Подключение заголовочного файла для стандартного ввода/вывода
#include "JSN/include/nlohmann/json.hpp" // Подключение заголовочного файла для работы с JSON
#include "FindMetal.h" // Подключение заголовочного файла для функции поиска металла
#include <fstream> // Подключение заголовочного файла для работы с файлами
#include "color_console.h" // Подключение заголовочного файла для работы с цветом в консоли
#include <windows.h>

using json = nlohmann::json; // Псевдоним для удобства использования

json FindMetal() { // Объявление функции поиска металла
    std::string filename = "metals.json"; // Имя файла с данными о металлах
    std::ifstream file(filename); // Поток для чтения из файла
    if (!file.is_open()) { // Проверка успешного открытия файла
        std::cerr << "Ошибка при открытии файла." << std::endl; // Вывод сообщения об ошибке в стандартный поток ошибок
        return json(nullptr); // Возвращение пустого JSON объекта
    }

    json j; // Создание JSON объекта
    try {
        file >> j; // Попытка чтения JSON данных из файла
    }
    catch (const std::exception& e) { // Обработка исключений
        std::cerr << "Ошибка при парсинге JSON: " << e.what() << std::endl; // Вывод сообщения об ошибке в стандартный поток ошибок
        return json(nullptr); // Возвращение пустого JSON объекта
    }
    int count = 0; // Переменная для подсчета количества металлов

    if (j.find("металлы") != j.end() && j["металлы"].is_array()) { // Проверка наличия массива "металлы"
        for (const auto& metal : j["металлы"]) { // Перебор всех металлов в массиве
            count += 1; // Увеличение счетчика

            SetConsoleColor(Yellow);
            std::cout << count << metal["название"] << std::endl; // Вывод названия металла на экран
            Sleep(50);
        }
    }

    while (true) { // Бесконечный цикл для ввода номера выбранного металла
        int chosenMetalNumber; // Переменная для хранения выбранного номера металла

        SetConsoleColor(White);
        std::cout << "Введите номер выбранного металла: "; // Запрос ввода номера металла
        std::cin >> chosenMetalNumber; // Чтение номера металла из стандартного ввода
        count = 0; // Сброс счетчика

        if (chosenMetalNumber >= 1 && chosenMetalNumber <= j["металлы"].size()) { // Проверка корректности введенного номера металла
            std::cout << "\033[2J\033[1;1H"; // Очистка экрана
            return j["металлы"][chosenMetalNumber - 1]; // Возвращение выбранного металла
        }
        else {
            std::cout << "\033[2J\033[1;1H"; // Очистка экрана
            for (const auto& metal : j["металлы"]) { // Перебор всех металлов в массиве
                count += 1; // Увеличение счетчика
                std::cout << count << metal["название"] << std::endl; // Вывод названия металла на экран
            }
            std::cout << "Неверный выбор. Пожалуйста, "; // Вывод сообщения об ошибке в стандартный поток ошибок
        }
    }
}
