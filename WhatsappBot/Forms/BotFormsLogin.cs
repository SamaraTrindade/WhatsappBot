using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappBot.Backend.Abstract;

namespace WhatsappBot
{
    public partial class BotFormsLogin : Form
    {
        BotClass B;
       
        public BotFormsLogin()
        {
           
            InitializeComponent();
            B = new BotClass(TxtUser,TxtPass,BtnPesquisar);
            
           
        }


        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            
            if(String.IsNullOrEmpty(TxtUser.Text) &&
                    String.IsNullOrEmpty(TxtPass.Text))
            {
                
                MessageBox.Show("Os dois campos estão vazios.", "ERRO!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (String.IsNullOrEmpty(TxtUser.Text))
               
            {
                MessageBox.Show("O campo do usuário está vazio.", "ERRO!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (String.IsNullOrEmpty(TxtPass.Text))
            {
                MessageBox.Show("O campo da senha está vazio.", "ERRO!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Mensagem m = new Mensagem(TxtUser.Text, TxtPass.Text,this);

                this.Visible = false;
                m.Visible = true;
                
            }

            
        }

        

        private void abrirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LblShow_Click(object sender, EventArgs e)
        {
           // B.HidePassword(LblShow);
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BtnPesquisar.PerformClick();
            }
        }
    }
}
