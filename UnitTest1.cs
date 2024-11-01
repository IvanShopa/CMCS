using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;

namespace UnitTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      String Message = "  clear  Display :  0, 128, 255.    ";

      Program.Command command = Program.Function(Message);

      String Result1 = "";
      if (command is Program.ClearDisplay clearDisplay)
      {
        Result1 = clearDisplay.Name;
      }

      String Result2 = "clear display";

      Assert.AreEqual(Result2, Result1);
    }

    [TestMethod]
    public void TestMethod2()
    {
      String Message = "  clear  Display :  0, 128, 255.    ";

      Program.Command command = Program.Function(Message);

      String Result1 = "";
      if (command is Program.ClearDisplay clearDisplay)
      {
        Result1 = clearDisplay.color.Red.ToString();
      }

      String Result2 = "0";

      Assert.AreEqual(Result2, Result1);
    }

    [TestMethod]
    public void TestMethod3()
    {
      String Message = "  clear  Display :  0, 128, 255.    ";

      Program.Command command = Program.Function(Message);

      String Result1 = "";
      if (command is Program.ClearDisplay clearDisplay)
      {
        Result1 = clearDisplay.color.Green.ToString();
      }

      String Result2 = "128";

      Assert.AreEqual(Result2, Result1);
    }

    [TestMethod]
    public void TestMethod4()
    {
      String Message = "  clear  Display :  0, 128, 255.    ";

      Program.Command command = Program.Function(Message);

      String Result1 = "";
      if (command is Program.ClearDisplay clearDisplay)
      {
        Result1 = clearDisplay.color.Blue.ToString();
      }

      String Result2 = "255";

      Assert.AreEqual(Result2, Result1);
    }
  }
}
