#define WIN32_LEAN_AND_MEAN // Этот макрос уменьшает объем заголовочных файлов Windows, исключая редко используемые определения.

#include <iostream>
#include <Windows.h>
#include <WinSock2.h>
#include <WS2tcpip.h>

using namespace std;

int main()
{
    WSADATA wsaData; // Структура для хранения информации о реализации библиотеки Winsock.
    ADDRINFO hints; // Структура, содержащая критерии для поиска адреса для соединения.
    ADDRINFO* addrResult; // Указатель на структуру ADDRINFO для хранения результатов getaddrinfo.
    SOCKET ClientSocket = INVALID_SOCKET; // Дескриптор сокета клиента.
    SOCKET ListenSocket = INVALID_SOCKET; // Дескриптор прослушивающего сокета.

    const char* sendBuffer = "Server"; // Буфер для отправки сообщения сервера.
    char recvBuffer[512]; // Буфер для приема сообщений от клиента.

    int result = WSAStartup(MAKEWORD(2, 2), &wsaData); // Инициализация библиотеки Winsock.
    if (result != 0) {
        cout << "WSAStartup failed" << endl;
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints)); // Заполняет память нулями для структуры hints.
    hints.ai_family = AF_INET; // Задает семейство адресов Internet для hints.
    hints.ai_socktype = SOCK_STREAM; // Задает тип сокета для hints.
    hints.ai_protocol = IPPROTO_TCP; // Задает протокол TCP для hints.
    hints.ai_flags = AI_PASSIVE; // Устанавливает флаг для привязки к адресу на сервере.

    result = getaddrinfo(NULL, "788", &hints, &addrResult); // Получает информацию об адресе для прослушивающего сокета.
    if (result != 0) {
        cout << "getaddrinfo failed" << endl;
        return 1;
    }

    ListenSocket = socket(addrResult->ai_family, addrResult->ai_socktype, addrResult->ai_protocol); // Создает прослушивающий сокет.
    if (ListenSocket == INVALID_SOCKET) {
        cout << "socket creation with error" << endl;
        freeaddrinfo(addrResult);
        return 1;
    }

    result = bind(ListenSocket, addrResult->ai_addr, (int)addrResult->ai_addrlen); // Привязывает сокет к адресу.
    if (result == SOCKET_ERROR) {
        cout << "binding connect failed" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }

    result = listen(ListenSocket, SOMAXCONN); // Переводит сокет в состояние прослушивания.
    if (result == SOCKET_ERROR) {
        cout << "Listening failed" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }

    ClientSocket = accept(ListenSocket, NULL, NULL); // Принимает входящее соединение.
    if (ClientSocket == INVALID_SOCKET) {
        cout << "Accepting Failed" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }

    do {
        ZeroMemory(recvBuffer, 512);
        result = recv(ClientSocket, recvBuffer, 512, 0); // Принимает данные от клиента.
        if (result > 0) {
            cout << "Получено " << result << " байт" << endl;
            cout << "Получено: " << recvBuffer << endl;

            // Отправка ответа после каждого принятого сообщения
            result = send(ClientSocket, sendBuffer, (int)strlen(sendBuffer), 0); // Отправляет данные клиенту.
            if (result == SOCKET_ERROR) {
                cout << "send Failed" << endl;
                freeaddrinfo(addrResult);
                WSACleanup();
                return 1;
            }
        }
        else if (result == 0) {
            cout << "Connection closed" << endl;
        }
        else {
            cout << "Сообщение не получено" << endl;
        }
    } while (result > 0);

    result = shutdown(ClientSocket, SD_SEND); // Завершает отправку данных.
    if (result == SOCKET_ERROR) {
        cout << "shutdown error" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }
    closesocket(ClientSocket); // Закрывает сокет клиента.
    freeaddrinfo(addrResult); // Освобождает память, выделенную для addrResult.
    WSACleanup(); // Завершает использование библиотеки Winsock.
}
