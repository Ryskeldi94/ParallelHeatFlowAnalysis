#ifndef COLOR_CONSOLE_H
#define COLOR_CONSOLE_H

#include <Windows.h>

enum ColorConsole {
    DarkBlue = 1,
    DarkGreen = 2,
    lBlue = 3,
    Red = 4,
    People = 5,
    Yellow = 6,
    White = 7,
    Grey = 8,
    Blue = 9,
    Green = 10
};

void SetConsoleColor(ColorConsole color);

#endif // COLOR_CONSOLE_H
