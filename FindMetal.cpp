#include <iostream>
#include "JSN/include/nlohmann/json.hpp"
#include "FindMetal.h"
using json = nlohmann::json; // Псевдоним для удобства использования

void FindMetal() {
    // Создаем JSON объект
    json j = {
        {"name", "John"},
        {"age", 30},
        {"city", "New York"}
    };

    // Выводим JSON объект
    std::cout << j.dump() << std::endl;

}
