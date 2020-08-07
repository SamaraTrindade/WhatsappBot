using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappBot.Backend.Abstract;

namespace WhatsappBot
{

    class BotConfig:BotMethod
    {




        /// <summary>
        /// Configuração de tooltip da primeira página
        /// </summary>
        public void TooltipPage1()
        {

            ToolTip tp = new ToolTip();
            tp.SetToolTip(MyUser, "Email do site");
            tp.SetToolTip(MyPassword, "Senha do site");
            tp.SetToolTip(BtnNextPage1, "Clique aqui para ser direcionado para\n"+
                                        "a proxima página");


        }

        /// <summary>
        /// Configuração de tooltip da segunda página.
        /// </summary>
        public void TooltipPage2()
        {
            
            ToolTip tp = new ToolTip();
            tp.SetToolTip(MyMessage, "Digite a mensagem que deseja enviar para os contatos");
            tp.SetToolTip(BtnPreviousPage, "Clique aqui para voltar para a página de login");
            tp.SetToolTip(BtnConfirmPage2, "Clique aqui para confirmar e o bot acessar o site.");

        }

        public void HidePassword(Label show)
        {
            LblShow = show;
            if (MyPassword.PasswordChar == '*')
            {
                MyPassword.PasswordChar = '\0';
                LblShow.Text = "Esconder\nSenha";
                LblShow.ForeColor = System.Drawing.Color.Green;

            }
            else if (MyPassword.PasswordChar == '\0')
            {
                MyPassword.PasswordChar = '*';
                LblShow.Text = "Mostrar\nSenha";
                LblShow.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    }


