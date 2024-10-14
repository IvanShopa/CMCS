using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Server
{
  public class Program
  {
    public static string Message(string ClientMessage)
    {
      Regex Regex1 = new Regex(@"\s*clear\s*display\s*:\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex2 = new Regex(@"\s*draw\s*pixel\s*:\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex3 = new Regex(@"\s*draw\s*line\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex4 = new Regex(@"\s*draw\s*rectangle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex5 = new Regex(@"\s*fill\s*rectangle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex6 = new Regex(@"\s*draw\s*ellipse\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex7 = new Regex(@"\s*fill\s*ellipse\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex8 = new Regex(@"\s*draw\s*circle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex9 = new Regex(@"\s*fill\s*circle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex10 = new Regex(@"\s*draw\s*rounded\s*rectangle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex11 = new Regex(@"\s*fill\s*rounded\s*rectangle\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex12 = new Regex(@"\s*draw\s*text\s*:\s*(\d+)\s*(\d+)\s*arial\s*(\d+)\s*(\w+)\s*red\s*$", RegexOptions.IgnoreCase);
      Regex Regex13 = new Regex(@"\s*draw\s*image\s*:\s*(\d+)\s*(\d+)\s*(\d+)\s*(\d+)\s*([01]+)\s*$", RegexOptions.IgnoreCase);

      Match Match1;

      if ((Match1 = Regex1.Match(ClientMessage)).Success)
      {
        return "\nCommand: clear display.\n" +
               "Parameter: color - " + Match1.Groups[1].Value + ".";
      }
      else if ((Match1 = Regex2.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw pixel.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "color - " + Match1.Groups[3].Value + ".";
      }
      else if ((Match1 = Regex3.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw line.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "x1 - " + Match1.Groups[3].Value + ",\n" +
               "y2 - " + Match1.Groups[4].Value + ",\n" +
               "color - " + Match1.Groups[5].Value + ".";
      }
      else if ((Match1 = Regex4.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw rectangle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "w - " + Match1.Groups[3].Value + ",\n" +
               "h - " + Match1.Groups[4].Value + ",\n" +
               "color - " + Match1.Groups[5].Value + ".";
      }
      else if ((Match1 = Regex5.Match(ClientMessage)).Success)
      {
        return "\nCommand: fill rectangle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "w - " + Match1.Groups[3].Value + ",\n" +
               "h - " + Match1.Groups[4].Value + ",\n" +
               "color - " + Match1.Groups[5].Value + ".";
      }
      else if ((Match1 = Regex6.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw ellipse.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "radius_x - " + Match1.Groups[3].Value + ",\n" +
               "radius_y - " + Match1.Groups[4].Value + ",\n" +
               "color - " + Match1.Groups[5].Value + ".";
      }
      else if ((Match1 = Regex7.Match(ClientMessage)).Success)
      {
        return "\nCommand: fill ellipse.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "radius_x - " + Match1.Groups[3].Value + ",\n" +
               "radius_y - " + Match1.Groups[4].Value + ",\n" +
               "color - " + Match1.Groups[5].Value + ".";
      }
      else if ((Match1 = Regex8.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw circle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "radius - " + Match1.Groups[3].Value + ",\n" +
               "color - " + Match1.Groups[4].Value + ".";
      }
      else if ((Match1 = Regex9.Match(ClientMessage)).Success)
      {
        return "\nCommand: fill circle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "radius - " + Match1.Groups[3].Value + ",\n" +
               "color - " + Match1.Groups[4].Value + ".";
      }
      else if ((Match1 = Regex10.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw rounded rectangle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "w - " + Match1.Groups[3].Value + ",\n" +
               "h - " + Match1.Groups[4].Value + ",\n" +
               "radius - " + Match1.Groups[5].Value + ",\n" +
               "color - " + Match1.Groups[6].Value + ".";
      }
      else if ((Match1 = Regex11.Match(ClientMessage)).Success)
      {
        return "\nCommand: fill rounded rectangle.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "w - " + Match1.Groups[3].Value + ",\n" +
               "h - " + Match1.Groups[4].Value + ",\n" +
               "radius - " + Match1.Groups[5].Value + ",\n" +
               "color - " + Match1.Groups[6].Value + ".";
      }
      else if ((Match1 = Regex12.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw text.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "font - " + Match1.Groups[3].Value + ",\n" +
               "length - " + Match1.Groups[4].Value + ",\n" +
               "text - " + Match1.Groups[5].Value + ",\n" +
               "color - " + Match1.Groups[6].Value + ".";
      }
      else if ((Match1 = Regex13.Match(ClientMessage)).Success)
      {
        return "\nCommand: draw image.\n" +
               "Parameters:\n" +
               "x0 - " + Match1.Groups[1].Value + ",\n" +
               "y0 - " + Match1.Groups[2].Value + ",\n" +
               "w - " + Match1.Groups[3].Value + ",\n" +
               "h - " + Match1.Groups[4].Value + ",\n" +
               "data - " + Match1.Groups[5].Value + ".";
      }
      else
      {
        return "Error.";
      }
    }

    static void Main()
    {
      Console.Title = "Server";

      Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

      IPEndPoint ServerIPEndPoint = new IPEndPoint(IPAddress.Parse("___.___.___.___"), 1);
      EndPoint ServerEndPoint = (EndPoint)ServerIPEndPoint;

      ServerSocket.Bind(ServerEndPoint);

      IPEndPoint ClientIPEndPoint = new IPEndPoint(IPAddress.Any, 1);
      EndPoint ClientEndPoint = (EndPoint)ClientIPEndPoint;

      byte[] Buffer = new byte[10000];
      string ClientMessage, ServerMessage;

      while (true)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("CLIENT: ");
        int ClientMessageByte = ServerSocket.ReceiveFrom(Buffer, ref ClientEndPoint);
        ClientMessage = Encoding.UTF8.GetString(Buffer, 0, ClientMessageByte);
        Console.WriteLine(ClientMessage);
        Regex Regex1 = new Regex(@"\s*exit\s*$", RegexOptions.IgnoreCase);
        if ((Regex1.Match(ClientMessage)).Success)
        {
          Console.WriteLine();
          continue;
        }
        else
        {
          ServerMessage = Message(ClientMessage);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("SERVER: ");
        byte[] ServerMessageByte = Encoding.UTF8.GetBytes(ServerMessage);
        ServerSocket.SendTo(ServerMessageByte, ClientEndPoint);
        Console.WriteLine(ServerMessage + "\n");
      }
    }
  }
}
