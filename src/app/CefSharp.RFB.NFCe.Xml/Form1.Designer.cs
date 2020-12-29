namespace CefSharp.RFB.NFCe.Xml
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.gbxInformacoesNFCe = new System.Windows.Forms.GroupBox();
            this.btnNFCeMontarXml = new System.Windows.Forms.Button();
            this.btnNFCePesquisarAutorizador = new System.Windows.Forms.Button();
            this.btnNFCeSelecionarPastaPedidos = new System.Windows.Forms.Button();
            this.txtNFCePastaPedidos = new System.Windows.Forms.TextBox();
            this.txtNFCeDigestValue = new System.Windows.Forms.TextBox();
            this.txtNFCeChave = new System.Windows.Forms.TextBox();
            this.lblNFCePastaPedidos = new System.Windows.Forms.Label();
            this.lblNFCeDigestValue = new System.Windows.Forms.Label();
            this.lblChave = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlAutorizador = new System.Windows.Forms.Panel();
            this.btnPesquisarPedido = new System.Windows.Forms.Button();
            this.pnlDados.SuspendLayout();
            this.gbxInformacoesNFCe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.gbxInformacoesNFCe);
            this.pnlDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDados.Location = new System.Drawing.Point(0, 0);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(1032, 174);
            this.pnlDados.TabIndex = 0;
            // 
            // gbxInformacoesNFCe
            // 
            this.gbxInformacoesNFCe.Controls.Add(this.btnPesquisarPedido);
            this.gbxInformacoesNFCe.Controls.Add(this.btnNFCeMontarXml);
            this.gbxInformacoesNFCe.Controls.Add(this.btnNFCePesquisarAutorizador);
            this.gbxInformacoesNFCe.Controls.Add(this.btnNFCeSelecionarPastaPedidos);
            this.gbxInformacoesNFCe.Controls.Add(this.txtNFCePastaPedidos);
            this.gbxInformacoesNFCe.Controls.Add(this.txtNFCeDigestValue);
            this.gbxInformacoesNFCe.Controls.Add(this.txtNFCeChave);
            this.gbxInformacoesNFCe.Controls.Add(this.lblNFCePastaPedidos);
            this.gbxInformacoesNFCe.Controls.Add(this.lblNFCeDigestValue);
            this.gbxInformacoesNFCe.Controls.Add(this.lblChave);
            this.gbxInformacoesNFCe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInformacoesNFCe.Location = new System.Drawing.Point(12, 13);
            this.gbxInformacoesNFCe.Name = "gbxInformacoesNFCe";
            this.gbxInformacoesNFCe.Size = new System.Drawing.Size(1008, 148);
            this.gbxInformacoesNFCe.TabIndex = 0;
            this.gbxInformacoesNFCe.TabStop = false;
            this.gbxInformacoesNFCe.Text = "Informações da NFC-e";
            // 
            // btnNFCeMontarXml
            // 
            this.btnNFCeMontarXml.Enabled = false;
            this.btnNFCeMontarXml.Location = new System.Drawing.Point(874, 109);
            this.btnNFCeMontarXml.Name = "btnNFCeMontarXml";
            this.btnNFCeMontarXml.Size = new System.Drawing.Size(128, 33);
            this.btnNFCeMontarXml.TabIndex = 8;
            this.btnNFCeMontarXml.Text = "Montar Arquivo";
            this.btnNFCeMontarXml.UseVisualStyleBackColor = true;
            this.btnNFCeMontarXml.Click += new System.EventHandler(this.btnNFCeMontarXml_Click);
            // 
            // btnNFCePesquisarAutorizador
            // 
            this.btnNFCePesquisarAutorizador.Location = new System.Drawing.Point(598, 20);
            this.btnNFCePesquisarAutorizador.Name = "btnNFCePesquisarAutorizador";
            this.btnNFCePesquisarAutorizador.Size = new System.Drawing.Size(133, 20);
            this.btnNFCePesquisarAutorizador.TabIndex = 2;
            this.btnNFCePesquisarAutorizador.Text = "Pesquisar no Autorizador";
            this.btnNFCePesquisarAutorizador.UseVisualStyleBackColor = true;
            this.btnNFCePesquisarAutorizador.Click += new System.EventHandler(this.btnNFCePesquisarAutorizador_Click);
            // 
            // btnNFCeSelecionarPastaPedidos
            // 
            this.btnNFCeSelecionarPastaPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNFCeSelecionarPastaPedidos.Location = new System.Drawing.Point(598, 80);
            this.btnNFCeSelecionarPastaPedidos.Name = "btnNFCeSelecionarPastaPedidos";
            this.btnNFCeSelecionarPastaPedidos.Size = new System.Drawing.Size(133, 20);
            this.btnNFCeSelecionarPastaPedidos.TabIndex = 7;
            this.btnNFCeSelecionarPastaPedidos.Text = "Selecionar";
            this.btnNFCeSelecionarPastaPedidos.UseVisualStyleBackColor = true;
            this.btnNFCeSelecionarPastaPedidos.Click += new System.EventHandler(this.btnNFCeSelecionarPastaPedidos_Click);
            // 
            // txtNFCePastaPedidos
            // 
            this.txtNFCePastaPedidos.Location = new System.Drawing.Point(128, 80);
            this.txtNFCePastaPedidos.Name = "txtNFCePastaPedidos";
            this.txtNFCePastaPedidos.Size = new System.Drawing.Size(454, 20);
            this.txtNFCePastaPedidos.TabIndex = 6;
            // 
            // txtNFCeDigestValue
            // 
            this.txtNFCeDigestValue.Location = new System.Drawing.Point(128, 50);
            this.txtNFCeDigestValue.Name = "txtNFCeDigestValue";
            this.txtNFCeDigestValue.Size = new System.Drawing.Size(454, 20);
            this.txtNFCeDigestValue.TabIndex = 4;
            // 
            // txtNFCeChave
            // 
            this.txtNFCeChave.Location = new System.Drawing.Point(128, 20);
            this.txtNFCeChave.Name = "txtNFCeChave";
            this.txtNFCeChave.Size = new System.Drawing.Size(454, 20);
            this.txtNFCeChave.TabIndex = 1;
            // 
            // lblNFCePastaPedidos
            // 
            this.lblNFCePastaPedidos.AutoSize = true;
            this.lblNFCePastaPedidos.Location = new System.Drawing.Point(6, 83);
            this.lblNFCePastaPedidos.Name = "lblNFCePastaPedidos";
            this.lblNFCePastaPedidos.Size = new System.Drawing.Size(100, 13);
            this.lblNFCePastaPedidos.TabIndex = 5;
            this.lblNFCePastaPedidos.Text = "* Pasta de Pedidos:";
            // 
            // lblNFCeDigestValue
            // 
            this.lblNFCeDigestValue.AutoSize = true;
            this.lblNFCeDigestValue.Location = new System.Drawing.Point(6, 53);
            this.lblNFCeDigestValue.Name = "lblNFCeDigestValue";
            this.lblNFCeDigestValue.Size = new System.Drawing.Size(111, 13);
            this.lblNFCeDigestValue.TabIndex = 3;
            this.lblNFCeDigestValue.Text = "Digest Value da NF-e:";
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Location = new System.Drawing.Point(6, 23);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(101, 13);
            this.lblChave.TabIndex = 0;
            this.lblChave.Text = "* Chave de Acesso:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // pnlAutorizador
            // 
            this.pnlAutorizador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAutorizador.Location = new System.Drawing.Point(0, 174);
            this.pnlAutorizador.Name = "pnlAutorizador";
            this.pnlAutorizador.Size = new System.Drawing.Size(1032, 511);
            this.pnlAutorizador.TabIndex = 1;
            // 
            // btnPesquisarPedido
            // 
            this.btnPesquisarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarPedido.Location = new System.Drawing.Point(737, 80);
            this.btnPesquisarPedido.Name = "btnPesquisarPedido";
            this.btnPesquisarPedido.Size = new System.Drawing.Size(133, 20);
            this.btnPesquisarPedido.TabIndex = 9;
            this.btnPesquisarPedido.Text = "Pesquisar Arquivo Xml";
            this.btnPesquisarPedido.UseVisualStyleBackColor = true;
            this.btnPesquisarPedido.Click += new System.EventHandler(this.btnPesquisarPedido_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 685);
            this.Controls.Add(this.pnlAutorizador);
            this.Controls.Add(this.pnlDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar NF-e Completa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlDados.ResumeLayout(false);
            this.gbxInformacoesNFCe.ResumeLayout(false);
            this.gbxInformacoesNFCe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.GroupBox gbxInformacoesNFCe;
        private System.Windows.Forms.Button btnNFCeSelecionarPastaPedidos;
        private System.Windows.Forms.TextBox txtNFCePastaPedidos;
        private System.Windows.Forms.TextBox txtNFCeDigestValue;
        private System.Windows.Forms.TextBox txtNFCeChave;
        private System.Windows.Forms.Label lblNFCePastaPedidos;
        private System.Windows.Forms.Label lblNFCeDigestValue;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.Button btnNFCeMontarXml;
        private System.Windows.Forms.Button btnNFCePesquisarAutorizador;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlAutorizador;
        private System.Windows.Forms.Button btnPesquisarPedido;
    }
}

