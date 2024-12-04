using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using static Server.BitmapAndGraphics;
using static Server.ClassCommand;
using static Server.FunctionCommand;

namespace Server
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      Canvas = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
      CanvasGraphics = Graphics.FromImage(Canvas);
      Task.Run(() =>
      {
        Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPEndPoint ServerIPEndPoint = new IPEndPoint(IPAddress.Parse("_._._._"), 1);
        EndPoint ServerEndPoint = (EndPoint)ServerIPEndPoint;

        ServerSocket.Bind(ServerEndPoint);

        IPEndPoint ClientIPEndPoint = new IPEndPoint(IPAddress.Any, 1);
        EndPoint ClientEndPoint = (EndPoint)ClientIPEndPoint;

        byte[] Buffer = new byte[1000000000];

        while (true)
        {
          int ClientMessageByte = ServerSocket.ReceiveFrom(Buffer, ref ClientEndPoint);
          string ClientMessage = Encoding.UTF8.GetString(Buffer, 0, ClientMessageByte);
          Regex RegexExit = new Regex(@"^\s*exit\s*\.\s*$", RegexOptions.IgnoreCase);
          if ((RegexExit.Match(ClientMessage)).Success) continue;

          string ServerMessage = "";
          Command Command1 = Function(ClientMessage);
          if (Command1 is ClearDisplay ClearDisplay2)
          {
            ServerMessage = "\nCommand: " + ClearDisplay2.Name + ".\n" +
                            "Parameter:\n" +
                            "Red = " + ClearDisplay2.color.Red + ";\n" +
                            "Green = " + ClearDisplay2.color.Green + ";\n" +
                            "Blue = " + ClearDisplay2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawPixel DrawPixel2)
          {
            ServerMessage = "\nCommand: " + DrawPixel2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawPixel2.X + ";\n" +
                            "Y = " + DrawPixel2.Y + ";\n" +
                            "Red = " + DrawPixel2.color.Red + ";\n" +
                            "Green = " + DrawPixel2.color.Green + ";\n" +
                            "Blue = " + DrawPixel2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawLine DrawLine2)
          {
            ServerMessage = "\nCommand: " + DrawLine2.Name + ".\n" +
                            "Parameter:\n" +
                            "X1 = " + DrawLine2.X1 + ";\n" +
                            "Y1 = " + DrawLine2.Y1 + ";\n" +
                            "X2 = " + DrawLine2.X2 + ";\n" +
                            "Y2 = " + DrawLine2.Y2 + ";\n" +
                            "Red = " + DrawLine2.color.Red + ";\n" +
                            "Green = " + DrawLine2.color.Green + ";\n" +
                            "Blue = " + DrawLine2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawRectangle DrawRectangle2)
          {
            ServerMessage = "\nCommand: " + DrawRectangle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawRectangle2.X + ";\n" +
                            "Y = " + DrawRectangle2.Y + ";\n" +
                            "W = " + DrawRectangle2.W + ";\n" +
                            "H = " + DrawRectangle2.H + ";\n" +
                            "Red = " + DrawRectangle2.color.Red + ";\n" +
                            "Green = " + DrawRectangle2.color.Green + ";\n" +
                            "Blue = " + DrawRectangle2.color.Blue + ".\n\n";
          }
          else if (Command1 is FillRectangle FillRectangle2)
          {
            ServerMessage = "\nCommand: " + FillRectangle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + FillRectangle2.X + ";\n" +
                            "Y = " + FillRectangle2.Y + ";\n" +
                            "W = " + FillRectangle2.W + ";\n" +
                            "H = " + FillRectangle2.H + ";\n" +
                            "Red = " + FillRectangle2.color.Red + ";\n" +
                            "Green = " + FillRectangle2.color.Green + ";\n" +
                            "Blue = " + FillRectangle2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawEllipse DrawEllipse2)
          {
            ServerMessage = "\nCommand: " + DrawEllipse2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawEllipse2.X + ";\n" +
                            "Y = " + DrawEllipse2.Y + ";\n" +
                            "W = " + DrawEllipse2.RadiusX + ";\n" +
                            "H = " + DrawEllipse2.RadiusX + ";\n" +
                            "Red = " + DrawEllipse2.color.Red + ";\n" +
                            "Green = " + DrawEllipse2.color.Green + ";\n" +
                            "Blue = " + DrawEllipse2.color.Blue + ".\n\n";
          }
          else if (Command1 is FillEllipse FillEllipse2)
          {
            ServerMessage = "\nCommand: " + FillEllipse2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + FillEllipse2.X + ";\n" +
                            "Y = " + FillEllipse2.Y + ";\n" +
                            "W = " + FillEllipse2.RadiusX + ";\n" +
                            "H = " + FillEllipse2.RadiusX + ";\n" +
                            "Red = " + FillEllipse2.color.Red + ";\n" +
                            "Green = " + FillEllipse2.color.Green + ";\n" +
                            "Blue = " + FillEllipse2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawCircle DrawCircle2)
          {
            ServerMessage = "\nCommand: " + DrawCircle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawCircle2.X + ";\n" +
                            "Y = " + DrawCircle2.Y + ";\n" +
                            "Radius = " + DrawCircle2.Radius + ";\n" +
                            "Red = " + DrawCircle2.color.Red + ";\n" +
                            "Green = " + DrawCircle2.color.Green + ";\n" +
                            "Blue = " + DrawCircle2.color.Blue + ".\n\n";
          }
          else if (Command1 is FillCircle FillCircle2)
          {
            ServerMessage = "\nCommand: " + FillCircle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + FillCircle2.X + ";\n" +
                            "Y = " + FillCircle2.Y + ";\n" +
                            "Radius = " + FillCircle2.Radius + ";\n" +
                            "Red = " + FillCircle2.color.Red + ";\n" +
                            "Green = " + FillCircle2.color.Green + ";\n" +
                            "Blue = " + FillCircle2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawRoundedRectangle DrawRoundedRectangle2)
          {
            ServerMessage = "\nCommand: " + DrawRoundedRectangle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawRoundedRectangle2.X + ";\n" +
                            "Y = " + DrawRoundedRectangle2.Y + ";\n" +
                            "W = " + DrawRoundedRectangle2.W + ";\n" +
                            "H = " + DrawRoundedRectangle2.H + ";\n" +
                            "Radius = " + DrawRoundedRectangle2.Radius + ";\n" +
                            "Red = " + DrawRoundedRectangle2.color.Red + ";\n" +
                            "Green = " + DrawRoundedRectangle2.color.Green + ";\n" +
                            "Blue = " + DrawRoundedRectangle2.color.Blue + ".\n\n";
          }
          else if (Command1 is FillRoundedRectangle FillRoundedRectangle2)
          {
            ServerMessage = "\nCommand: " + FillRoundedRectangle2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + FillRoundedRectangle2.X + ";\n" +
                            "Y = " + FillRoundedRectangle2.Y + ";\n" +
                            "W = " + FillRoundedRectangle2.W + ";\n" +
                            "H = " + FillRoundedRectangle2.H + ";\n" +
                            "Radius = " + FillRoundedRectangle2.Radius + ";\n" +
                            "Red = " + FillRoundedRectangle2.color.Red + ";\n" +
                            "Green = " + FillRoundedRectangle2.color.Green + ";\n" +
                            "Blue = " + FillRoundedRectangle2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawText DrawText2)
          {
            ServerMessage = "\nCommand: " + DrawText2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawText2.X + ";\n" +
                            "Y = " + DrawText2.Y + ";\n" +
                            "Font = " + DrawText2.Font + ";\n" +
                            "Length = " + DrawText2.Length + ";\n" +
                            "Text = " + DrawText2.Text + ";\n" +
                            "Red = " + DrawText2.color.Red + ";\n" +
                            "Green = " + DrawText2.color.Green + ";\n" +
                            "Blue = " + DrawText2.color.Blue + ".\n\n";
          }
          else if (Command1 is DrawImage DrawImage2)
          {
            ServerMessage = "\nCommand: " + DrawImage2.Name + ".\n" +
                            "Parameter:\n" +
                            "X = " + DrawImage2.X + ";\n" +
                            "Y = " + DrawImage2.Y + ";\n" +
                            "W = " + DrawImage2.W + ";\n" +
                            "H = " + DrawImage2.H + ";\n" +
                            "Data = " + DrawImage2.Data + ".\n\n";
          }
          else if (Command1 is Error Error2)
          {
            ServerMessage = Error2.Text;
          }
          byte[] ServerMessageByte = Encoding.UTF8.GetBytes(ServerMessage);
          ServerSocket.SendTo(ServerMessageByte, ClientEndPoint);
          Invalidate();
        }
      });
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawImage(Canvas, 0, 0);
    }

    private void Form1_Resize(object sender, System.EventArgs e)
    {
      Canvas = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
      CanvasGraphics = Graphics.FromImage(Canvas);
    }
  }
}
