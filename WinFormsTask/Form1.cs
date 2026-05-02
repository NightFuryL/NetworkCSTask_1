using System.Net;
using System.Net.Sockets;
using System.Text;
namespace WinFormsTask;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnSendRequest_Click(object sender, EventArgs e)
    {
        try
        {
            int serverPort = 8080;
            IPAddress serverAddress = IPAddress.Loopback; //127.0.0.1
            IPEndPoint serverEP = new IPEndPoint(serverAddress, serverPort);
            using Socket clientSocket = new Socket(
                AddressFamily.InterNetwork,//IPv4
                SocketType.Stream,
                ProtocolType.Tcp
                );
            clientSocket.Connect(serverEP);
            string request = "GET / HTTP/1.1\r\nHost: localHost\r\nConenction: close\r\n\r\n";
            clientSocket.Send(Encoding.UTF8.GetBytes(request));
            byte[] buffer = new byte[1024];
            int bytesRead;
            txtResult.Clear();
            do
            {
                bytesRead = clientSocket.Receive(buffer);
                string receiveString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                txtResult.AppendText(receiveString);
            } while (bytesRead > 0);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"ERROR: {ex.Message}");
        }
    }
}
