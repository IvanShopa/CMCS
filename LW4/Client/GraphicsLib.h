#ifndef GraphicsLib_h
	#define GraphicsLib_h
	#include <stdint.h>
	#ifndef RGB
		#define RGB(r, g, b) (((r & 0xF8) << 8) | ((g & 0xFC) << 3) | ((b & 0xF8) >> 3))
	#endif
	class GraphicsLib
	{
		public:
			GraphicsLib(uint_least16_t w, uint_least16_t h) : width(w), height(h) {};
			GraphicsLib() : width(0), height(0) {};

			int_least16_t getWidth(void) { return width; };
			int_least16_t getHeight(void) { return height; };

			virtual void fillScreen(uint_least16_t color) = 0;
		private:
			int_least16_t width, height;
	};
#endif