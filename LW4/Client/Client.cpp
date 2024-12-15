#include <winsock.h>
#include <windows.h>
#include <stdio.h>
#include <string>
#include "GraphicsLib.h"
#pragma comment(lib, "ws2_32.lib")
#pragma warning(disable: 4996)
#define Size 10000

class Display : public GraphicsLib
{
	public:
		SOCKET ClientSocket;
		SOCKADDR_IN ServerAddress;
		int ServerAddressSize;

		Display(uint16_t width, uint16_t height, std::string host, uint16_t port)
		{
			WSAData Data;
			WSAStartup(MAKEWORD(2, 2), &Data);
			ClientSocket = socket(AF_INET, SOCK_DGRAM, 0);
			ServerAddress.sin_family = AF_INET;
			ServerAddress.sin_port = htons(port);
			ServerAddress.sin_addr.s_addr = inet_addr(host.c_str());
			ServerAddressSize = sizeof(ServerAddress);
		}

		int get_red(uint_least16_t color)
		{
			return 1;
		}
		int get_green(uint_least16_t color)
		{
			return 2;
		}
		int get_blue(uint_least16_t color)
		{
			return 3;
		}
		void send_command(std::string command)
		{
			sendto(ClientSocket, command.c_str(), command.size(), 0, (SOCKADDR*)&ServerAddress, ServerAddressSize);
		}
		void fillScreen(uint_least16_t color)
		{
			int red = get_red(color);
			int green = get_green(color);
			int blue = get_blue(color);
			std::string command = "clear display: 255, 0, 0.";
			send_command(command);
		}
};

int main()
{
	Display display(400, 300, "127.0.0.1", 1);
	display.fillScreen(0x1111);
	return 0;
}