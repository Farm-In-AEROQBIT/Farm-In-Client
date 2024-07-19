#include <windows.h>
#include <wininet.h>
#include <stdio.h>
#define _CRT_SECURE_NO_WARNINGS


// WinINet ���̺귯���� ��ũ
#pragma comment(lib, "wininet.lib")

// ���Ͽ��� �����͸� �д� �Լ�
char* ReadDataFromFile(const char* filePath) {
    FILE* file;
    errno_t err = fopen_s(&file, filePath, "r");
    if (err != 0 || !file) {
        printf("Failed to open file\n");
        return NULL;
    }

    fseek(file, 0, SEEK_END);
    long fileSize = ftell(file);
    rewind(file);

    char* buffer = (char*)malloc((fileSize + 1) * sizeof(char));
    if (!buffer) {
        printf("Memory allocation failed\n");
        fclose(file);
        return NULL;
    }

    fread(buffer, sizeof(char), fileSize, file);
    buffer[fileSize] = '\0';
    fclose(file);

    return buffer;
}

// ������ �����͸� �����ϴ� �Լ�
void SendDataToServer(const char* serverIp, const char* serverPort, const char* data) {
    HINTERNET hInternet, hConnect, hRequest;
    BOOL bRequestSent;
    char serverAddress[256];

    // ��Ʈ ��ȣ�� ������ ���� �ּ� ���ڿ� ����
    snprintf(serverAddress, sizeof(serverAddress), "%s:%s", serverIp, serverPort);

    // WinINet �ʱ�ȭ
    hInternet = InternetOpen(L"DataSender", INTERNET_OPEN_TYPE_DIRECT, NULL, NULL, 0);
    if (!hInternet) {
        printf("InternetOpen failed\n");
        return;
    }

    // ������ ����
    hConnect = InternetConnectA(hInternet, serverIp, atoi(serverPort), NULL, NULL, INTERNET_SERVICE_HTTP, 0, 0);
    if (!hConnect) {
        printf("InternetConnect failed\n");
        InternetCloseHandle(hInternet);
        return;
    }

    // HTTP ��û ����
    hRequest = HttpOpenRequestA(hConnect, "POST", "/data", NULL, NULL, NULL, 0, 0);
    if (!hRequest) {
        printf("HttpOpenRequest failed\n");
        InternetCloseHandle(hConnect);
        InternetCloseHandle(hInternet);
        return;
    }

    // ��û ����
    bRequestSent = HttpSendRequestA(hRequest, NULL, 0, (LPVOID)data, strlen(data));
    if (!bRequestSent) {
        printf("HttpSendRequest failed\n");
    }
    else {
        printf("Data sent successfully\n");
    }

    // ����
    InternetCloseHandle(hRequest);
    InternetCloseHandle(hConnect);
    InternetCloseHandle(hInternet);
}

// �ֱ������� �����͸� �����ϴ� ������ �Լ�
DWORD WINAPI ThreadFunc(void* param) {
    const char* serverIp = ((const char**)param)[0];
    const char* serverPort = ((const char**)param)[1];
    const char* filePath = ((const char**)param)[2];

    while (1) {
        char* sensorData = ReadDataFromFile(filePath);
        if (sensorData) {
            SendDataToServer(serverIp, serverPort, sensorData);
            free(sensorData);
        }
        Sleep(21600000); // 6�ð� ���
    }

    return 0;
}

int main() {
    const char* serverIp = "14.51.17.64"; // ������ ���� IP �ּ�
    const char* serverPort = "8081"; // ������ ��Ʈ ��ȣ
    const char* filePath = "\\My Documents\\sensor_data.txt"; // ������ ���� ���

    const char* params[3] = { serverIp, serverPort, filePath };

    // ���ο� �����带 �����Ͽ� �ֱ������� �����͸� ����
    HANDLE hThread = CreateThread(NULL, 0, ThreadFunc, (void*)params, 0, NULL);
    if (hThread == NULL) {
        printf("CreateThread failed\n");
        return 1;
    }

    // ���� �����忡�� ���� ������ �����带 ��ٸ�
    WaitForSingleObject(hThread, INFINITE);

    return 0;
}
