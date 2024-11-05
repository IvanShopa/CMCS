using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Client
{
  internal class Program
  {
    static void Main()
    {
      Console.Title = "Клієнт";

      Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

      IPEndPoint ServerIPEndPoint = new IPEndPoint(IPAddress.Parse("_._._._"), 1);
      EndPoint ServerEndPoint = (EndPoint)ServerIPEndPoint;

      byte[] Buffer = new byte[10000];
      
      while (true)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Клiєнт: ");
        string ClientMessage = Console.ReadLine();
        byte[] ClientMessageByte = Encoding.UTF8.GetBytes(ClientMessage);
        ClientSocket.SendTo(ClientMessageByte, ServerEndPoint);
        Regex RegexExit = new Regex(@"\s*exit\s*\.\s*$", RegexOptions.IgnoreCase);
        if ((RegexExit.Match(ClientMessage)).Success)
        {
          Console.WriteLine();
          break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Сервер:");
        int ServerMessageByte = ClientSocket.ReceiveFrom(Buffer, ref ServerEndPoint);
        string ServerMessage = Encoding.UTF8.GetString(Buffer, 0, ServerMessageByte);
        Console.Write(ServerMessage);
      }

      Console.ReadKey();
    }
  }
}
