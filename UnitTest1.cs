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
    public void TestMethod1()
    {
      String Message = "  clear  Display :  0, 128, 255.    ";
      Program.ClearDisplay command = (ClearDisplay)Program.Function(Message);

      Assert.AreEqual("clear display", command.Name);
      Assert.AreEqual(0, command.color.Red);
      Assert.AreEqual(128, command.color.Green);
      Assert.AreEqual(255, command.color.Blue);
    }

    [TestMethod]
    public void TestMethod2()
    {
      String Message = "  clear  Display :  -0, 128, 255.    ";
      Program.Error error = (Error)Program.Function(Message);

      Assert.AreEqual(" Error.\n\n", error.Text);
    }
  }
}
