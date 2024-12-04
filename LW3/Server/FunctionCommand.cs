using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

using static Server.BitmapAndGraphics;
using static Server.ClassCommand;

namespace Server
{
  static class FunctionCommand
  {
    public static Command Function(String Message)
    {
      Regex RegexClearDisplay = new Regex(@"^\s*clear\s+display\s*:\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawPixel = new Regex(@"^\s*draw\s*pixel\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawLine = new Regex(@"^\s*draw\s*line\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRectangle = new Regex(@"^\s*draw\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRectangle = new Regex(@"^\s*fill\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawEllipse = new Regex(@"^\s*draw\s*ellipse\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillEllipse = new Regex(@"^\s*fill\s*ellipse\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawCircle = new Regex(@"^\s*draw\s*circle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillCircle = new Regex(@"^\s*fill\s*circle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawRoundedRectangle = new Regex(@"^\s*draw\s*rounded\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexFillRoundedRectangle = new Regex(@"^\s*fill\s*rounded\s*rectangle\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawText = new Regex(@"^\s*draw\s*text\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*arial\s*,\s*(\d+)\s*,\s*([\w+\s*]+)\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*,\s*([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\s*\.\s*$", RegexOptions.IgnoreCase);
      Regex RegexDrawImage = new Regex(@"^\s*draw\s*image\s*:\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(-\d+|\d+)\s*,\s*(.+)\s*\.\s*$", RegexOptions.IgnoreCase);

      Match Match1;

      if ((Match1 = RegexClearDisplay.Match(Message)).Success)
      {
        ClearDisplay clearDisplay = new ClearDisplay();
        clearDisplay.Name = "clear display";
        clearDisplay.color.Red = Byte.Parse(Match1.Groups[1].Value);
        clearDisplay.color.Green = Byte.Parse(Match1.Groups[2].Value);
        clearDisplay.color.Blue = Byte.Parse(Match1.Groups[3].Value);

        CanvasGraphics.Clear(System.Drawing.Color.FromArgb(255, clearDisplay.color.Red, clearDisplay.color.Green, clearDisplay.color.Blue));

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

        System.Drawing.Color pixelColor = System.Drawing.Color.FromArgb(255, drawPixel.color.Red, drawPixel.color.Green, drawPixel.color.Blue);
        Canvas.SetPixel(drawPixel.X, drawPixel.Y, pixelColor);

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

        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, drawLine.color.Red, drawLine.color.Green, drawLine.color.Blue));
        CanvasGraphics.DrawLine(pen, drawLine.X1, drawLine.Y1, drawLine.X2, drawLine.Y2);

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

        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, drawRectangle.color.Red, drawRectangle.color.Green, drawRectangle.color.Blue));
        CanvasGraphics.DrawRectangle(pen, drawRectangle.X, drawRectangle.Y, drawRectangle.W, drawRectangle.H);

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

        CanvasGraphics.FillRectangle(
          new SolidBrush(System.Drawing.Color.FromArgb(255, fillRectangle.color.Red, fillRectangle.color.Green, fillRectangle.color.Blue)),
          fillRectangle.X, fillRectangle.Y, fillRectangle.W, fillRectangle.H
        );

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

        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, drawEllipse.color.Red, drawEllipse.color.Green, drawEllipse.color.Blue));
        CanvasGraphics.DrawEllipse(pen, drawEllipse.X - drawEllipse.RadiusX, drawEllipse.Y - drawEllipse.RadiusY, drawEllipse.RadiusX * 2, drawEllipse.RadiusY * 2);

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

        CanvasGraphics.FillEllipse(
          new SolidBrush(System.Drawing.Color.FromArgb(255, fillEllipse.color.Red, fillEllipse.color.Green, fillEllipse.color.Blue)),
          fillEllipse.X - fillEllipse.RadiusX, fillEllipse.Y - fillEllipse.RadiusY, fillEllipse.RadiusX * 2, fillEllipse.RadiusY * 2
        );

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

        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, drawCircle.color.Red, drawCircle.color.Green, drawCircle.color.Blue));
        CanvasGraphics.DrawEllipse(pen, drawCircle.X - drawCircle.Radius, drawCircle.Y - drawCircle.Radius, drawCircle.Radius * 2, drawCircle.Radius * 2);

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

        Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(255, fillCircle.color.Red, fillCircle.color.Green, fillCircle.color.Blue));
        CanvasGraphics.FillEllipse(brush, fillCircle.X - fillCircle.Radius, fillCircle.Y - fillCircle.Radius, fillCircle.Radius * 2, fillCircle.Radius * 2);

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

        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, drawRoundedRectangle.color.Red, drawRoundedRectangle.color.Green, drawRoundedRectangle.color.Blue));
        GraphicsPath path = new GraphicsPath();
        path.AddArc(drawRoundedRectangle.X, drawRoundedRectangle.Y, drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, 180, 90);
        path.AddArc(drawRoundedRectangle.X + drawRoundedRectangle.W - drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Y, drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, 270, 90);
        path.AddArc(drawRoundedRectangle.X + drawRoundedRectangle.W - drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Y + drawRoundedRectangle.H - drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, 0, 90);
        path.AddArc(drawRoundedRectangle.X, drawRoundedRectangle.Y + drawRoundedRectangle.H - drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, drawRoundedRectangle.Radius * 2, 90, 90);
        path.CloseFigure();
        CanvasGraphics.DrawPath(pen, path);

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

        SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(255, fillRoundedRectangle.color.Red, fillRoundedRectangle.color.Green, fillRoundedRectangle.color.Blue));
        GraphicsPath path = new GraphicsPath();
        path.AddArc(fillRoundedRectangle.X, fillRoundedRectangle.Y, fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, 180, 90);
        path.AddArc(fillRoundedRectangle.X + fillRoundedRectangle.W - fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Y, fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, 270, 90);
        path.AddArc(fillRoundedRectangle.X + fillRoundedRectangle.W - fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Y + fillRoundedRectangle.H - fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, 0, 90);
        path.AddArc(fillRoundedRectangle.X, fillRoundedRectangle.Y + fillRoundedRectangle.H - fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, fillRoundedRectangle.Radius * 2, 90, 90);
        path.CloseFigure();
        CanvasGraphics.FillPath(brush, path);

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

        Font font = new Font(drawText.Font, drawText.Length);
        SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(255, drawText.color.Red, drawText.color.Green, drawText.color.Blue));
        CanvasGraphics.DrawString(drawText.Text, font, brush, new PointF(drawText.X, drawText.Y));

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

        try
        {
          byte[] imageBytes = Convert.FromBase64String(drawImage.Data);
          MemoryStream ms = new MemoryStream(imageBytes);
          Image img = Image.FromStream(ms);
          CanvasGraphics.DrawImage(img, drawImage.X, drawImage.Y, drawImage.W, drawImage.H);
        }
        catch (FormatException ex)
        {
          Error error = new Error();
          error.Text = "Error.\n\n";
          return error;
        }

        return drawImage;
      }
      else
      {
        Error error = new Error();
        error.Text = "Error.\n\n";
        return error;
      }
    }
  }
}
