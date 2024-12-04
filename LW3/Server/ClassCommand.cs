using System;

namespace Server
{
  internal class ClassCommand
  {
    public class Command { }
    public class Color
    {
      public Byte Red, Green, Blue;
    }
    public class ClearDisplay : Command
    {
      public String Name;
      public Color color = new Color();
    }
    public class DrawPixel : Command
    {
      public String Name;
      public Int16 X, Y;
      public Color color = new Color();
    }
    public class DrawLine : Command
    {
      public String Name;
      public Int16 X1, Y1, X2, Y2;
      public Color color = new Color();
    }
    public class DrawRectangle : Command
    {
      public String Name;
      public Int16 X, Y, W, H;
      public Color color = new Color();
    }
    public class FillRectangle : Command
    {
      public String Name;
      public Int16 X, Y, W, H;
      public Color color = new Color();
    }
    public class DrawEllipse : Command
    {
      public String Name;
      public Int16 X, Y, RadiusX, RadiusY;
      public Color color = new Color();
    }
    public class FillEllipse : Command
    {
      public String Name;
      public Int16 X, Y, RadiusX, RadiusY;
      public Color color = new Color();
    }
    public class DrawCircle : Command
    {
      public String Name;
      public Int16 X, Y, Radius;
      public Color color = new Color();
    }
    public class FillCircle : Command
    {
      public String Name;
      public Int16 X, Y, Radius;
      public Color color = new Color();
    }
    public class DrawRoundedRectangle : Command
    {
      public String Name;
      public Int16 X, Y, W, H, Radius;
      public Color color = new Color();
    }
    public class FillRoundedRectangle : Command
    {
      public String Name;
      public Int16 X, Y, W, H, Radius;
      public Color color = new Color();
    }
    public class DrawText : Command
    {
      public String Name;
      public Int16 X, Y, Length;
      public String Font, Text;
      public Color color = new Color();
    }
    public class DrawImage : Command
    {
      public String Name;
      public Int32 X, Y, W, H;
      public String Data;
    }
    public class Error : Command
    {
      public String Text;
    }
  }
}
