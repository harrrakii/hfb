#include <stdbool.h>
#include <string.h>

extern "C" __declspec(dllexport) bool serchstr(const char* str, const char* chars) {

    for (int i = 0; chars[i] != '\0'; i++) {
        if (strchr(str, chars[i]) == NULL) {
            return false;
        }
    }

    return true;
}