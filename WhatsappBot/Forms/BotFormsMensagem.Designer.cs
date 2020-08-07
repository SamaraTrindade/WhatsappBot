namespace WhatsappBot
{
    partial class Mensagem
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
            this.label1 = new System.Windows.Forms.Label();
            this.RTxtMensagem = new System.Windows.Forms.RichTextBox();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.MyDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnBack = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimoDaPlanilhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CbPicture = new System.Windows.Forms.CheckBox();
            this.MyPicture = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(45, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mensagem";
            // 
            // RTxtMensagem
            // 
            this.RTxtMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RTxtMensagem.Location = new System.Drawing.Point(163, 94);
            this.RTxtMensagem.Name = "RTxtMensagem";
            this.RTxtMensagem.Size = new System.Drawing.Size(312, 119);
            this.RTxtMensagem.TabIndex = 1;
            this.RTxtMensagem.Text = "";
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Location = new System.Drawing.Point(237, 267);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.BtnPesquisar.TabIndex = 4;
            this.BtnPesquisar.Text = "Pesquisar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // MyDialog
            // 
            this.MyDialog.FileName = "openFileDialog1";
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(49, 267);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(75, 23);
            this.BtnBack.TabIndex = 4;
            this.BtnBack.Text = "Voltar";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(498, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ultimoDaPlanilhaToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // ultimoDaPlanilhaToolStripMenuItem
            // 
            this.ultimoDaPlanilhaToolStripMenuItem.Name = "ultimoDaPlanilhaToolStripMenuItem";
            this.ultimoDaPlanilhaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ultimoDaPlanilhaToolStripMenuItem.Text = "Ultimo da planilha";
            this.ultimoDaPlanilhaToolStripMenuItem.Click += new System.EventHandler(this.ultimoDaPlanilhaToolStripMenuItem_Click);
            // 
            // CbPicture
            // 
            this.CbPicture.AutoSize = true;
            this.CbPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbPicture.Location = new System.Drawing.Point(369, 234);
            this.CbPicture.Name = "CbPicture";
            this.CbPicture.Size = new System.Drawing.Size(54, 20);
            this.CbPicture.TabIndex = 6;
            this.CbPicture.Text = "Foto";
            this.CbPicture.UseVisualStyleBackColor = true;
            this.CbPicture.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MyPicture
            // 
            this.MyPicture.FileName = "openFileDialog1";
            // 
            // Mensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 302);
            this.Controls.Add(this.CbPicture);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.RTxtMensagem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Mensagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mensagem_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RTxtMensagem;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.OpenFileDialog MyDialog;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ultimoDaPlanilhaToolStripMenuItem;
        private System.Windows.Forms.CheckBox CbPicture;
        private System.Windows.Forms.OpenFileDialog MyPicture;
    }
}