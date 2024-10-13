using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace UnitTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMessage1()
    {
      string ClientMessage = " clear  Display :  red 4";
      string ServerMessage = "\nCommand: clear display.\n" +
                             "Parameter: color - " + "red" + ".";

      string Result = Program.Message(ClientMessage);

      Assert.AreEqual(ServerMessage, Result);
    }

    [TestMethod]
    public void TestMessage2()
    {
      string ClientMessage = " clear  Display :  red";
      string ServerMessage = "\nCommand: clear display.\n" +
                             "Parameter: color - " + "red" + ".";

      string Result = Program.Message(ClientMessage);

      Assert.AreEqual(ServerMessage, Result);
    }
  }
}
