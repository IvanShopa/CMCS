using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
  internal class Program
  {
    public class Command { }
    public class Color
    {
      public Byte Red, Green, Blue;
    }
    public class ClearDisplay : Command
    {
      public Color Color1 = new Color();
    }
    public class DrawPixel : Command
    {
      public Int16 X, Y;
      public Color Color2 = new Color();
    }
    public class DrawLine : Command
    {
      public Int16 X1, Y1, X2, Y2;
      public Color Color3 = new Color();
    }
    public class DrawRectangle : Command
    {
      public Int16 X, Y, W, H;
      public Color Color4 = new Color();
    }
    public class FillRectangle : Command
    {
      public Int16 X, Y, W, H;
      public Color Color5 = new Color();
    }
    public class DrawEllipse : Command
    {
      public Int16 X, Y, RadiusX, RadiusY;
      public Color Color6 = new Color();
    }
    public class FillEllipse : Command
    {
      public Int16 X, Y, RadiusX, RadiusY;
      public Color Color7 = new Color();
    }
    public class DrawCircle : Command
    {
      public Int16 X, Y, Radius;
      public Color Color8 = new Color();
    }
    public class FillCircle : Command
    {
      public Int16 X, Y, Radius;
      public Color Color9 = new Color();
    }
    public class DrawRoundedRectangle : Command
    {
      public Int16 X, Y, W, H, Radius;
      public Color Color10 = new Color();
    }
    public class FillRoundedRectangle : Command
    {
      public Int16 X, Y, W, H, Radius;
      public Color Color11 = new Color();
    }
    public class DrawText : Command
    {
      public Int16 X, Y, Length;
      public String Font, Text;
      public Color Color12 = new Color();
    }
    public class DrawImage : Command
    {
      public Int32 X, Y, W, H;
      public String Data;
    }
    public class Error : Command
    {
      public String Text;
    }

    public static Command Function(String Message)
    {
      Regex RegexClearDisplay = new Regex(@"\s*clear\s+display\s*:\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawPixel = new Regex(@"\s*draw\s*pixel\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawLine = new Regex(@"\s*draw\s*line\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRectangle = new Regex(@"\s*draw\s*rectangle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRectangle = new Regex(@"\s*fill\s*rectangle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawEllipse = new Regex(@"\s*draw\s*ellipse\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillEllipse = new Regex(@"\s*fill\s*ellipse\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawCircle = new Regex(@"\s*draw\s*circle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillCircle = new Regex(@"\s*fill\s*circle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRoundedRectangle = new Regex(@"\s*draw\s*rounded\s*rectangle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRoundedRectangle = new Regex(@"\s*fill\s*rounded\s*rectangle\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawText = new Regex(@"\s*draw\s*text\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*arial,\s*(\d+),\s*([\w+\s*]+),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]),\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawImage = new Regex(@"\s*draw\s*image\s*:\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*(-\d+|\d+),\s*([01]+)\s*$", RegexOptions.IgnoreCase);

      Match Match1;

      if ((Match1 = RegexClearDisplay.Match(Message)).Success)
      {
        ClearDisplay ClearDisplay1 = new ClearDisplay();
        ClearDisplay1.Color1.Red = Byte.Parse(Match1.Groups[1].Value);
        ClearDisplay1.Color1.Green = Byte.Parse(Match1.Groups[2].Value);
        ClearDisplay1.Color1.Blue = Byte.Parse(Match1.Groups[3].Value);
        return ClearDisplay1;
      }
      else if ((Match1 = RegexDrawPixel.Match(Message)).Success)
      {
        DrawPixel DrawPixel1 = new DrawPixel();
        DrawPixel1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawPixel1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawPixel1.Color2.Red = Byte.Parse(Match1.Groups[3].Value);
        DrawPixel1.Color2.Green = Byte.Parse(Match1.Groups[4].Value);
        DrawPixel1.Color2.Blue = Byte.Parse(Match1.Groups[5].Value);
        return DrawPixel1;
      }
      else if ((Match1 = RegexDrawLine.Match(Message)).Success)
      {
        DrawLine DrawLine1 = new DrawLine();
        DrawLine1.X1 = Int16.Parse(Match1.Groups[1].Value);
        DrawLine1.Y1 = Int16.Parse(Match1.Groups[2].Value);
        DrawLine1.X2 = Int16.Parse(Match1.Groups[3].Value);
        DrawLine1.Y2 = Int16.Parse(Match1.Groups[4].Value);
        DrawLine1.Color3.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawLine1.Color3.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawLine1.Color3.Blue = Byte.Parse(Match1.Groups[7].Value);
        return DrawLine1;
      }
      else if ((Match1 = RegexDrawRectangle.Match(Message)).Success)
      {
        DrawRectangle DrawRectangle1 = new DrawRectangle();
        DrawRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        DrawRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        DrawRectangle1.Color4.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawRectangle1.Color4.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawRectangle1.Color4.Blue = Byte.Parse(Match1.Groups[7].Value);
        return DrawRectangle1;
      }
      else if ((Match1 = RegexFillRectangle.Match(Message)).Success)
      {
        FillRectangle FillRectangle1 = new FillRectangle();
        FillRectangle1.X = Int16.Parse(Match1.Groups[1].Value);
        FillRectangle1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillRectangle1.W = Int16.Parse(Match1.Groups[3].Value);
        FillRectangle1.H = Int16.Parse(Match1.Groups[4].Value);
        FillRectangle1.Color5.Red = Byte.Parse(Match1.Groups[5].Value);
        FillRectangle1.Color5.Green = Byte.Parse(Match1.Groups[6].Value);
        FillRectangle1.Color5.Blue = Byte.Parse(Match1.Groups[7].Value);
        return FillRectangle1;
      }
      else if ((Match1 = RegexDrawEllipse.Match(Message)).Success)
      {
        DrawEllipse DrawEllipse1 = new DrawEllipse();
        DrawEllipse1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawEllipse1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawEllipse1.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        DrawEllipse1.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        DrawEllipse1.Color6.Red = Byte.Parse(Match1.Groups[5].Value);
        DrawEllipse1.Color6.Green = Byte.Parse(Match1.Groups[6].Value);
        DrawEllipse1.Color6.Blue = Byte.Parse(Match1.Groups[7].Value);
        return DrawEllipse1;
      }
      else if ((Match1 = RegexFillEllipse.Match(Message)).Success)
      {
        FillEllipse FillEllipse1 = new FillEllipse();
        FillEllipse1.X = Int16.Parse(Match1.Groups[1].Value);
        FillEllipse1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillEllipse1.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        FillEllipse1.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        FillEllipse1.Color7.Red = Byte.Parse(Match1.Groups[5].Value);
        FillEllipse1.Color7.Green = Byte.Parse(Match1.Groups[6].Value);
        FillEllipse1.Color7.Blue = Byte.Parse(Match1.Groups[7].Value);
        return FillEllipse1;
      }
      else if ((Match1 = RegexDrawCircle.Match(Message)).Success)
      {
        DrawCircle DrawCircle1 = new DrawCircle();
        DrawCircle1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawCircle1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawCircle1.Radius = Int16.Parse(Match1.Groups[3].Value);
        DrawCircle1.Color8.Red = Byte.Parse(Match1.Groups[4].Value);
        DrawCircle1.Color8.Green = Byte.Parse(Match1.Groups[5].Value);
        DrawCircle1.Color8.Blue = Byte.Parse(Match1.Groups[6].Value);
        return DrawCircle1;
      }
      else if ((Match1 = RegexFillCircle.Match(Message)).Success)
      {
        FillCircle FillCircle1 = new FillCircle();
        FillCircle1.X = Int16.Parse(Match1.Groups[1].Value);
        FillCircle1.Y = Int16.Parse(Match1.Groups[2].Value);
        FillCircle1.Radius = Int16.Parse(Match1.Groups[3].Value);
        FillCircle1.Color9.Red = Byte.Parse(Match1.Groups[4].Value);
        FillCircle1.Color9.Green = Byte.Parse(Match1.Groups[5].Value);
        FillCircle1.Color9.Blue = Byte.Parse(Match1.Groups[6].Value);
        return FillCircle1;
      }
      else if ((Match1 = RegexDrawRoundedRectangle.Match(Message)).Success)
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
        return DrawRoundedRectangle1;
      }
      else if ((Match1 = RegexFillRoundedRectangle.Match(Message)).Success)
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
        return FillRoundedRectangle1;
      }
      else if ((Match1 = RegexDrawText.Match(Message)).Success)
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
        return DrawText1;
      }
      else if ((Match1 = RegexDrawImage.Match(Message)).Success)
      {
        DrawImage DrawImage1 = new DrawImage();
        DrawImage1.X = Int16.Parse(Match1.Groups[1].Value);
        DrawImage1.Y = Int16.Parse(Match1.Groups[2].Value);
        DrawImage1.W = Int16.Parse(Match1.Groups[3].Value);
        DrawImage1.H = Int16.Parse(Match1.Groups[4].Value);
        DrawImage1.Data = Match1.Groups[5].Value;
        return DrawImage1;
      }
      else
      {
        Error Error1 = new Error();
        Error1.Text = " Error\n\n";
        return Error1;
      }
    }

    static void Main()
    {
      while (true)
      {
        Console.Write("Enter: ");
        String Message = Console.ReadLine();

        Console.Write("Result:");
        Command Command1 = Function(Message);
        if (Command1 is ClearDisplay ClearDisplay2)
        {
          Console.Write("\nCommand: Clear Display.\n" +
                        "Parameter:\n" +
                        "Red = " + ClearDisplay2.Color1.Red + ";\n" +
                        "Green = " + ClearDisplay2.Color1.Green + ";\n" +
                        "Blue = " + ClearDisplay2.Color1.Blue + ".\n\n");
        }
        else if (Command1 is DrawPixel DrawPixel2)
        {
          Console.Write("\nCommand: Draw Pixel.\n" +
                        "Parameter:\n" +
                        "X = " + DrawPixel2.X + ";\n" +
                        "Y = " + DrawPixel2.Y + ";\n" +
                        "Red = " + DrawPixel2.Color2.Red + ";\n" +
                        "Green = " + DrawPixel2.Color2.Green + ";\n" +
                        "Blue = " + DrawPixel2.Color2.Blue + ".\n\n");
        }
        else if (Command1 is DrawLine DrawLine2)
        {
          Console.Write("Command: Draw Line.\n" +
                        "Parameter:\n" +
                        "X1 = " + DrawLine2.X1 + ";\n" +
                        "Y1 = " + DrawLine2.Y1 + ";\n" +
                        "X2 = " + DrawLine2.X2 + ";\n" +
                        "Y2 = " + DrawLine2.Y2 + ";\n" +
                        "Red = " + DrawLine2.Color3.Red + ";\n" +
                        "Green = " + DrawLine2.Color3.Green + ";\n" +
                        "Blue = " + DrawLine2.Color3.Blue + ".\n\n");
        }
        else if (Command1 is DrawRectangle DrawRectangle2)
        {
          Console.Write("Command: Draw Rectangle.\n" +
                        "Parameter:\n" +
                        "X = " + DrawRectangle2.X + ";\n" +
                        "Y = " + DrawRectangle2.Y + ";\n" +
                        "W = " + DrawRectangle2.W + ";\n" +
                        "H = " + DrawRectangle2.H + ";\n" +
                        "Red = " + DrawRectangle2.Color4.Red + ";\n" +
                        "Green = " + DrawRectangle2.Color4.Green + ";\n" +
                        "Blue = " + DrawRectangle2.Color4.Blue + ".\n\n");
        }
        else if (Command1 is FillRectangle FillRectangle2)
        {
          Console.Write("Command: Fill Rectangle.\n" +
                        "Parameter:\n" +
                        "X = " + FillRectangle2.X + ";\n" +
                        "Y = " + FillRectangle2.Y + ";\n" +
                        "W = " + FillRectangle2.W + ";\n" +
                        "H = " + FillRectangle2.H + ";\n" +
                        "Red = " + FillRectangle2.Color5.Red + ";\n" +
                        "Green = " + FillRectangle2.Color5.Green + ";\n" +
                        "Blue = " + FillRectangle2.Color5.Blue + ".\n\n");
        }
        else if (Command1 is DrawEllipse DrawEllipse2)
        {
          Console.Write("Command: Draw Ellipse.\n" +
                      "Parameter:\n" +
                      "X = " + DrawEllipse2.X + ";\n" +
                      "Y = " + DrawEllipse2.Y + ";\n" +
                      "W = " + DrawEllipse2.RadiusX + ";\n" +
                      "H = " + DrawEllipse2.RadiusX + ";\n" +
                      "Red = " + DrawEllipse2.Color6.Red + ";\n" +
                      "Green = " + DrawEllipse2.Color6.Green + ";\n" +
                      "Blue = " + DrawEllipse2.Color6.Blue + ".\n\n");
        }
        else if (Command1 is FillEllipse FillEllipse2)
        {
          Console.Write("Command: Fill Ellipse.\n" +
                      "Parameter:\n" +
                      "X = " + FillEllipse2.X + ";\n" +
                      "Y = " + FillEllipse2.Y + ";\n" +
                      "W = " + FillEllipse2.RadiusX + ";\n" +
                      "H = " + FillEllipse2.RadiusX + ";\n" +
                      "Red = " + FillEllipse2.Color7.Red + ";\n" +
                      "Green = " + FillEllipse2.Color7.Green + ";\n" +
                      "Blue = " + FillEllipse2.Color7.Blue + ".\n\n");
        }
        else if (Command1 is DrawCircle DrawCircle2)
        {
          Console.Write("Command: Draw Circle.\n" +
                        "Parameter:\n" +
                        "X = " + DrawCircle2.X + ";\n" +
                        "Y = " + DrawCircle2.Y + ";\n" +
                        "Radius = " + DrawCircle2.Radius + ";\n" +
                        "Red = " + DrawCircle2.Color8.Red + ";\n" +
                        "Green = " + DrawCircle2.Color8.Green + ";\n" +
                        "Blue = " + DrawCircle2.Color8.Blue + ".\n\n");
        }
        else if (Command1 is FillCircle FillCircle2)
        {
          Console.Write("Command: Fill Circle.\n" +
                        "Parameter:\n" +
                        "X = " + FillCircle2.X + ";\n" +
                        "Y = " + FillCircle2.Y + ";\n" +
                        "Radius = " + FillCircle2.Radius + ";\n" +
                        "Red = " + FillCircle2.Color9.Red + ";\n" +
                        "Green = " + FillCircle2.Color9.Green + ";\n" +
                        "Blue = " + FillCircle2.Color9.Blue + ".\n\n");
        }
        else if (Command1 is DrawRoundedRectangle DrawRoundedRectangle2)
        {
          Console.Write("Command: Draw Rounded Rectangle.\n" +
                        "Parameter:\n" +
                        "X = " + DrawRoundedRectangle2.X + ";\n" +
                        "Y = " + DrawRoundedRectangle2.Y + ";\n" +
                        "W = " + DrawRoundedRectangle2.W + ";\n" +
                        "H = " + DrawRoundedRectangle2.H + ";\n" +
                        "Radius = " + DrawRoundedRectangle2.Radius + ";\n" +
                        "Red = " + DrawRoundedRectangle2.Color10.Red + ";\n" +
                        "Green = " + DrawRoundedRectangle2.Color10.Green + ";\n" +
                        "Blue = " + DrawRoundedRectangle2.Color10.Blue + ".\n\n");
        }
        else if (Command1 is FillRoundedRectangle FillRoundedRectangle2)
        {
          Console.Write("Command: Fill Rounded Rectangle.\n" +
                        "Parameter:\n" +
                        "X = " + FillRoundedRectangle2.X + ";\n" +
                        "Y = " + FillRoundedRectangle2.Y + ";\n" +
                        "W = " + FillRoundedRectangle2.W + ";\n" +
                        "H = " + FillRoundedRectangle2.H + ";\n" +
                        "Radius = " + FillRoundedRectangle2.Radius + ";\n" +
                        "Red = " + FillRoundedRectangle2.Color11.Red + ";\n" +
                        "Green = " + FillRoundedRectangle2.Color11.Green + ";\n" +
                        "Blue = " + FillRoundedRectangle2.Color11.Blue + ".\n\n");
        }
        else if (Command1 is DrawText DrawText2)
        {
          Console.Write("Command: Draw Text.\n" +
                        "Parameter:\n" +
                        "X = " + DrawText2.X + ";\n" +
                        "Y = " + DrawText2.Y + ";\n" +
                        "Font = " + DrawText2.Font + ";\n" +
                        "Length = " + DrawText2.Length + ";\n" +
                        "Text = " + DrawText2.Text + ";\n" +
                        "Red = " + DrawText2.Color12.Red + ";\n" +
                        "Green = " + DrawText2.Color12.Green + ";\n" +
                        "Blue = " + DrawText2.Color12.Blue + ".\n\n");
        }
        else if (Command1 is DrawImage DrawImage2)
        {
          Console.Write("Command: Draw Image.\n" +
                        "Parameter:\n" +
                        "X = " + DrawImage2.X + ";\n" +
                        "Y = " + DrawImage2.Y + ";\n" +
                        "W = " + DrawImage2.W + ";\n" +
                        "H = " + DrawImage2.H + ";\n" +
                        "Data = " + DrawImage2.Data + ".\n\n");
        }
        else if (Command1 is Error Error2)
        {
          Console.Write(Error2.Text);
        }
      }
    }
  }
}
