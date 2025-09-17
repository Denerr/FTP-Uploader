using System.Net;

namespace FTP_Uploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string BaseUrlPublica = "https://scotconsultoria.com.br/bancoImagensUP/";

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
            public string BasicPublicUrl { get; set; }

        }

        FTPSetting _ftp = new FTPSetting
        {
            Host = "147.79.95.20",
            Username = "u861738622",
            Password = "Carona@#@#7339",
            Port = "21",
            Protocol = "FTP",
            RemotePath = "/domains/scotconsultoria.com.br/public_html/bancoImagensUP",
            BasicPublicUrl = "https://scotconsultoria.com.br/bancoImagensUP/"
        };

        FTPSetting _ftp_teste = new FTPSetting
        {
            Host = "ftp.scot.agropecuaria.ws",
            Username = "scot",
            Password = "Malboro@102030",
            Port = "80",
            Protocol = "FTP",
            RemotePath = "/public_html/dener-teste",
            BasicPublicUrl = "http://scot.agropecuaria.ws/dener-teste/"
        };

        private void EnsureListViewConfigured()
        {
            if (lvArquivos.View != View.Details)
                lvArquivos.View = View.Details;

            lvArquivos.FullRowSelect = true;
            lvArquivos.GridLines = true;

            if (lvArquivos.Columns.Count == 0)
            {
                lvArquivos.Columns.Add("Nome", 300);
                lvArquivos.Columns.Add("Tamanho", 120);
                lvArquivos.Columns.Add("Status", 120);
                lvArquivos.Columns.Add("URL", 300);
            }
        }

        private bool JaListado(string fullPath)
        {
            foreach (ListViewItem it in lvArquivos.Items)
            {
                if (it.Tag is string existing && string.Equals(existing, fullPath, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private string FormataTamanho(long bytes)
        {
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;

            if (bytes >= GB) return $"{bytes / (double)GB:0.##} GB";
            if (bytes >= MB) return $"{bytes / (double)MB:0.##} MB";
            if (bytes >= KB) return $"{bytes / (double)KB:0.##} KB";
            return $"{bytes} B";
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Selecione as imagens";
                    ofd.Filter =
                        "Imagens|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.tif;*.webp;*.jfif;*.heic|Todos os arquivos|*.*";
                    ofd.Multiselect = true;
                    ofd.CheckFileExists = true;

                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    EnsureListViewConfigured();

                    foreach (var filePath in ofd.FileNames)
                    {
                        if (!File.Exists(filePath)) continue;

                        // Evita duplicatas
                        if (JaListado(filePath)) continue;

                        var fi = new FileInfo(filePath);
                        var item = new ListViewItem(fi.Name);
                        item.SubItems.Add(FormataTamanho(fi.Length));
                        item.SubItems.Add("Não Enviado");
                        item.Tag = fi.FullName;

                        lvArquivos.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar imagens: \n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProtocolo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var arquivos = e.Argument as List<string>;
            var linksGerados = new List<string>();

            int total = arquivos.Count;
            for (int i = 0; i <total; i++)
            {
                string fullPath = arquivos[i];
                string fileName = Path.GetFileName(fullPath);

                try
                {
                    if (_ftp_teste.Protocol != "FTP")
                    {
                        throw new NotSupportedException("Somente protocolo FTP simples implementado até o momento.");
                    }

                    string remoteUri = $"ftp://{_ftp_teste.Host}:{_ftp_teste.Port}{_ftp_teste.RemotePath}/{Uri.EscapeDataString(fileName)}";

                    // Prepara a request
                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(remoteUri);
                    req.Method = WebRequestMethods.Ftp.UploadFile;
                    req.Credentials = new NetworkCredential(_ftp_teste.Username, _ftp_teste.Password);
                    req.UseBinary = true;
                    req.KeepAlive = false;
                    req.EnableSsl = false; // mude para true se for FTPS
                    req.Timeout = 20000;

                    // Envio em chunks
                    const int bufferSize = 32 * 1024; //32KB
                    byte[] buffer = new byte[bufferSize];
                    long totalBytes = new FileInfo(fullPath).Length;
                    long sent = 0;

                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    using (var rs = req.GetRequestStream())
                    {
                        int read;
                        while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            rs.Write(buffer, 0, read);
                            sent += read;

                            // Progresso geral (0..100)
                            int overallPct = (int)((i + (sent / (double)totalBytes)) / total * 100.0);

                            // Reporta progresso do item i (UserState carrega índice, status, url provisória vazia)
                            backgroundWorker.ReportProgress(
                                overallPct,
                                Tuple.Create(i, $"enviando... {(int)(sent * 100.0 / totalBytes)}%", "")
                            );
                        }
                    }

                    using (var resp = (FtpWebResponse)req.GetResponse())
                    {
                        // Se chegou aqui, deu certo
                    }

                    // Monta o link público presumindo public_html => / no site
                    string linkPublico = $"{_ftp_teste.BasicPublicUrl}/{Uri.EscapeUriString(fileName)}";
                    linksGerados.Add(linkPublico);

                    // Atualiza status: enviado
                    backgroundWorker.ReportProgress(
                        (int)((i + 1) / (double)total * 100.0),
                        Tuple.Create(i, "enviado", linkPublico)
                    );
                }
                catch (Exception ex)
                {
                    // Caso falhe, atualiza o status para erro

                    backgroundWorker.ReportProgress(
                        (int)((i + 1) / (double)total * 100.0),
                        Tuple.Create(i, $"erro: {ex.Message}", "")
                    );
                }
            }

            e.Result = linksGerados;
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblProgresso.Text = $"Progresso: {e.ProgressPercentage}%";

            // Lê o Tuple<int index, string status, string url>
            if (e.UserState is Tuple<int, string, string> info)
            {
                int index = info.Item1;
                string status = info.Item2;
                string url = info.Item3;

                if (index >= 0 && index < lvArquivos.Items.Count)
                {
                    var it = lvArquivos.Items[index];
                    it.SubItems[2].Text = status;

                    // Se quiser, você pode guardar a URL final no Tag2 (ex.: Dictionary) ou
                    // até adicionar uma coluna "Link" depois. Aqui mantemos só o status.
                    it.ToolTipText = string.IsNullOrEmpty(url) ? null : url; // dica rápida no hover
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblProgresso.Text = "Upload concluído!";

            var links = e.Result as List<string> ?? new List<string>();
            if (links.Count > 0)
            {
                string texto = string.Join(Environment.NewLine, links);
                try
                {
                    Clipboard.SetText(texto);
                    MessageBox.Show(
                        "Upload concluído! Os links foram copiados para a área de transferência:\n\n" + texto,
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    // Em ambientes sem clipboard disponível
                    MessageBox.Show(
                        "Upload concluído! Seguem os links gerados:\n\n" + texto,
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Processo concluído. Nenhum link gerado (falhas ou lista vazia).",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    Host = "ftp.scot.agropecuaria.ws",
                    Username = "scot",
                    Password = "Malboro@102030",
                    Port = "80",
                    Protocol = "FTP",
                    RemotePath = "/public_html/dener-teste",
                    BasicPublicUrl = "http://scot.agropecuaria.ws/dener-teste/"
                };

                if (_ftp_teste.Protocol == "FTP")
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

        private void btnLimpaLista_Click(object sender, EventArgs e)
        {
            if (lvArquivos.Items.Count == 0)
            {
                MessageBox.Show("A lista já está vazia.",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Tem certeza que deseja limpar a lista de arquivos?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                lvArquivos.Items.Clear();
                MessageBox.Show("Lista de arquivos limpa com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoverSel_Click(object sender, EventArgs e)
        {
            if (lvArquivos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um arquivo para remover.",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Tem certeza que deseja remover {lvArquivos.SelectedItems.Count} arquivo(s) da lista?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ListViewItem[] itensSelecionados = new ListViewItem[lvArquivos.SelectedItems.Count];
                lvArquivos.SelectedItems.CopyTo(itensSelecionados, 0);

                foreach (var item in itensSelecionados)
                {
                    lvArquivos.Items.Remove(item);
                }

                MessageBox.Show("Arquivos removidos com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (lvArquivos.Items.Count == 0)
            {
                MessageBox.Show("Não há arquivos na lista para enviar.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var arquivos = new List<string>();
            for (int i = 0; i < lvArquivos.Items.Count; i++)
            {
                var it = lvArquivos.Items[i];
                if (it.Tag is string fullPath && File.Exists(fullPath))
                {
                    it.SubItems[2].Text = "Enviando...";
                    arquivos.Add(fullPath);
                }
                else
                {
                    it.SubItems[2].Text = "Arquivo inválido";
                }
            }

            if (arquivos.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo válido para enviar.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync(arquivos);
        }
    }
}
