namespace FTP_Uploader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcrtlPrincipal = new TabControl();
            tpgImagens = new TabPage();
            lblProgresso = new Label();
            progressBar1 = new ProgressBar();
            listView1 = new ListView();
            flpContainer = new FlowLayoutPanel();
            btnSelecionar = new Button();
            btnRemoverSel = new Button();
            btnLimpaLista = new Button();
            btnEnviar = new Button();
            btnCancelar = new Button();
            btnCopiarUrls = new Button();
            tpgConfigs = new TabPage();
            button1 = new Button();
            lblSenha = new Label();
            lblUsuario = new Label();
            lblProtocolo = new Label();
            lblNumPorta = new Label();
            lblUrl = new Label();
            lblPasta = new Label();
            lblHost = new Label();
            cboProtocolo = new ComboBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            txtPorta = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txtHost = new TextBox();
            chkValidarTipo = new CheckBox();
            chkSobrescrever = new CheckBox();
            tcrtlPrincipal.SuspendLayout();
            tpgImagens.SuspendLayout();
            flpContainer.SuspendLayout();
            tpgConfigs.SuspendLayout();
            SuspendLayout();
            // 
            // tcrtlPrincipal
            // 
            tcrtlPrincipal.Controls.Add(tpgImagens);
            tcrtlPrincipal.Controls.Add(tpgConfigs);
            tcrtlPrincipal.Dock = DockStyle.Fill;
            tcrtlPrincipal.Location = new Point(0, 0);
            tcrtlPrincipal.Name = "tcrtlPrincipal";
            tcrtlPrincipal.SelectedIndex = 0;
            tcrtlPrincipal.Size = new Size(1111, 579);
            tcrtlPrincipal.TabIndex = 0;
            // 
            // tpgImagens
            // 
            tpgImagens.Controls.Add(lblProgresso);
            tpgImagens.Controls.Add(progressBar1);
            tpgImagens.Controls.Add(listView1);
            tpgImagens.Controls.Add(flpContainer);
            tpgImagens.Location = new Point(4, 29);
            tpgImagens.Name = "tpgImagens";
            tpgImagens.Padding = new Padding(3);
            tpgImagens.Size = new Size(1103, 546);
            tpgImagens.TabIndex = 0;
            tpgImagens.Text = "Imagens";
            tpgImagens.UseVisualStyleBackColor = true;
            // 
            // lblProgresso
            // 
            lblProgresso.AutoSize = true;
            lblProgresso.Location = new Point(515, 517);
            lblProgresso.Name = "lblProgresso";
            lblProgresso.Size = new Size(69, 20);
            lblProgresso.TabIndex = 3;
            lblProgresso.Text = "Progesso";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.ForeColor = Color.LawnGreen;
            progressBar1.Location = new Point(3, 510);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1097, 33);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(3, 84);
            listView1.Name = "listView1";
            listView1.Size = new Size(1097, 459);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // flpContainer
            // 
            flpContainer.Controls.Add(btnSelecionar);
            flpContainer.Controls.Add(btnRemoverSel);
            flpContainer.Controls.Add(btnLimpaLista);
            flpContainer.Controls.Add(btnEnviar);
            flpContainer.Controls.Add(btnCancelar);
            flpContainer.Controls.Add(btnCopiarUrls);
            flpContainer.Controls.Add(chkValidarTipo);
            flpContainer.Controls.Add(chkSobrescrever);
            flpContainer.Dock = DockStyle.Top;
            flpContainer.Location = new Point(3, 3);
            flpContainer.Name = "flpContainer";
            flpContainer.Size = new Size(1097, 81);
            flpContainer.TabIndex = 0;
            // 
            // btnSelecionar
            // 
            btnSelecionar.Location = new Point(3, 3);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(175, 35);
            btnSelecionar.TabIndex = 0;
            btnSelecionar.Text = "Selecionar Imagens...";
            btnSelecionar.UseVisualStyleBackColor = true;
            btnSelecionar.Click += btnSelecionar_Click;
            // 
            // btnRemoverSel
            // 
            btnRemoverSel.Location = new Point(184, 3);
            btnRemoverSel.Name = "btnRemoverSel";
            btnRemoverSel.Size = new Size(175, 35);
            btnRemoverSel.TabIndex = 0;
            btnRemoverSel.Text = "Remover Selecionados";
            btnRemoverSel.UseVisualStyleBackColor = true;
            // 
            // btnLimpaLista
            // 
            btnLimpaLista.Location = new Point(365, 3);
            btnLimpaLista.Name = "btnLimpaLista";
            btnLimpaLista.Size = new Size(175, 35);
            btnLimpaLista.TabIndex = 0;
            btnLimpaLista.Text = "Limpar Lista";
            btnLimpaLista.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(546, 3);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(175, 35);
            btnEnviar.TabIndex = 0;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(727, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(175, 35);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCopiarUrls
            // 
            btnCopiarUrls.Location = new Point(908, 3);
            btnCopiarUrls.Name = "btnCopiarUrls";
            btnCopiarUrls.Size = new Size(175, 35);
            btnCopiarUrls.TabIndex = 0;
            btnCopiarUrls.Text = "Copiar Urls";
            btnCopiarUrls.UseVisualStyleBackColor = true;
            // 
            // tpgConfigs
            // 
            tpgConfigs.Controls.Add(button1);
            tpgConfigs.Controls.Add(lblSenha);
            tpgConfigs.Controls.Add(lblUsuario);
            tpgConfigs.Controls.Add(lblProtocolo);
            tpgConfigs.Controls.Add(lblNumPorta);
            tpgConfigs.Controls.Add(lblUrl);
            tpgConfigs.Controls.Add(lblPasta);
            tpgConfigs.Controls.Add(lblHost);
            tpgConfigs.Controls.Add(cboProtocolo);
            tpgConfigs.Controls.Add(textBox4);
            tpgConfigs.Controls.Add(textBox3);
            tpgConfigs.Controls.Add(txtPorta);
            tpgConfigs.Controls.Add(textBox2);
            tpgConfigs.Controls.Add(textBox1);
            tpgConfigs.Controls.Add(txtHost);
            tpgConfigs.Location = new Point(4, 29);
            tpgConfigs.Name = "tpgConfigs";
            tpgConfigs.Padding = new Padding(3);
            tpgConfigs.Size = new Size(1103, 546);
            tpgConfigs.TabIndex = 1;
            tpgConfigs.Text = "Configurações";
            tpgConfigs.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(860, 279);
            button1.Name = "button1";
            button1.Size = new Size(175, 40);
            button1.TabIndex = 3;
            button1.Text = "Testar Conexão";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(884, 43);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(52, 20);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(590, 43);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuário:";
            // 
            // lblProtocolo
            // 
            lblProtocolo.AutoSize = true;
            lblProtocolo.Location = new Point(64, 130);
            lblProtocolo.Name = "lblProtocolo";
            lblProtocolo.Size = new Size(158, 20);
            lblProtocolo.TabIndex = 2;
            lblProtocolo.Text = "Selecione o Protocolo:";
            // 
            // lblNumPorta
            // 
            lblNumPorta.AutoSize = true;
            lblNumPorta.Location = new Point(371, 43);
            lblNumPorta.Name = "lblNumPorta";
            lblNumPorta.Size = new Size(46, 20);
            lblNumPorta.TabIndex = 2;
            lblNumPorta.Text = "Porta:";
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(420, 253);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(125, 20);
            lblUrl.TabIndex = 2;
            lblUrl.Text = "Base URL Pública:";
            // 
            // lblPasta
            // 
            lblPasta.AutoSize = true;
            lblPasta.Location = new Point(73, 253);
            lblPasta.Name = "lblPasta";
            lblPasta.Size = new Size(168, 20);
            lblPasta.TabIndex = 2;
            lblPasta.Text = "Informe a pasta remota:";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(126, 43);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(43, 20);
            lblHost.TabIndex = 2;
            lblHost.Text = "Host:";
            // 
            // cboProtocolo
            // 
            cboProtocolo.FormattingEnabled = true;
            cboProtocolo.Items.AddRange(new object[] { "FTP", "SFTP" });
            cboProtocolo.Location = new Point(20, 163);
            cboProtocolo.Name = "cboProtocolo";
            cboProtocolo.Size = new Size(248, 28);
            cboProtocolo.TabIndex = 1;
            cboProtocolo.SelectedIndexChanged += cboProtocolo_SelectedIndexChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(798, 76);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(237, 27);
            textBox4.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(505, 76);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(238, 27);
            textBox3.TabIndex = 0;
            // 
            // txtPorta
            // 
            txtPorta.Location = new Point(343, 76);
            txtPorta.Name = "txtPorta";
            txtPorta.Size = new Size(107, 27);
            txtPorta.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(343, 286);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(279, 27);
            textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 286);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 27);
            textBox1.TabIndex = 0;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(20, 76);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(279, 27);
            txtHost.TabIndex = 0;
            // 
            // chkValidarTipo
            // 
            chkValidarTipo.AutoSize = true;
            chkValidarTipo.Location = new Point(3, 44);
            chkValidarTipo.Name = "chkValidarTipo";
            chkValidarTipo.Size = new Size(188, 24);
            chkValidarTipo.TabIndex = 1;
            chkValidarTipo.Text = "Validar tipo da Imagem";
            chkValidarTipo.UseVisualStyleBackColor = true;
            // 
            // chkSobrescrever
            // 
            chkSobrescrever.AutoSize = true;
            chkSobrescrever.Location = new Point(197, 44);
            chkSobrescrever.Name = "chkSobrescrever";
            chkSobrescrever.Size = new Size(177, 24);
            chkSobrescrever.TabIndex = 2;
            chkSobrescrever.Text = "Sobrescrever se existir";
            chkSobrescrever.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 579);
            Controls.Add(tcrtlPrincipal);
            Name = "Form1";
            Text = "Uploader FTP";
            tcrtlPrincipal.ResumeLayout(false);
            tpgImagens.ResumeLayout(false);
            tpgImagens.PerformLayout();
            flpContainer.ResumeLayout(false);
            flpContainer.PerformLayout();
            tpgConfigs.ResumeLayout(false);
            tpgConfigs.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcrtlPrincipal;
        private TabPage tpgImagens;
        private TabPage tpgConfigs;
        private FlowLayoutPanel flpContainer;
        private ComboBox cboProtocolo;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox txtPorta;
        private TextBox txtHost;
        private Button btnSelecionar;
        private Button btnRemoverSel;
        private Button btnLimpaLista;
        private Button btnEnviar;
        private Button btnCancelar;
        private Button btnCopiarUrls;
        private ListView listView1;
        private Label lblSenha;
        private Label lblUsuario;
        private Label lblProtocolo;
        private Label lblNumPorta;
        private Label lblHost;
        private Label lblUrl;
        private Label lblPasta;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label lblProgresso;
        private ProgressBar progressBar1;
        private CheckBox chkValidarTipo;
        private CheckBox chkSobrescrever;
    }
}
