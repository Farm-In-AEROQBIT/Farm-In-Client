#include <windows.h>
#include <wininet.h>
#include <stdio.h>
#define _CRT_SECURE_NO_WARNINGS


// WinINet 라이브러리를 링크
#pragma comment(lib, "wininet.lib")

// 파일에서 데이터를 읽는 함수
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

// 서버로 데이터를 전송하는 함수
void SendDataToServer(const char* serverIp, const char* serverPort, const char* data) {
    HINTERNET hInternet, hConnect, hRequest;
    BOOL bRequestSent;
    char serverAddress[256];

    // 포트 번호를 포함한 서버 주소 문자열 생성
    snprintf(serverAddress, sizeof(serverAddress), "%s:%s", serverIp, serverPort);

    // WinINet 초기화
    hInternet = InternetOpen(L"DataSender", INTERNET_OPEN_TYPE_DIRECT, NULL, NULL, 0);
    if (!hInternet) {
        printf("InternetOpen failed\n");
        return;
    }

    // 서버에 연결
    hConnect = InternetConnectA(hInternet, serverIp, atoi(serverPort), NULL, NULL, INTERNET_SERVICE_HTTP, 0, 0);
    if (!hConnect) {
        printf("InternetConnect failed\n");
        InternetCloseHandle(hInternet);
        return;
    }

    // HTTP 요청 열기
    hRequest = HttpOpenRequestA(hConnect, "POST", "/data", NULL, NULL, NULL, 0, 0);
    if (!hRequest) {
        printf("HttpOpenRequest failed\n");
        InternetCloseHandle(hConnect);
        InternetCloseHandle(hInternet);
        return;
    }

    // 요청 전송
    bRequestSent = HttpSendRequestA(hRequest, NULL, 0, (LPVOID)data, strlen(data));
    if (!bRequestSent) {
        printf("HttpSendRequest failed\n");
    }
    else {
        printf("Data sent successfully\n");
    }

    // 정리
    InternetCloseHandle(hRequest);
    InternetCloseHandle(hConnect);
    InternetCloseHandle(hInternet);
}

// 주기적으로 데이터를 전송하는 쓰레드 함수
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
        Sleep(21600000); // 6시간 대기
    }

    return 0;
}

int main() {
    const char* serverIp = "14.51.17.64"; // 서버의 공인 IP 주소
    const char* serverPort = "8081"; // 서버의 포트 번호
    const char* filePath = "\\My Documents\\sensor_data.txt"; // 데이터 파일 경로

    const char* params[3] = { serverIp, serverPort, filePath };

    // 새로운 쓰레드를 생성하여 주기적으로 데이터를 전송
    HANDLE hThread = CreateThread(NULL, 0, ThreadFunc, (void*)params, 0, NULL);
    if (hThread == NULL) {
        printf("CreateThread failed\n");
        return 1;
    }

    // 메인 쓰레드에서 새로 생성된 쓰레드를 기다림
    WaitForSingleObject(hThread, INFINITE);

    return 0;
}
