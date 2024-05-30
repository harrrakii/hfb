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
    locale::global(std::locale("")); // Устанавливает глобальную локаль, используемую для ввода-вывода.

    const char* sendBuffer1 = "Hi from Client"; // Буфер для отправки первого сообщения.
    const char* sendBuffer2 = "Hello from Client"; // Буфер для отправки второго сообщения.
    char recvBuffer[512]; // Буфер для приема сообщений от сервера.

    int result = WSAStartup(MAKEWORD(2, 2), &wsaData); // Инициализация библиотеки Winsock.
    if (result != 0) {
        cout << "WSAStartup failed" << endl;
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints)); // Заполняет память нулями для структуры hints.
    hints.ai_family = AF_INET; // Задает семейство адресов Internet для hints.
    hints.ai_socktype = SOCK_STREAM; // Задает тип сокета для hints.
    hints.ai_protocol = IPPROTO_TCP; // Задает протокол TCP для hints.

    result = getaddrinfo("localhost", "788", &hints, &addrResult); // Получает информацию об адресе для соединения с сервером.
    if (result != 0) {
        cout << "getaddrinfo failed" << endl;
        return 1;
    }

    ClientSocket = socket(addrResult->ai_family, addrResult->ai_socktype, addrResult->ai_protocol); // Создает сокет для клиента.
    if (ClientSocket == INVALID_SOCKET) {
        cout << "socket creation with error" << endl;
        freeaddrinfo(addrResult);
        return 1;
    }

    result = connect(ClientSocket, addrResult->ai_addr, (int)addrResult->ai_addrlen); // Устанавливает соединение с сервером.
    if (result == SOCKET_ERROR) {
        cout << "Unable to connect server" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }

    // Отправка первого сообщения
    result = send(ClientSocket, sendBuffer1, (int)strlen(sendBuffer1), 0); // Отправляет данные на сервер.
    if (result == SOCKET_ERROR) {
        cout << "send Failed" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }
    cout << "Sent " << result << " bytes of first message" << endl;

    // Прием ответа на первое сообщение
    ZeroMemory(recvBuffer, 512);
    result = recv(ClientSocket, recvBuffer, 512, 0); // Принимает данные от сервера.
    if (result > 0) {
        cout << "Получено " << result << " байт" << endl;
        cout << "Получено: " << recvBuffer << endl;
    }
    else if (result == 0) {
        cout << "Connection closed" << endl;
    }
    else {
        cout << "Сообщение не получено" << endl;
    }

    // Отправка второго сообщения
    result = send(ClientSocket, sendBuffer2, (int)strlen(sendBuffer2), 0); // Отправляет вторые данные на сервер.
    if (result == SOCKET_ERROR) {
        cout << "send Failed" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }
    cout << "Sent " << result << " bytes of second message" << endl;

    // Прием ответа на второе сообщение
    ZeroMemory(recvBuffer, 512);
    result = recv(ClientSocket, recvBuffer, 512, 0); // Принимает данные от сервера.
    if (result > 0) {
        cout << "Получено " << result << " байт" << endl;
        cout << "Получено: " << recvBuffer << endl;
    }
    else if (result == 0) {
        cout << "Connection closed" << endl;
    }
    else {
        cout << "Сообщение не получено" << endl;
    }

    result = shutdown(ClientSocket, SD_SEND); // Завершает отправку данных.
    if (result == SOCKET_ERROR) {
        cout << "shutdown error" << endl;
        freeaddrinfo(addrResult);
        WSACleanup();
        return 1;
    }

    closesocket(ClientSocket); // Закрывает сокет.
    freeaddrinfo(addrResult); // Освобождает память, выделенную для addrResult.
    WSACleanup(); // Завершает использование библиотеки Winsock.
}
