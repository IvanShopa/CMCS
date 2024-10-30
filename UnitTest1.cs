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
      String Message = " clear  Display :  -0, 128, 255";

      Program.Command Command1 = Program.Function(Message);

      String Result1 = "";
      if (Command1 is Program.ClearDisplay ClearDisplay2)
      {
        Result1 = "Result:" +
                  "\nCommand: Clear Display.\n" +
                  "Parameter:\n" +
                  "Red = " + ClearDisplay2.Color1.Red + ";\n" +
                  "Green = " + ClearDisplay2.Color1.Green + ";\n" +
                  "Blue = " + ClearDisplay2.Color1.Blue + ".\n\n";
      }
      else if (Command1 is Program.Error Error2)
      {
        Result1 = "Result:" + Error2.Text;
      }

      String Result2 = "Result:" +
                       "\nCommand: Clear Display.\n" +
                       "Parameter:\n" +
                       "Red = 0;\n" +
                       "Green = 128;\n" +
                       "Blue = 255.\n\n";

      Assert.AreEqual(Result2, Result1);
    }

    [TestMethod]
    public void TestMethod2()
    {
      string Message = " clear  Display :  0, 128, 255";

      Program.Command Command1 = Program.Function(Message);

      String Result1 = "";
      if (Command1 is Program.ClearDisplay ClearDisplay2)
      {
        Result1 = "Result:" +
                  "\nCommand: Clear Display.\n" +
                  "Parameter:\n" +
                  "Red = " + ClearDisplay2.Color1.Red + ";\n" +
                  "Green = " + ClearDisplay2.Color1.Green + ";\n" +
                  "Blue = " + ClearDisplay2.Color1.Blue + ".\n\n";
      }
      else if (Command1 is Program.Error Error2)
      {
        Result1 = "Result:" + Error2.Text;
      }

      String Result2 = "Result:" +
                       "\nCommand: Clear Display.\n" +
                       "Parameter:\n" +
                       "Red = 0;\n" +
                       "Green = 128;\n" +
                       "Blue = 255.\n\n";

      Assert.AreEqual(Result2, Result1);
    }

  }
}
