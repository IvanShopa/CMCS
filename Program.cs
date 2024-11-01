using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
  public class Program
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

    public static Command Function(String Message)
    {
      Regex RegexClearDisplay = new Regex(@"\s*clear\s+display\s*:\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawPixel = new Regex(@"\s*draw\s*pixel\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawLine = new Regex(@"\s*draw\s*line\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRectangle = new Regex(@"\s*draw\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRectangle = new Regex(@"\s*fill\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawEllipse = new Regex(@"\s*draw\s*ellipse\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillEllipse = new Regex(@"\s*fill\s*ellipse\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawCircle = new Regex(@"\s*draw\s*circle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillCircle = new Regex(@"\s*fill\s*circle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRoundedRectangle = new Regex(@"\s*draw\s*rounded\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRoundedRectangle = new Regex(@"\s*fill\s*rounded\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawText = new Regex(@"\s*draw\s*text\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*arial\s*,\s*(\d+)\s*,\s*([\w+\s*]+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawImage = new Regex(@"\s*draw\s*image\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([01]+)\s*\.\s*$", RegexOptions.IgnoreCase);

      Match Match1;

      if ((Match1 = RegexClearDisplay.Match(Message)).Success)
      {
        ClearDisplay clearDisplay = new ClearDisplay();
        clearDisplay.Name = "clear display";
        clearDisplay.color.Red = Byte.Parse(Match1.Groups[1].Value);
        clearDisplay.color.Green = Byte.Parse(Match1.Groups[2].Value);
        clearDisplay.color.Blue = Byte.Parse(Match1.Groups[3].Value);
        return clearDisplay;
      }
      else if ((Match1 = RegexDrawPixel.Match(Message)).Success)
      {
        DrawPixel drawPixel = new DrawPixel();
        drawPixel.Name = "draw pixel";
        drawPixel.X = Int16.Parse(Match1.Groups[1].Value);
        drawPixel.Y = Int16.Parse(Match1.Groups[2].Value);
        drawPixel.color.Red = Byte.Parse(Match1.Groups[3].Value);
        drawPixel.color.Green = Byte.Parse(Match1.Groups[4].Value);
        drawPixel.color.Blue = Byte.Parse(Match1.Groups[5].Value);
        return drawPixel;
      }
      else if ((Match1 = RegexDrawLine.Match(Message)).Success)
      {
        DrawLine drawLine = new DrawLine();
        drawLine.Name = "draw line";
        drawLine.X1 = Int16.Parse(Match1.Groups[1].Value);
        drawLine.Y1 = Int16.Parse(Match1.Groups[2].Value);
        drawLine.X2 = Int16.Parse(Match1.Groups[3].Value);
        drawLine.Y2 = Int16.Parse(Match1.Groups[4].Value);
        drawLine.color.Red = Byte.Parse(Match1.Groups[5].Value);
        drawLine.color.Green = Byte.Parse(Match1.Groups[6].Value);
        drawLine.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return drawLine;
      }
      else if ((Match1 = RegexDrawRectangle.Match(Message)).Success)
      {
        DrawRectangle drawRectangle = new DrawRectangle();
        drawRectangle.Name = "draw rectangle";
        drawRectangle.X = Int16.Parse(Match1.Groups[1].Value);
        drawRectangle.Y = Int16.Parse(Match1.Groups[2].Value);
        drawRectangle.W = Int16.Parse(Match1.Groups[3].Value);
        drawRectangle.H = Int16.Parse(Match1.Groups[4].Value);
        drawRectangle.color.Red = Byte.Parse(Match1.Groups[5].Value);
        drawRectangle.color.Green = Byte.Parse(Match1.Groups[6].Value);
        drawRectangle.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return drawRectangle;
      }
      else if ((Match1 = RegexFillRectangle.Match(Message)).Success)
      {
        FillRectangle fillRectangle = new FillRectangle();
        fillRectangle.Name = "fill rectangle";
        fillRectangle.X = Int16.Parse(Match1.Groups[1].Value);
        fillRectangle.Y = Int16.Parse(Match1.Groups[2].Value);
        fillRectangle.W = Int16.Parse(Match1.Groups[3].Value);
        fillRectangle.H = Int16.Parse(Match1.Groups[4].Value);
        fillRectangle.color.Red = Byte.Parse(Match1.Groups[5].Value);
        fillRectangle.color.Green = Byte.Parse(Match1.Groups[6].Value);
        fillRectangle.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return fillRectangle;
      }
      else if ((Match1 = RegexDrawEllipse.Match(Message)).Success)
      {
        DrawEllipse drawEllipse = new DrawEllipse();
        drawEllipse.Name = "draw ellipse";
        drawEllipse.X = Int16.Parse(Match1.Groups[1].Value);
        drawEllipse.Y = Int16.Parse(Match1.Groups[2].Value);
        drawEllipse.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        drawEllipse.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        drawEllipse.color.Red = Byte.Parse(Match1.Groups[5].Value);
        drawEllipse.color.Green = Byte.Parse(Match1.Groups[6].Value);
        drawEllipse.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return drawEllipse;
      }
      else if ((Match1 = RegexFillEllipse.Match(Message)).Success)
      {
        FillEllipse fillEllipse = new FillEllipse();
        fillEllipse.Name = "fill ellipse";
        fillEllipse.X = Int16.Parse(Match1.Groups[1].Value);
        fillEllipse.Y = Int16.Parse(Match1.Groups[2].Value);
        fillEllipse.RadiusX = Int16.Parse(Match1.Groups[3].Value);
        fillEllipse.RadiusY = Int16.Parse(Match1.Groups[4].Value);
        fillEllipse.color.Red = Byte.Parse(Match1.Groups[5].Value);
        fillEllipse.color.Green = Byte.Parse(Match1.Groups[6].Value);
        fillEllipse.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return fillEllipse;
      }
      else if ((Match1 = RegexDrawCircle.Match(Message)).Success)
      {
        DrawCircle drawCircle = new DrawCircle();
        drawCircle.Name = "draw circle";
        drawCircle.X = Int16.Parse(Match1.Groups[1].Value);
        drawCircle.Y = Int16.Parse(Match1.Groups[2].Value);
        drawCircle.Radius = Int16.Parse(Match1.Groups[3].Value);
        drawCircle.color.Red = Byte.Parse(Match1.Groups[4].Value);
        drawCircle.color.Green = Byte.Parse(Match1.Groups[5].Value);
        drawCircle.color.Blue = Byte.Parse(Match1.Groups[6].Value);
        return drawCircle;
      }
      else if ((Match1 = RegexFillCircle.Match(Message)).Success)
      {
        FillCircle fillCircle = new FillCircle();
        fillCircle.Name = "fill circle";
        fillCircle.X = Int16.Parse(Match1.Groups[1].Value);
        fillCircle.Y = Int16.Parse(Match1.Groups[2].Value);
        fillCircle.Radius = Int16.Parse(Match1.Groups[3].Value);
        fillCircle.color.Red = Byte.Parse(Match1.Groups[4].Value);
        fillCircle.color.Green = Byte.Parse(Match1.Groups[5].Value);
        fillCircle.color.Blue = Byte.Parse(Match1.Groups[6].Value);
        return fillCircle;
      }
      else if ((Match1 = RegexDrawRoundedRectangle.Match(Message)).Success)
      {
        DrawRoundedRectangle drawRoundedRectangle = new DrawRoundedRectangle();
        drawRoundedRectangle.Name = "draw rounded rectangle";
        drawRoundedRectangle.X = Int16.Parse(Match1.Groups[1].Value);
        drawRoundedRectangle.Y = Int16.Parse(Match1.Groups[2].Value);
        drawRoundedRectangle.W = Int16.Parse(Match1.Groups[3].Value);
        drawRoundedRectangle.H = Int16.Parse(Match1.Groups[4].Value);
        drawRoundedRectangle.Radius = Int16.Parse(Match1.Groups[5].Value);
        drawRoundedRectangle.color.Red = Byte.Parse(Match1.Groups[6].Value);
        drawRoundedRectangle.color.Green = Byte.Parse(Match1.Groups[7].Value);
        drawRoundedRectangle.color.Blue = Byte.Parse(Match1.Groups[8].Value);
        return drawRoundedRectangle;
      }
      else if ((Match1 = RegexFillRoundedRectangle.Match(Message)).Success)
      {
        FillRoundedRectangle fillRoundedRectangle = new FillRoundedRectangle();
        fillRoundedRectangle.Name = "fill rounded rectangle";
        fillRoundedRectangle.X = Int16.Parse(Match1.Groups[1].Value);
        fillRoundedRectangle.Y = Int16.Parse(Match1.Groups[2].Value);
        fillRoundedRectangle.W = Int16.Parse(Match1.Groups[3].Value);
        fillRoundedRectangle.H = Int16.Parse(Match1.Groups[4].Value);
        fillRoundedRectangle.Radius = Int16.Parse(Match1.Groups[5].Value);
        fillRoundedRectangle.color.Red = Byte.Parse(Match1.Groups[6].Value);
        fillRoundedRectangle.color.Green = Byte.Parse(Match1.Groups[7].Value);
        fillRoundedRectangle.color.Blue = Byte.Parse(Match1.Groups[8].Value);
        return fillRoundedRectangle;
      }
      else if ((Match1 = RegexDrawText.Match(Message)).Success)
      {
        DrawText drawText = new DrawText();
        drawText.Name = "draw text";
        drawText.X = Int16.Parse(Match1.Groups[1].Value);
        drawText.Y = Int16.Parse(Match1.Groups[2].Value);
        drawText.Font = "Arial";
        drawText.Length = Int16.Parse(Match1.Groups[3].Value);
        drawText.Text = Match1.Groups[4].Value;
        drawText.color.Red = Byte.Parse(Match1.Groups[5].Value);
        drawText.color.Green = Byte.Parse(Match1.Groups[6].Value);
        drawText.color.Blue = Byte.Parse(Match1.Groups[7].Value);
        return drawText;
      }
      else if ((Match1 = RegexDrawImage.Match(Message)).Success)
      {
        DrawImage drawImage = new DrawImage();
        drawImage.Name = "draw image";
        drawImage.X = Int16.Parse(Match1.Groups[1].Value);
        drawImage.Y = Int16.Parse(Match1.Groups[2].Value);
        drawImage.W = Int16.Parse(Match1.Groups[3].Value);
        drawImage.H = Int16.Parse(Match1.Groups[4].Value);
        drawImage.Data = Match1.Groups[5].Value;
        return drawImage;
      }
      else
      {
        Error Error1 = new Error();
        Error1.Text = " Error.\n\n";
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
          Console.Write("\nCommand: " + ClearDisplay2.Name + ".\n" +
                        "Parameter:\n" +
                        "Red = " + ClearDisplay2.color.Red + ";\n" +
                        "Green = " + ClearDisplay2.color.Green + ";\n" +
                        "Blue = " + ClearDisplay2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawPixel DrawPixel2)
        {
          Console.Write("\nCommand: " + DrawPixel2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawPixel2.X + ";\n" +
                        "Y = " + DrawPixel2.Y + ";\n" +
                        "Red = " + DrawPixel2.color.Red + ";\n" +
                        "Green = " + DrawPixel2.color.Green + ";\n" +
                        "Blue = " + DrawPixel2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawLine DrawLine2)
        {
          Console.Write("\nCommand: " + DrawLine2.Name + ".\n" +
                        "Parameter:\n" +
                        "X1 = " + DrawLine2.X1 + ";\n" +
                        "Y1 = " + DrawLine2.Y1 + ";\n" +
                        "X2 = " + DrawLine2.X2 + ";\n" +
                        "Y2 = " + DrawLine2.Y2 + ";\n" +
                        "Red = " + DrawLine2.color.Red + ";\n" +
                        "Green = " + DrawLine2.color.Green + ";\n" +
                        "Blue = " + DrawLine2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawRectangle DrawRectangle2)
        {
          Console.Write("\nCommand: " + DrawRectangle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawRectangle2.X + ";\n" +
                        "Y = " + DrawRectangle2.Y + ";\n" +
                        "W = " + DrawRectangle2.W + ";\n" +
                        "H = " + DrawRectangle2.H + ";\n" +
                        "Red = " + DrawRectangle2.color.Red + ";\n" +
                        "Green = " + DrawRectangle2.color.Green + ";\n" +
                        "Blue = " + DrawRectangle2.color.Blue + ".\n\n");
        }
        else if (Command1 is FillRectangle FillRectangle2)
        {
          Console.Write("\nCommand: " + FillRectangle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + FillRectangle2.X + ";\n" +
                        "Y = " + FillRectangle2.Y + ";\n" +
                        "W = " + FillRectangle2.W + ";\n" +
                        "H = " + FillRectangle2.H + ";\n" +
                        "Red = " + FillRectangle2.color.Red + ";\n" +
                        "Green = " + FillRectangle2.color.Green + ";\n" +
                        "Blue = " + FillRectangle2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawEllipse DrawEllipse2)
        {
          Console.Write("\nCommand: " + DrawEllipse2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawEllipse2.X + ";\n" +
                        "Y = " + DrawEllipse2.Y + ";\n" +
                        "W = " + DrawEllipse2.RadiusX + ";\n" +
                        "H = " + DrawEllipse2.RadiusX + ";\n" +
                        "Red = " + DrawEllipse2.color.Red + ";\n" +
                        "Green = " + DrawEllipse2.color.Green + ";\n" +
                        "Blue = " + DrawEllipse2.color.Blue + ".\n\n");
        }
        else if (Command1 is FillEllipse FillEllipse2)
        {
          Console.Write("\nCommand: " + FillEllipse2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + FillEllipse2.X + ";\n" +
                        "Y = " + FillEllipse2.Y + ";\n" +
                        "W = " + FillEllipse2.RadiusX + ";\n" +
                        "H = " + FillEllipse2.RadiusX + ";\n" +
                        "Red = " + FillEllipse2.color.Red + ";\n" +
                        "Green = " + FillEllipse2.color.Green + ";\n" +
                        "Blue = " + FillEllipse2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawCircle DrawCircle2)
        {
          Console.Write("\nCommand: " + DrawCircle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawCircle2.X + ";\n" +
                        "Y = " + DrawCircle2.Y + ";\n" +
                        "Radius = " + DrawCircle2.Radius + ";\n" +
                        "Red = " + DrawCircle2.color.Red + ";\n" +
                        "Green = " + DrawCircle2.color.Green + ";\n" +
                        "Blue = " + DrawCircle2.color.Blue + ".\n\n");
        }
        else if (Command1 is FillCircle FillCircle2)
        {
          Console.Write("\nCommand: " + FillCircle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + FillCircle2.X + ";\n" +
                        "Y = " + FillCircle2.Y + ";\n" +
                        "Radius = " + FillCircle2.Radius + ";\n" +
                        "Red = " + FillCircle2.color.Red + ";\n" +
                        "Green = " + FillCircle2.color.Green + ";\n" +
                        "Blue = " + FillCircle2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawRoundedRectangle DrawRoundedRectangle2)
        {
          Console.Write("\nCommand: " + DrawRoundedRectangle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawRoundedRectangle2.X + ";\n" +
                        "Y = " + DrawRoundedRectangle2.Y + ";\n" +
                        "W = " + DrawRoundedRectangle2.W + ";\n" +
                        "H = " + DrawRoundedRectangle2.H + ";\n" +
                        "Radius = " + DrawRoundedRectangle2.Radius + ";\n" +
                        "Red = " + DrawRoundedRectangle2.color.Red + ";\n" +
                        "Green = " + DrawRoundedRectangle2.color.Green + ";\n" +
                        "Blue = " + DrawRoundedRectangle2.color.Blue + ".\n\n");
        }
        else if (Command1 is FillRoundedRectangle FillRoundedRectangle2)
        {
          Console.Write("\nCommand: " + FillRoundedRectangle2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + FillRoundedRectangle2.X + ";\n" +
                        "Y = " + FillRoundedRectangle2.Y + ";\n" +
                        "W = " + FillRoundedRectangle2.W + ";\n" +
                        "H = " + FillRoundedRectangle2.H + ";\n" +
                        "Radius = " + FillRoundedRectangle2.Radius + ";\n" +
                        "Red = " + FillRoundedRectangle2.color.Red + ";\n" +
                        "Green = " + FillRoundedRectangle2.color.Green + ";\n" +
                        "Blue = " + FillRoundedRectangle2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawText DrawText2)
        {
          Console.Write("\nCommand: " + DrawText2.Name + ".\n" +
                        "Parameter:\n" +
                        "X = " + DrawText2.X + ";\n" +
                        "Y = " + DrawText2.Y + ";\n" +
                        "Font = " + DrawText2.Font + ";\n" +
                        "Length = " + DrawText2.Length + ";\n" +
                        "Text = " + DrawText2.Text + ";\n" +
                        "Red = " + DrawText2.color.Red + ";\n" +
                        "Green = " + DrawText2.color.Green + ";\n" +
                        "Blue = " + DrawText2.color.Blue + ".\n\n");
        }
        else if (Command1 is DrawImage DrawImage2)
        {
          Console.Write("\nCommand: " + DrawImage2.Name + ".\n" +
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
