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
      return (color >> 8) & 0xf8;
    }
    int get_green(uint_least16_t color)
    {
      return (color >> 3) & 0xfc;
    }
    int get_blue(uint_least16_t color)
    {
      return (color << 3) & 0xf8;
    }
    void send_command(std::string command)
    {
      sendto(
        ClientSocket,
        command.c_str(),
        command.size(), 0,
        (SOCKADDR*)&ServerAddress,
        ServerAddressSize
      );
    }

    void fillScreen(
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "clear display: " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    void drawPixel(
      int_least16_t x0,
      int_least16_t y0,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw pixel: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual void drawLine(
      int_least16_t x0,
      int_least16_t y0,
      int_least16_t x1,
      int_least16_t y1,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw line: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(x1) + ", " +
                            std::to_string(y1) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual void drawRect(
      int_least16_t x0,
      int_least16_t y0,
      int_least16_t w,
      int_least16_t h,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw rectangle: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(w) + ", " +
                            std::to_string(h) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual void fillRect(
      int_least16_t x0,
      int_least16_t y0,
      int_least16_t w,
      int_least16_t h,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "fill rectangle: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(w) + ", " +
                            std::to_string(h) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual void drawEllipse(
      int_least16_t x0,
      int_least16_t y0,
      int_least16_t r_x,
      int_least16_t r_y,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw ellipse: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(r_x) + ", " +
                            std::to_string(r_y) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual void fillEllipse(
      int_least16_t x0,
      int_least16_t y0,
      int_least16_t r_x,
      int_least16_t r_y,
      uint_least16_t color
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "fill ellipse: " +
                            std::to_string(x0) + ", " +
                            std::to_string(y0) + ", " +
                            std::to_string(r_x) + ", " +
                            std::to_string(r_y) + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
    }
    virtual int_least16_t drawChar(
      int_least16_t x,
      int_least16_t y,
      char c,
      uint_least16_t color,
      uint_least16_t bg,
      uint_least8_t size
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw text: " +
                            std::to_string(x) + ", " +
                            std::to_string(y) + ", " +
                            "arial" + ", " +
                            std::to_string(bg) + ", " +
                            // ??? uint_least8_t size ???
                            c + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
      return 0;
    }
    virtual int_least16_t drawText(
      int_least16_t x,
      int_least16_t y,
      const char* s,
      uint_least16_t color,
      uint_least16_t bg,
      uint_least8_t size
    )
    {
      int red = get_red(color);
      int green = get_green(color);
      int blue = get_blue(color);
      std::string command = "draw text: " +
                            std::to_string(x) + ", " +
                            std::to_string(y) + ", " +
                            "arial" + ", " +
                            std::to_string(bg) + ", " +
                            // ??? uint_least8_t size ???
                            s + ", " +
                            std::to_string(red) + ", " +
                            std::to_string(green) + ", " +
                            std::to_string(blue) + ".";
      send_command(command);
      return 0;
    }
    virtual void loadSprite( // ???
      uint_least8_t index,
      int_least16_t width,
      int_least16_t height,
      char* data
    )
    {

    }
    virtual void showSprite( // ???
      uint_least8_t index,
      uint_least16_t x,
      uint_least16_t y
    )
    {

    }
};

int main()
{
  Display display(400, 300, "127.0.0.1", 1);
  // display.fillScreen(0x1111);
  // display.drawPixel(768, 152, 0x1111);
  // display.drawLine(672, 304, 864, 456, 0x1111);
  // display.drawRect(96, 76, 192, 152, 0x1111);
  // display.fillRect(96, 76, 192, 152, 0x1111);
  // display.drawEllipse(480, 608, 96, 76, 0x1111);
  // display.fillEllipse(480, 836, 96, 76, 0x1111);
  // display.drawChar(672, 532, 'A', 0x1111, 70, 0);
  display.drawText(672, 532, "Hello", 0x1111, 70, 0);
  return 0;
}
