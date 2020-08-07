using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsappBot
{
    public partial class Mensagem : Form
    {
        BotClass B;
        public String User { get; set; }
        public String Pass { get; set; }
        public Form PreviousPage { get; set; }
        public Mensagem(String User, String Password,Form page)
        {
            InitializeComponent();
            this.User = User;
            this.Pass = Password;
            PreviousPage = page;
            B = new BotClass(RTxtMensagem,BtnPesquisar,BtnBack);
        }

        [Obsolete]
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MyDialog.Filter = "(xlsx) | *.xlsx";
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
               
                B.Iniciar(MyDialog.FileName, User, Pass, RTxtMensagem.Text, MyDialog,CbPicture);



            }
            else
            {
                MessageBox.Show("Este arquivo não é do tipo .xlsx", "ERRO!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            
            PreviousPage.Visible = true;
            this.Visible = false;
        }

        private void Mensagem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ultimoDaPlanilhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B.UltimaPessoa();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CbPicture.Checked)
            {
                MyPicture.Filter = "(JPG, JPEG, PNG, PDF) | *.jpg; *.jpeg; *.pdf; *.png";
                if (MyPicture.ShowDialog() == DialogResult.OK)
                {
                    B.IsPicturePress(MyPicture);

                }
                else
                {

                }
            }
        }
    }
}
