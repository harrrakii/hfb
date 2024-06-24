#include <iostream>
#include <string>
#include <windows.h>

typedef bool (*CheckCharactersFunction)(const char*, const char*);

int main() {
    using namespace std;

    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    cout << "Строка для поиска: ";
    string inputString;
    getline(cin, inputString);

    cout << "Символы для поиска: ";
    string searchChars;
    getline(cin, searchChars);

    HINSTANCE hLib = LoadLibrary(L"DinLib.dll");
    if (!hLib) {
        cerr << "Не удалось загрузить библиотеку string_utils.dll" << endl;
        return 1;
    }

    CheckCharactersFunction checkChars = (CheckCharactersFunction)GetProcAddress(hLib, "serchstr");
    if (!checkChars) {
        cerr << "Не удалось найти функцию serchstr" << endl;
        FreeLibrary(hLib);
        return 1;
    }

    bool result = checkChars(inputString.c_str(), searchChars.c_str());
    if (result) {
        cout << "Поздравляю! такие сиимволы есть :)" << endl;
    }
    else {
        cout << "Таких символов не наблюдается :(" << endl;
    }

    FreeLibrary(hLib);

    return 0;
}
