namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(txtUri.Text);

                response.EnsureSuccessStatusCode();

                await PrintResponseDataAsync(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PrintResponseDataAsync(HttpResponseMessage response)
        {
            rtbResult.Clear();
            rtbResult.AppendText("=========== HTTP RESPONSE ============" + Environment.NewLine);
            rtbResult.AppendText("Status:" + Environment.NewLine);
            rtbResult.AppendText($"{(int)response.StatusCode} " + $"{response.ReasonPhrase} " + $"HTTP/{response.Version}" + Environment.NewLine + Environment.NewLine);
            rtbResult.AppendText("Headers:" + Environment.NewLine);
            foreach (var header in response.Headers)
            {
                rtbResult.AppendText(
                    $"{header.Key}: " +
                    $"{string.Join(", ", header.Value)}" +
                    Environment.NewLine);
            }

            rtbResult.AppendText(Environment.NewLine + "Body:" + Environment.NewLine);
            string responseBody = await response.Content.ReadAsStringAsync();
            rtbResult.AppendText(responseBody);
        }
    }
}
