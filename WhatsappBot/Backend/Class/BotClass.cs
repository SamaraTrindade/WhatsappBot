using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappBot.Backend.Abstract;

namespace WhatsappBot
{
    /// <summary>
    /// Classe usada para captura de Nome, Telefone e DDD no excel.
    /// </summary>
    class Info
    {
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String DDD { get; set; }
        public String Prefixo { get; set; }
    }
    class BotClass : BotMethod
    {
        String systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        /// <summary>
        /// Construtor. Irá Pegar os botões da página referente, usar no código
        /// e configurar o ToolTip.
        /// Força o uso de caracteres minúsculos no campo de e-mail.
        /// </summary>
        /// <param name="User">Caixa de texto do usuário(e-mail).</param>
        /// <param name="Password">Caixa de texto da senha.</param>
        /// <param name="Confirm">Botão de confirmação da primeira página.</param>

        public BotClass(TextBox User, TextBox Password, Button Confirm)
        {
            MyUser = User;
            MyPassword = Password;
            BtnNextPage1 = Confirm;

            MyUser.CharacterCasing = CharacterCasing.Lower;

            LastInfo = "";
        }


        /// <summary>
        ///  Construtor. Irá Pegar os botões da página referente, usar no código
        ///  e configurar o ToolTip.
        /// </summary>
        /// <param name="Message">Referente a caixa de mensagem.</param>
        /// <param name="Confirm2">Referente ao botão de confirmação da segunda página.</param>
        /// <param name="Back">Referente ao botão 'voltar' da segunda página.</param>
        public BotClass(RichTextBox Message, Button Confirm2, Button Back)
        {
            MyMessage = Message;
            BtnConfirmPage2 = Confirm2;
            BtnPreviousPage = Back;
            //TooltipPage2();

            /*
            MyMessage.Text = "estou testando o envio de mensagem de bot.\n\n" +
                             "Peço que não responda a essa mensagem.\n" +
                             "Estou enviando um link também:\n\nwww.netflix.com/";*/
        }

        /*
         
         if (IsElementPresent(By.Id("element name"))) 
        { //do if exists
        
        } else 
        { //do if does not exists 
        }
         */

        /// <summary>
        /// Inicia o bot
        /// </summary>
        /// <param name="path">Caminho do arquivo.</param>
        /// <param name="user">E-mail a ser usado na página de login.</param>
        /// <param name="pass">Senha a ser usada na página de login.</param>
        /// <param name="Mensagem">Mensagem a ser usada para envio na página de mensagem.</param>
        [Obsolete]
        public void Iniciar(string path, String user, String pass, String Mensagem, OpenFileDialog MyDialog, CheckBox Foto)
        {
            

            Driver = new ChromeDriver(@"C:\Users\Samar\source\repos\WhatsappBot\WhatsappBot\Drivers\ChromeDriver\");
            FileDialog = MyDialog;
            var infos = new List<Info>();
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            int counter = 0;
            do
            {


                while (reader.Read())
                {
                    if (counter < 2)
                    {
                        counter++;
                        continue;

                    }

                    if (reader.GetValue(1) == null ||
                        reader.GetValue(3) == null ||
                        reader.GetValue(4) == null)
                    {

                    }
                    else
                    {
                        infos.Add(new Info
                        {

                            Nome = reader.GetValue(1).ToString(),
                            DDD = reader.GetValue(3).ToString(),
                            Telefone = reader.GetValue(4).ToString(),

                        });

                    }

                }


            } while (reader.NextResult());

            try
            {

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("no -sandbox");
                
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(@"https://painel.zapsac.com/login");

                Login(user, pass);

                //Modal
                //    VisibleClick(By.XPath("/html/body/div[4]/div[9]"));

                //Serviço Manual
                GoToManualService();
                
                foreach (var info in infos)
                {
                    SendMessage(info.Prefixo, info.Nome, info.DDD, info.Telefone, MyMessage.Text);
                    
                }
                    Quit_Site();
            }
            catch (Exception ex)
            {

                Driver.Manage().Window.Minimize();
                MessageBox.Show(ex.ToString(), "ERRO!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
