using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
  internal class Program
  {
    public class Color
    {
      public Byte Red, Green, Blue;
    }
    public class ClearDisplay
    {
      public Color Color1 = new Color();
    }
    public class DrawPixel
    {
      public Int16 X, Y;
      public Color Color2 = new Color();
    }
    public class DrawLine
    {
      public Int16 X1, Y1, X2, Y2;
      public Color Color3 = new Color();
    }
    public class DrawRectangle
    {
      public Int16 X, Y, W, H;
      public Color Color4 = new Color();
    }
    public class FillRectangle
    {
      public Int16 X, Y, W, H;
      public Color Color5 = new Color();
    }
    public class DrawEllipse
    {
      public Int16 X, Y, RadiusX, RadiusY;
      public Color Color6 = new Color();
    }
    public class FillEllipse
    {
      public Int16 X, Y, RadiusX, RadiusY;
      public Color Color7 = new Color();
    }
    public class DrawCircle
    {
      public Int16 X, Y, Radius;
      public Color Color8 = new Color();
    }
    public class FillCircle
    {
      public Int16 X, Y, Radius;
      public Color Color9 = new Color();
    }
    public class DrawRoundedRectangle
    {
      public Int16 X, Y, W, H, Radius;
      public Color Color10 = new Color();
    }
    public class FillRoundedRectangle
    {
      public Int16 X, Y, W, H, Radius;
      public Color Color11 = new Color();
    }
    public class DrawText
    {
      public Int16 X, Y, Length;
      public String Font, Text;
      public Color Color12 = new Color();
    }
    public class DrawImage
    {
      public Int32 X, Y, W, H;
      public String Data;
    }

    public static void Parser(String Message)
    {
      string Pattern1 = @"([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])";
      string Pattern2 = $@"{Pattern1}\s+{Pattern1}\s+{Pattern1}";
      Regex Regex1 = new Regex($@"\s*clear\s+display\s*:\s*{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex2 = new Regex($@"\s*draw\s*pixel\s*:\s*(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex3 = new Regex($@"\s*draw\s*line\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex4 = new Regex($@"\s*draw\s*rectangle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex5 = new Regex($@"\s*fill\s*rectangle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex6 = new Regex($@"\s*draw\s*ellipse\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex7 = new Regex($@"\s*fill\s*ellipse\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex8 = new Regex($@"\s*draw\s*circle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex9 = new Regex($@"\s*fill\s*circle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex10 = new Regex($@"\s*draw\s*rounded\s*rectangle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex11 = new Regex($@"\s*fill\s*rounded\s*rectangle\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex12 = new Regex($@"\s*draw\s*text\s*:\s*(\d+)\s+(\d+)\s+arial\s+(\d+)\s+(\w+)\s+{Pattern2}\s*$", RegexOptions.IgnoreCase);
      Regex Regex13 = new Regex(@"\s*draw\s*image\s*:\s*(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+([01]+)\s*$", RegexOptions.IgnoreCase);

      Match Match1;

      if ((Match1 = Regex1.Match(Message)).Success)
      {
        ClearDisplay ClearDisplay1 = new ClearDisplay();
        ClearDisplay1.Color1.Red = Byte.Parse(Match1.Groups[1].Value);
        ClearDisplay1.Color1.Green = Byte.Parse(Match1.Groups[2].Value);
        ClearDisplay1.Color1.Blue = Byte.Parse(Match1.Groups[3].Value);

        Console.Write("Command: Clear Display.\n" +
                      "Parameter:\n" +
                      "Color.Red = " + ClearDisplay1.Color1.Red + ";\n" +
                      "Color.Green = " + ClearDisplay1.Color1.Green + ";\n" +
                      "Color.Blue = " + ClearDisplay1.Color1.Blue + ".\n\n");
      }
      else if ((Match1 = Regex2.Match(Message)).Success)
      {
        DrawPixel DrawPixel1 = new DrawPixel();
        DrawPixel1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawPixel1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawPixel1.Color2.Red = Byte.Parse(Match1.Groups[3].Value);
        DrawPixel1.Color2.Green = Byte.Parse(Match1.Groups[4].Value);
        DrawPixel1.Color2.Blue = Byte.Parse(Match1.Groups[5].Value);

        Console.Write("Command: Draw Pixel.\n" +
                      "Parameter:\n" +
                      "X = " + DrawPixel1.X + ";\n" +
                      "Y = " + DrawPixel1.Y + ";\n" +
                      "Color.Red = " + DrawPixel1.Color2.Red + ";\n" +
                      "Color.Green = " + DrawPixel1.Color2.Green + ";\n" +
                      "Color.Blue = " + DrawPixel1.Color2.Blue + ".\n\n");
      }
      else if ((Match1 = Regex3.Match(Message)).Success)
      {
        DrawLine DrawLine1 = new DrawLine();
        DrawLine1.X1 = Int16.Parse(Match1.Groups[1].Value);
        DrawLine1.Y1 = Int16.Parse(Match1.Groups[2].Value);
        DrawLine1.X2 = Int16.Parse(Match1.Groups[3].Value);
        DrawLine1.Y2 = Int16.Parse(Match1.Groups[4].Value);
        DrawLine1.Color3.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawLine1.Color3.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawLine1.Color3.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Draw Line.\n" +
                      "Parameter:\n" +
                      "X1 = " + DrawLine1.X1 + ";\n" +
                      "Y1 = " + DrawLine1.Y1 + ";\n" +
                      "X2 = " + DrawLine1.X2 + ";\n" +
                      "Y2 = " + DrawLine1.Y2 + ";\n" +
                      "Color.Red = " + DrawLine1.Color3.Red + ";\n" +
                      "Color.Green = " + DrawLine1.Color3.Green + ";\n" +
                      "Color.Blue = " + DrawLine1.Color3.Blue + ".\n\n");
      }
      else if ((Match1 = Regex4.Match(Message)).Success)
      {
        DrawRectangle DrawRectangle1 = new DrawRectangle();
        DrawRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        DrawRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        DrawRectangle1.Color4.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawRectangle1.Color4.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawRectangle1.Color4.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Draw Rectangle.\n" +
                      "Parameter:\n" +
                      "X = " + DrawRectangle1.X + ";\n" +
                      "Y = " + DrawRectangle1.Y + ";\n" +
                      "W = " + DrawRectangle1.W + ";\n" +
                      "H = " + DrawRectangle1.H + ";\n" +
                      "Color.Red = " + DrawRectangle1.Color4.Red + ";\n" +
                      "Color.Green = " + DrawRectangle1.Color4.Green + ";\n" +
                      "Color.Blue = " + DrawRectangle1.Color4.Blue + ".\n\n");
      }
      else if ((Match1 = Regex5.Match(Message)).Success)
      {
        FillRectangle FillRectangle1 = new FillRectangle();
        FillRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        FillRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        FillRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        FillRectangle1.Color5.Red = Byte.Parse(Match1.Groups[5].Value);
        FillRectangle1.Color5.Green = Byte.Parse(Match1.Groups[6].Value);
        FillRectangle1.Color5.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Fill Rectangle.\n" +
                      "Parameter:\n" +
                      "X = " + FillRectangle1.X + ";\n" +
                      "Y = " + FillRectangle1.Y + ";\n" +
                      "W = " + FillRectangle1.W + ";\n" +
                      "H = " + FillRectangle1.H + ";\n" +
                      "Color.Red = " + FillRectangle1.Color5.Red + ";\n" +
                      "Color.Green = " + FillRectangle1.Color5.Green + ";\n" +
                      "Color.Blue = " + FillRectangle1.Color5.Blue + ".\n\n");
      }
      else if ((Match1 = Regex6.Match(Message)).Success)
      {
        DrawEllipse DrawEllipse1 = new DrawEllipse();
        DrawEllipse1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawEllipse1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawEllipse1.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        DrawEllipse1.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        DrawEllipse1.Color6.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawEllipse1.Color6.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawEllipse1.Color6.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Draw Ellipse.\n" +
                      "Parameter:\n" +
                      "X = " + DrawEllipse1.X + ";\n" +
                      "Y = " + DrawEllipse1.Y + ";\n" +
                      "W = " + DrawEllipse1.RadiusX + ";\n" +
                      "H = " + DrawEllipse1.RadiusX + ";\n" +
                      "Color.Red = " + DrawEllipse1.Color6.Red + ";\n" +
                      "Color.Green = " + DrawEllipse1.Color6.Green + ";\n" +
                      "Color.Blue = " + DrawEllipse1.Color6.Blue + ".\n\n");
      }
      else if ((Match1 = Regex7.Match(Message)).Success)
      {
        FillEllipse FillEllipse1 = new FillEllipse();
        FillEllipse1.X = Int16.Parse(Match1.Groups[1].Value);
        FillEllipse1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillEllipse1.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        FillEllipse1.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        FillEllipse1.Color7.Red = Byte.Parse(Match1.Groups[5].Value);
        FillEllipse1.Color7.Green = Byte.Parse(Match1.Groups[6].Value);
        FillEllipse1.Color7.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Fill Ellipse.\n" +
                      "Parameter:\n" +
                      "X = " + FillEllipse1.X + ";\n" +
                      "Y = " + FillEllipse1.Y + ";\n" +
                      "W = " + FillEllipse1.RadiusX + ";\n" +
                      "H = " + FillEllipse1.RadiusX + ";\n" +
                      "Color.Red = " + FillEllipse1.Color7.Red + ";\n" +
                      "Color.Green = " + FillEllipse1.Color7.Green + ";\n" +
                      "Color.Blue = " + FillEllipse1.Color7.Blue + ".\n\n");
      }
      else if ((Match1 = Regex8.Match(Message)).Success)
      {
        DrawCircle DrawCircle1 = new DrawCircle();
        DrawCircle1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawCircle1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawCircle1.Radius = Int16.Parse(Match1.Groups[3].Value);
        DrawCircle1.Color8.Red = Byte.Parse(Match1.Groups[4].Value);
        DrawCircle1.Color8.Green = Byte.Parse(Match1.Groups[5].Value);
        DrawCircle1.Color8.Blue = Byte.Parse(Match1.Groups[6].Value);

        Console.Write("Command: Draw Circle.\n" +
                      "Parameter:\n" +
                      "X = " + DrawCircle1.X + ";\n" +
                      "Y = " + DrawCircle1.Y + ";\n" +
                      "Radius = " + DrawCircle1.Radius + ";\n" +
                      "Color.Red = " + DrawCircle1.Color8.Red + ";\n" +
                      "Color.Green = " + DrawCircle1.Color8.Green + ";\n" +
                      "Color.Blue = " + DrawCircle1.Color8.Blue + ".\n\n");
      }
      else if ((Match1 = Regex9.Match(Message)).Success)
      {
        FillCircle FillCircle1 = new FillCircle();
        FillCircle1.X = Int16.Parse(Match1.Groups[1].Value);
        FillCircle1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillCircle1.Radius = Int16.Parse(Match1.Groups[3].Value);
        FillCircle1.Color9.Red = Byte.Parse(Match1.Groups[4].Value);
        FillCircle1.Color9.Green = Byte.Parse(Match1.Groups[5].Value);
        FillCircle1.Color9.Blue = Byte.Parse(Match1.Groups[6].Value);

        Console.Write("Command: Fill Circle.\n" +
                      "Parameter:\n" +
                      "X = " + FillCircle1.X + ";\n" +
                      "Y = " + FillCircle1.Y + ";\n" +
                      "Radius = " + FillCircle1.Radius + ";\n" +
                      "Color.Red = " + FillCircle1.Color9.Red + ";\n" +
                      "Color.Green = " + FillCircle1.Color9.Green + ";\n" +
                      "Color.Blue = " + FillCircle1.Color9.Blue + ".\n\n");
      }
      else if ((Match1 = Regex10.Match(Message)).Success)
      {
        DrawRoundedRectangle DrawRoundedRectangle1 = new DrawRoundedRectangle();
        DrawRoundedRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawRoundedRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawRoundedRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        DrawRoundedRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        DrawRoundedRectangle1.Radius = Int16.Parse(Match1.Groups[5].Value);
        DrawRoundedRectangle1.Color10.Red = Byte.Parse(Match1.Groups[6].Value);
        DrawRoundedRectangle1.Color10.Green = Byte.Parse(Match1.Groups[7].Value);
        DrawRoundedRectangle1.Color10.Blue = Byte.Parse(Match1.Groups[8].Value);

        Console.Write("Command: Draw Rounded Rectangle.\n" +
                      "Parameter:\n" +
                      "X = " + DrawRoundedRectangle1.X + ";\n" +
                      "Y = " + DrawRoundedRectangle1.Y + ";\n" +
                      "W = " + DrawRoundedRectangle1.W + ";\n" +
                      "H = " + DrawRoundedRectangle1.H + ";\n" +
                      "Radius = " + DrawRoundedRectangle1.Radius + ";\n" +
                      "Color.Red = " + DrawRoundedRectangle1.Color10.Red + ";\n" +
                      "Color.Green = " + DrawRoundedRectangle1.Color10.Green + ";\n" +
                      "Color.Blue = " + DrawRoundedRectangle1.Color10.Blue + ".\n\n");
      }
      else if ((Match1 = Regex11.Match(Message)).Success)
      {
        FillRoundedRectangle FillRoundedRectangle1 = new FillRoundedRectangle();
        FillRoundedRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        FillRoundedRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillRoundedRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        FillRoundedRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        FillRoundedRectangle1.Radius = Int16.Parse(Match1.Groups[5].Value);
        FillRoundedRectangle1.Color11.Red = Byte.Parse(Match1.Groups[6].Value);
        FillRoundedRectangle1.Color11.Green = Byte.Parse(Match1.Groups[7].Value);
        FillRoundedRectangle1.Color11.Blue = Byte.Parse(Match1.Groups[8].Value);

        Console.Write("Command: Fill Rounded Rectangle.\n" +
                      "Parameter:\n" +
                      "X = " + FillRoundedRectangle1.X + ";\n" +
                      "Y = " + FillRoundedRectangle1.Y + ";\n" +
                      "W = " + FillRoundedRectangle1.W + ";\n" +
                      "H = " + FillRoundedRectangle1.H + ";\n" +
                      "Radius = " + FillRoundedRectangle1.Radius + ";\n" +
                      "Color.Red = " + FillRoundedRectangle1.Color11.Red + ";\n" +
                      "Color.Green = " + FillRoundedRectangle1.Color11.Green + ";\n" +
                      "Color.Blue = " + FillRoundedRectangle1.Color11.Blue + ".\n\n");
      }
      else if ((Match1 = Regex12.Match(Message)).Success)
      {
        DrawText DrawText1 = new DrawText();
        DrawText1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawText1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawText1.Font = "Arial";
        DrawText1.Length = Int16.Parse(Match1.Groups[3].Value);
        DrawText1.Text = Match1.Groups[4].Value;
        DrawText1.Color12.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawText1.Color12.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawText1.Color12.Blue = Byte.Parse(Match1.Groups[7].Value);

        Console.Write("Command: Draw Text.\n" +
                      "Parameter:\n" +
                      "X = " + DrawText1.X + ";\n" +
                      "Y = " + DrawText1.Y + ";\n" +
                      "Font = " + DrawText1.Font + ";\n" +
                      "Length = " + DrawText1.Length + ";\n" +
                      "Text = " + DrawText1.Text + ";\n" +
                      "Color.Red = " + DrawText1.Color12.Red + ";\n" +
                      "Color.Green = " + DrawText1.Color12.Green + ";\n" +
                      "Color.Blue = " + DrawText1.Color12.Blue + ".\n\n");
      }
      else if ((Match1 = Regex13.Match(Message)).Success)
      {
        DrawImage DrawImage1 = new DrawImage();
        DrawImage1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawImage1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawImage1.W = Int16.Parse(Match1.Groups[3].Value);
        DrawImage1.H = Int16.Parse(Match1.Groups[4].Value);
        DrawImage1.Data = Match1.Groups[5].Value;

        Console.Write("Command: Draw Image.\n" +
                      "Parameter:\n" +
                      "X = " + DrawImage1.X + ";\n" +
                      "Y = " + DrawImage1.Y + ";\n" +
                      "W = " + DrawImage1.W + ";\n" +
                      "H = " + DrawImage1.H + ";\n" +
                      "Data = " + DrawImage1.Data + ".\n\n");
      }
      else
      {
        Console.WriteLine("Error.");
      }
    }

    static void Main()
    {
      while (true)
      {
        Console.Write("Enter: ");
        String Message = Console.ReadLine();
        Parser(Message);
      }
    }
  }
}
