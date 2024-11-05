using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;
using static ConsoleApp.Program;

namespace UnitTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod01()
    {
      String Message = "clear display: 0, 128, 255.";
      Program.ClearDisplay command = (ClearDisplay)Program.Function(Message);

      Assert.AreEqual("clear display", command.Name);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod02()
    {
      String Message = "clear display: 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod03()
    {
      String Message = "draw pixel: 1, 2, 0, 128, 255.";
      Program.DrawPixel command = (DrawPixel)Program.Function(Message);

      Assert.AreEqual("draw pixel", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod04()
    {
      String Message = "draw pixel: 1, 2, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod05()
    {
      String Message = "draw line: 1, 2, 3, 4, 0, 128, 255.";
      Program.DrawLine command = (DrawLine)Program.Function(Message);

      Assert.AreEqual("draw line", command.Name);
      Assert.AreEqual(1, command.X1);
      Assert.AreEqual(2, command.Y1);
      Assert.AreEqual(3, command.X2);
      Assert.AreEqual(4, command.Y2);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod06()
    {
      String Message = "draw line: 1, 2, 3, 4, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod07()
    {
      String Message = "draw rectangle: 1, 2, 3, 4, 0, 128, 255.";
      Program.DrawRectangle command = (DrawRectangle)Program.Function(Message);

      Assert.AreEqual("draw rectangle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.W);
      Assert.AreEqual(4, command.H);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod08()
    {
      String Message = "draw rectangle: 1, 2, 3, 4, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod09()
    {
      String Message = "fill rectangle: 1, 2, 3, 4, 0, 128, 255.";
      Program.FillRectangle command = (FillRectangle)Program.Function(Message);

      Assert.AreEqual("fill rectangle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.W);
      Assert.AreEqual(4, command.H);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod10()
    {
      String Message = "fill rectangle: 1, 2, 3, 4, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod11()
    {
      String Message = "draw ellipse: 1, 2, 3, 4, 0, 128, 255.";
      Program.DrawEllipse command = (DrawEllipse)Program.Function(Message);

      Assert.AreEqual("draw ellipse", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.RadiusX);
      Assert.AreEqual(4, command.RadiusY);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod12()
    {
      String Message = "draw ellipse: 1, 2, 3, 4, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod13()
    {
      String Message = "fill ellipse: 1, 2, 3, 4, 0, 128, 255.";
      Program.FillEllipse command = (FillEllipse)Program.Function(Message);

      Assert.AreEqual("fill ellipse", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.RadiusX);
      Assert.AreEqual(4, command.RadiusY);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod14()
    {
      String Message = "fill ellipse: 1, 2, 3, 4, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod15()
    {
      String Message = "draw circle: 1, 2, 3, 0, 128, 255.";
      Program.DrawCircle command = (DrawCircle)Program.Function(Message);

      Assert.AreEqual("draw circle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.Radius);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod16()
    {
      String Message = "draw circle: 1, 2, 3, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod17()
    {
      String Message = "fill circle: 1, 2, 3, 0, 128, 255.";
      Program.FillCircle command = (FillCircle)Program.Function(Message);

      Assert.AreEqual("fill circle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.Radius);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod18()
    {
      String Message = "fill circle: 1, 2, 3, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod19()
    {
      String Message = "draw rounded rectangle: 1, 2, 3, 4, 5, 0, 128, 255.";
      Program.DrawRoundedRectangle command = (DrawRoundedRectangle)Program.Function(Message);

      Assert.AreEqual("draw rounded rectangle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.W);
      Assert.AreEqual(4, command.H);
      Assert.AreEqual(5, command.Radius);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod20()
    {
      String Message = "draw rounded rectangle: 1, 2, 3, 4, 5, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod21()
    {
      String Message = "fill rounded rectangle: 1, 2, 3, 4, 5, 0, 128, 255.";
      Program.FillRoundedRectangle command = (FillRoundedRectangle)Program.Function(Message);

      Assert.AreEqual("fill rounded rectangle", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.W);
      Assert.AreEqual(4, command.H);
      Assert.AreEqual(5, command.Radius);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod22()
    {
      String Message = "fill rounded rectangle: 1, 2, 3, 4, 5, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod23()
    {
      String Message = "draw text: 1, 2, arial, 3, Hello World, 0, 128, 255.";
      Program.DrawText command = (DrawText)Program.Function(Message);

      Assert.AreEqual("draw text", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual("Arial", command.Font);
      Assert.AreEqual(3, command.Length);
      Assert.AreEqual("Hello World", command.Text);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod24()
    {
      String Message = "draw text: 1, 2, arial, 3, Hello World, 0, -128, 255.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }

    [TestMethod]
    public void TestMethod25()
    {
      String Message = "draw image: 1, 2, 3, 4, 00111001.";
      Program.DrawImage command = (DrawImage)Program.Function(Message);

      Assert.AreEqual("draw image", command.Name);
      Assert.AreEqual(1, command.X);
      Assert.AreEqual(2, command.Y);
      Assert.AreEqual(3, command.W);
      Assert.AreEqual(4, command.H);
      Assert.AreEqual("00111001", command.Data);
    }

    [TestMethod]
    public void TestMethod26()
    {
      String Message = "draw image: 1, 2, 3, 4, 00141001.";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }
  }
}
