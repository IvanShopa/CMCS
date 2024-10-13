using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Client
{
  public class Program
  {
    static void Main()
    {
      Console.Title = "Client";

      Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

      IPEndPoint ServerIPEndPoint = new IPEndPoint(IPAddress.Parse("___.___.___.___"), 1);
      EndPoint ServerEndPoint = (EndPoint)ServerIPEndPoint;

      byte[] Buffer = new byte[10000];

      while (true)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("CLIENT: ");
        string ClientMessage = Console.ReadLine();
        byte[] ClientMessageByte = Encoding.UTF8.GetBytes(ClientMessage);
        ClientSocket.SendTo(ClientMessageByte, ServerEndPoint);
        Regex Regex1 = new Regex(@"\s*exit\s*$", RegexOptions.IgnoreCase);
        if ((Regex1.Match(ClientMessage)).Success)
        {
          Console.WriteLine();
          break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("SERVER: ");
        int ServerMessageByte = ClientSocket.ReceiveFrom(Buffer, ref ServerEndPoint);
        string ServerMessage = Encoding.UTF8.GetString(Buffer, 0, ServerMessageByte);
        Console.WriteLine(ServerMessage);

        Console.WriteLine();
      }

      Console.ReadKey();
    }
  }
}
