﻿#include "GraphicsLib.h"
#include <iostream>
#include <windows.h>
#include <mutex>
#pragma comment(lib, "ws2_32.lib")
#pragma warning(disable: 4996)
enum CommandOpcode {
  CLEAR_DISPLAY_OPCODE,
  DRAW_PIXEL_OPCODE,
  DRAW_LINE_OPCODE,
  DRAW_RECTANGLE_OPCODE,
  FILL_RECTANGLE_OPCODE,
  DRAW_ELLIPSE_OPCODE,
  FILL_ELLIPSE_OPCODE,
  DRAW_TEXT_OPCODE,
  SET_ORIENTATION_OPCODE,
  GET_WIDTH_OPCODE,
  GET_HEIGHT_OPCODE,
  LOAD_SPRITE_OPCODE,
  SHOW_SPRITE_OPCODE
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
  std::vector<uint8_t> receiveResponse(size_t expectedSize) {
    std::vector<uint8_t> buffer(expectedSize);
    int receivedBytes = recv(clientSocket, reinterpret_cast<char*>(buffer.data()), expectedSize, 0);
    if (receivedBytes != expectedSize) {
      throw std::runtime_error("Failed to receive complete response from server");
    }
    return buffer;
  }
  void setOrientation(int_least16_t orientation) {
    if (orientation != 0 && orientation != 90 && orientation != 180 && orientation != 270) {
      throw std::invalid_argument("Invalid orientation value");
    }
    std::vector<uint8_t> command = { SET_ORIENTATION_OPCODE };
    command.push_back((orientation >> 8) & 0xFF);
    command.push_back(orientation & 0xFF);
    sendCommand(command);
  }
  uint16_t getWidth() {
    std::vector<uint8_t> command = { GET_WIDTH_OPCODE };
    sendCommand(command);
    std::vector<uint8_t> response = receiveResponse(3);
    if (response[0] != GET_WIDTH_OPCODE) {
      throw std::runtime_error("Invalid response opcode for GET_WIDTH");
    }
    return (response[1] << 8) | response[2];
  }
  uint16_t getHeight() {
    std::vector<uint8_t> command = { GET_HEIGHT_OPCODE };
    sendCommand(command);
    std::vector<uint8_t> response = receiveResponse(3);
    if (response[0] != GET_HEIGHT_OPCODE) {
      throw std::runtime_error("Invalid response opcode for GET_HEIGHT");
    }
    return (response[1] << 8) | response[2];
  }
  void drawPixel(int_least16_t x0, int_least16_t y0, uint_least16_t color) override {
    std::vector<uint8_t> command = { DRAW_PIXEL_OPCODE };
    addCoordinatesToCommand(command, x0, y0);
    addColorToCommand(command, color);
    sendCommand(command);
  }
  void loadSprite(uint16_t index, uint16_t width, uint16_t height, const std::vector<uint8_t> &data) {
    if (data.size() != width * height * 3) {
      throw std::invalid_argument("Sprite data size does not match specified dimensions.");
    }
    std::vector<uint8_t> command = { LOAD_SPRITE_OPCODE };
    command.push_back((index >> 8) & 0xFF);
    command.push_back(index & 0xFF);
    command.push_back((width >> 8) & 0xFF);
    command.push_back(width & 0xFF);
    command.push_back((height >> 8) & 0xFF);
    command.push_back(height & 0xFF);
    command.insert(command.end(), data.begin(), data.end());
    sendCommand(command);
  }
  void showSprite(uint16_t index, int16_t x, int16_t y) {
    std::vector<uint8_t> command = { SHOW_SPRITE_OPCODE };
    command.push_back((index >> 8) & 0xFF);
    command.push_back(index & 0xFF);
    addCoordinatesToCommand(command, x, y);
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
  void drawText(int16_t x, int16_t y, uint16_t color, const std::string& text, int_least16_t spacing = 19) {
    const int16_t centerX = x;
    const int16_t centerY = y;
    const double radians = orientation * 3.14 / 180.0;
    int16_t currentX = x;
    int16_t currentY = y;
    for (char c : text) {
      int16_t rotatedX = centerX + (currentX - centerX) * cos(radians) - (currentY - centerY) * sin(radians);
      int16_t rotatedY = centerY + (currentX - centerX) * sin(radians) + (currentY - centerY) * cos(radians);
      std::vector<uint8_t> command = { DRAW_TEXT_OPCODE };
      command.push_back(rotatedX >> 8);
      command.push_back(rotatedX & 0xFF);
      command.push_back(rotatedY >> 8);
      command.push_back(rotatedY & 0xFF);
      command.push_back(color >> 8);
      command.push_back(color & 0xFF);
      command.push_back(c);
      sendCommand(command);
      currentX += spacing;
    }
  }
  void animateCircle(GraphicsLib& display) {
    const int radius = 20;
    int width = display.getWidth();
    int height = display.getHeight();
    for (int i = 0; i < width; ++i) {
      display.fillScreen(toRGB565(255, 255, 255));
      display.fillEllipse(i, height / 2, radius, radius, toRGB565(255, 0, 0));
      Sleep(20);
    }
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
  const int_least16_t radius = 50;
  const int_least16_t spacing = 100;
  const int_least16_t boxWidth = radius * 2;
  const int_least16_t boxHeight = spacing * 3;
  const int_least16_t boxX = centerX - boxWidth / 2;
  const int_least16_t boxY = centerY - spacing - radius;
  display.fillRect(boxX, boxY, boxWidth, boxHeight, toRGB565(123, 50, 50));
  const int_least16_t poleWidth = 20;
  const int_least16_t poleHeight = 200;
  const int_least16_t poleX = centerX - poleWidth / 2;
  const int_least16_t poleY = boxY + boxHeight;
  display.fillRect(poleX, poleY, poleWidth, poleHeight, toRGB565(10, 0, 10));
  while (true) {
    display.fillEllipse(centerX, centerY - spacing, radius, radius, toRGB565(255, 0, 0));
    display.fillEllipse(centerX, centerY, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + spacing, radius, radius, toRGB565(0, 0, 0));
    Sleep(2000);
    display.fillEllipse(centerX, centerY - spacing, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY, radius, radius, toRGB565(255, 255, 0));
    display.fillEllipse(centerX, centerY + spacing, radius, radius, toRGB565(0, 0, 0));
    Sleep(1000);
    display.fillEllipse(centerX, centerY - spacing, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY, radius, radius, toRGB565(0, 0, 0));
    display.fillEllipse(centerX, centerY + spacing, radius, radius, toRGB565(0, 255, 0));
    Sleep(2000);
  }
}
std::mutex displayMutex;
void spriteAnimation(GraphicsLib& display) {
  std::vector<uint8_t> spriteData(16 * 16 * 3, 0);
  for (int y = 0; y < 16; ++y) {
    for (int x = 0; x < 16; ++x) {
      int dx = x - 8;
      int dy = y - 8;
      if (dx * dx + dy * dy <= 64) {
        spriteData[(y * 16 + x) * 3] = 105;
        spriteData[(y * 16 + x) * 3 + 1] = 105;
        spriteData[(y * 16 + x) * 3 + 2] = 105;
        if (dx * dx + dy * dy <= 16) {
          spriteData[(y * 16 + x) * 3] = 255;
          spriteData[(y * 16 + x) * 3 + 1] = 255;
          spriteData[(y * 16 + x) * 3 + 2] = 255;
        }
      }
    }
  }
  display.loadSprite(1, 16, 16, spriteData);
  std::vector<std::vector<uint8_t>> explosionFrames(5, std::vector<uint8_t>(16 * 16 * 3, 0));
  for (int i = 0; i < 5; ++i) {
    for (int y = 0; y < 16; ++y) {
      for (int x = 0; x < 16; ++x) {
        int dx = x - 8;
        int dy = y - 8;
        int distance = dx * dx + dy * dy;
        if (distance <= (8 + i * 2) * (8 + i * 2)) {
          explosionFrames[i][(y * 16 + x) * 3] = 255 - i * 50;
          explosionFrames[i][(y * 16 + x) * 3 + 1] = 255 - i * 50;
          explosionFrames[i][(y * 16 + x) * 3 + 2] = 0;
        }
      }
    }
  }
  const int_least16_t startX = 800 / 2 - 8;
  const int_least16_t startY = 600 / 2 - 8;
  int currentX = startX;
  int currentY = startY;
  int dx = 10;
  int dy = 10;
  display.setOrientation(0);
  int textX = 800;
  int textY = 200;
  uint8_t colorShift = 0;
  while (true) {
    {
      std::lock_guard<std::mutex> lock(displayMutex);
      display.fillScreen(toRGB565(0, 0, 0));
      display.showSprite(1, currentX, currentY);
      display.drawText(textX, textY, toRGB565(colorShift, 255 - colorShift, colorShift), "HELLO", 30);
    }
    currentX += dx;
    currentY += dy;
    bool collision = false;
    if (currentX <= 0) {
      dx = -dx;
      currentX = 0;
      collision = true;
    }
    if (currentX >= 640) {
      dx = -dx;
      currentX = 640;
      collision = true;
    }
    if (currentY <= 0) {
      dy = -dy;
      currentY = 0;
      collision = true;
    }
    if (currentY >= 400) {
      dy = -dy;
      currentY = 400;
      collision = true;
    }
    if (collision) {
      for (const auto& frame : explosionFrames) {
        std::lock_guard<std::mutex> lock(displayMutex);
        display.loadSprite(2, 16, 16, frame);
        display.showSprite(2, currentX, currentY);
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
      }
    }
    textX -= 5;
    if (textX < -300) textX = 800;
    colorShift += 5;
    if (colorShift > 255) colorShift = 0;
    std::this_thread::sleep_for(std::chrono::milliseconds(50));
  }
}
int main() {
  try {
    DisplayClient display(800, 600, "127.0.0.1", 1);
    display.fillScreen(toRGB565(255, 255, 255));
    std::thread spriteAnimationThread(spriteAnimation, std::ref(display));
    spriteAnimationThread.join();
  }
  catch (const std::exception& e) {
    std::cerr << "Exception: " << e.what() << std::endl;
  }
  return 0;
}
