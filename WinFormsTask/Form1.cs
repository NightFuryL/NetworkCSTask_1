using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;

namespace WinFormsTask
{
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
                txtResult.Clear();

                // Якщо користувач не ввів http/https — додаємо http
                // це зробив щоб не було помилок
                string input = txtHost.Text.Trim();
                if (!input.StartsWith("http"))
                    input = "http://" + input;

                Uri uri = new Uri(input);

                // Визначаємо порт чи це https чи ні 
                int port = uri.Scheme == "https" ? 443 : 80;

                string result = SendHttpRequest(uri, port);

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }
        private static string SendHttpRequest(Uri? uri = null, int port = 80) //метод за сигнатурою з документації переробив та додав https
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            StringBuilder responseBuilder = new StringBuilder();

            #region Документація

            // 1. Отримуємо IP адресу через DNS
            IPHostEntry hostEntry = Dns.GetHostEntry(uri.Host);
            IPAddress ipAddress = hostEntry.AddressList[0];

            // 2. Створюємо endpoint (IP + порт)
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            //Створюємо сокет (TCP)
            using Socket socket = new Socket(
                AddressFamily.InterNetwork, // IPv4
                SocketType.Stream,          // TCP (потоковий)
                ProtocolType.Tcp            // TCP протокол
            );

            socket.Connect(endPoint);

            //Формуємо HTTP GET запит
            string request =
                $"GET {uri.PathAndQuery} HTTP/1.1\r\n" +
                $"Host: {uri.Host}\r\n" +
                $"Connection: close\r\n\r\n";

            byte[] requestBytes = Encoding.UTF8.GetBytes(request);

            #endregion
            #region HTTPS та HTTP
            //Зробив за допомогою ШІ та інтернету бо складно було
            //HTTPS (через SSL)
            if (uri.Scheme == "https")
            {
                using NetworkStream networkStream = new NetworkStream(socket);

                // Створюємо SSL потік поверх TCP
                using SslStream sslStream = new SslStream(
                    networkStream,
                    false,
                    (sender, cert, chain, errors) => true // пропускаємо перевірку сертифікату (для навчання)
                );

                // Аутентифікація (SSL handshake)
                sslStream.AuthenticateAsClient(uri.Host);

                // Відправка запиту
                sslStream.Write(requestBytes);
                sslStream.Flush();

                // Читання відповіді
                byte[] buffer = new byte[1024];
                int bytesRead;

                do
                {
                    bytesRead = sslStream.Read(buffer, 0, buffer.Length);
                    responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
                while (bytesRead > 0);
            }
            else // HTTP
            {
                // Відправка запиту
                socket.Send(requestBytes);

                byte[] buffer = new byte[1024];
                int bytesRead;

                // Читання відповіді
                do
                {
                    bytesRead = socket.Receive(buffer);
                    responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
                while (bytesRead > 0);
            }
            #endregion
            return responseBuilder.ToString();
        }
    }
}