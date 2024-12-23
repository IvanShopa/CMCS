﻿#include "GraphicsLib.h"
#include <iostream>
#include <vector>
#include <windows.h>
#pragma comment(lib, "ws2_32.lib")
#pragma warning(disable: 4996)
enum CommandOpcode {
  CLEAR_DISPLAY_OPCODE,
  DRAW_PIXEL_OPCODE,
  DRAW_LINE_OPCODE,
  DRAW_RECTANGLE_OPCODE,
  FILL_RECTANGLE_OPCODE,
  DRAW_ELLIPSE_OPCODE,
  FILL_ELLIPSE_OPCODE
};
class DisplayClient : public GraphicsLib {
public:
  DisplayClient(uint_least16_t w, uint_least16_t h, const std::string& ipAddress, uint16_t port) : GraphicsLib(w, h), ipAddress(ipAddress), port(port) {
    initSocket();
  }
  ~DisplayClient() {
    closesocket(clientSocket);
    WSACleanup();
  }
  void fillScreen(uint_least16_t color) override {
    std::vector<uint8_t> command = { CLEAR_DISPLAY_OPCODE };
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void drawPixel(int_least16_t x0, int_least16_t y0, uint_least16_t color) override {
    std::vector<uint8_t> command = { DRAW_PIXEL_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void drawLine(int_least16_t x0, int_least16_t y0, int_least16_t x1, int_least16_t y1, uint_least16_t color) override {
    std::vector<uint8_t> command = { DRAW_LINE_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addCoordinatesToCommand(command, x1, y1);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void drawRect(int_least16_t x0, int_least16_t y0, int_least16_t w, int_least16_t h, uint_least16_t color) override {
    std::vector<uint8_t> command = { DRAW_RECTANGLE_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addCoordinatesToCommand(command, x0 + w, y0 + h);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void fillRect(int_least16_t x0, int_least16_t y0, int_least16_t w, int_least16_t h, uint_least16_t color) override {
    std::vector<uint8_t> command = { FILL_RECTANGLE_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addCoordinatesToCommand(command, x0 + w, y0 + h);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void drawEllipse(int_least16_t x0, int_least16_t y0, int_least16_t r_x, int_least16_t r_y, uint_least16_t color) override {
    std::vector<uint8_t> command = { DRAW_ELLIPSE_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addCoordinatesToCommand(command, r_x, r_y);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void fillEllipse(int_least16_t x0, int_least16_t y0, int_least16_t r_x, int_least16_t r_y, uint_least16_t color) override {
    std::vector<uint8_t> command = { FILL_ELLIPSE_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addCoordinatesToCommand(command, r_x, r_y);
    addColorToCommand(command, color);
    sendCommand(command);
  }
private:
  SOCKET clientSocket;
  sockaddr_in serverAddr;
  std::string ipAddress;
  uint16_t port;
  void initSocket() {
    WSAData wsaData;
    WORD DLLVersion = MAKEWORD(2, 2);
    if (WSAStartup(DLLVersion, &wsaData) != 0) {
      throw std::runtime_error("Error initializing WinSock");
    }
    clientSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    if (clientSocket == INVALID_SOCKET) {
      WSACleanup();
      throw std::runtime_error("Error creating socket");
    }
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_port = htons(port);
    serverAddr.sin_addr.s_addr = inet_addr(ipAddress.c_str());
  }
  void sendCommand(const std::vector<uint8_t>& command) {
    sendto(clientSocket, (char*)command.data(), command.size(), 0, (sockaddr*)&serverAddr, sizeof(serverAddr));
  }
  void addColorToCommand(std::vector<uint8_t>& command, uint16_t color) {
    command.push_back((color >> 8) & 0xFF);
    command.push_back(color & 0xFF);
  }
  void addCoordinatesToCommand(std::vector<uint8_t>& command, int16_t x, int16_t y) {
    command.push_back((x >> 8) & 0xFF);
    command.push_back(x & 0xFF);
    command.push_back((y >> 8) & 0xFF);
    command.push_back(y & 0xFF);
  }
};
void displayTrafficLight(GraphicsLib& display) {
  const int_least16_t centerX = display.getWidth() / 2;
  const int_least16_t centerY = display.getHeight() / 2;
  const int_least16_t radius = 40;
  const int_least16_t spacing = 100;
  const int_least16_t boxWidth = radius * 3;
  const int_least16_t boxHeight = spacing * 3;
  const int_least16_t boxX = centerX - boxWidth / 2;
  const int_least16_t boxY = centerY - spacing - radius;
  display.fillRect(boxX, boxY, boxWidth, boxHeight, toRGB565(150, 150, 150));
  const int_least16_t poleWidth = 30;
  const int_least16_t poleHeight = 200;
  const int_least16_t poleX = centerX - poleWidth / 2;
  const int_least16_t poleY = boxY + boxHeight;
  display.fillRect(poleX, poleY, poleWidth, poleHeight, toRGB565(150, 0, 0));
  while (true) {
    display.fillEllipse(centerX, centerY - spacing + 10, radius, radius, toRGB565(255, 0, 0));
    display.fillEllipse(centerX, centerY + 10, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + spacing + 10, radius, radius, toRGB565(0, 0, 0));
    Sleep(2000);
    display.fillEllipse(centerX, centerY - spacing + 10, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + 10, radius, radius, toRGB565(255, 255, 0));
    display.fillEllipse(centerX, centerY + spacing + 10, radius, radius, toRGB565(0, 0, 0));
    Sleep(2000);
    display.fillEllipse(centerX, centerY - spacing + 10, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + 10, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + spacing + 10, radius, radius, toRGB565(0, 255, 0));
    Sleep(2000);
  }
}
int main() {
  try {
    DisplayClient display(800, 600, "127.0.0.1", 1);
    display.fillScreen(toRGB565(255, 255, 255));
    displayTrafficLight(display);
  }
  catch (const std::exception& e) {
    std::cerr << "Exception: " << e.what() << std::endl;
  }
  return 0;
}
