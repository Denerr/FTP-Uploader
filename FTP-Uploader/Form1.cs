using System.Net;

namespace FTP_Uploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct FTPSetting
        {
            public string Host { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string RemotePath { get; set; }
            public string Port { get; set; }
            public string Protocol { get; set; } // "FTP" or "SFTP"
            public string Filename { get; set; }
            public string FullName { get; set; }

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void cboProtocolo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblProgresso.Text = $"Progresso: {e.ProgressPercentage}%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblProgresso.Text = "Upload concluído!";
        }

        private void btnTesteConect_Click(object sender, EventArgs e)
        {
            try
            {
                FTPSetting ftp = new FTPSetting
                {
                    //Host = txtHost.Text,
                    //Username = txtUsuario.Text,
                    //Password = txtSenha.Text,
                    //RemotePath = txtCaminhoPasta.Text,
                    //Port = txtPorta.Text,
                    //Protocol = cboProtocolo.SelectedItem.ToString()
                    Host = "147.79.95.20",
                    Username = "u861738622",
                    Password = "Carona@#@#7339",
                    Port = "21",
                    Protocol = "FTP",
                    RemotePath = "/domains/scotconsultoria.com.br/public_html/bancoImagensUP"
                };

                if (ftp.Protocol == "FTP")
                {
                    string uri = $"ftp://{ftp.Host}:{ftp.Port}{ftp.RemotePath}";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    request.Credentials = new NetworkCredential(ftp.Username, ftp.Password);
                    request.EnableSsl = false;
                    request.Timeout = 5000; // 5 segundos

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        MessageBox.Show($"Conexão bem-sucedida! Status: {response.StatusDescription}");
                    }
                }
                else
                {
                    MessageBox.Show("Protocolo SFTP não implementado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conexão: {ex.Message}");
            }

        }
    }
}
