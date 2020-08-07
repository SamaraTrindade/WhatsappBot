using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsappBot.Backend.Abstract
{
    class BotMethod
    {
        private static String systemPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        protected static String path = @"C:\Users\Samar\source\repos\WhatsappBot\WhatsappBot\Drivers\ChromeDriver\";

        protected static String LastInfo { get; set; }

        protected TextBox MyUser { get; set; }

        protected TextBox MyPassword { get; set; }

        protected Button BtnNextPage1 { get; set; }

        protected static OpenFileDialog FileDialog { get; set; }

        protected RichTextBox MyMessage { get; set; }

        protected Button BtnPreviousPage { get; set; }

        protected Button BtnConfirmPage2 { get; set; }

        protected Label LblShow { get; set; }

        protected OpenFileDialog MyPicture { get; set; }

        protected static IWebDriver Driver { get; set; }

        protected IJavaScriptExecutor Executor { get; set; }

        private static IWebElement LoginButton { get; set; }

        protected static IWebElement Email { get; set; }

        protected static IWebElement Password { get; set; }

        protected static IWebElement ManualService { get; set; }

        protected static IWebElement CellPhone { get; set; } // Telefone a ser enviado

        protected static IWebElement NamePT { set; get; } // Nome a ser enviado

        protected static IWebElement Message { get; set; } // Mensagem a ser enviada

        protected static IWebElement Baloon { get; set; } // Balão para abrir a caixa de envio

        protected static IWebElement SearchCellphone { get; set; } // Procura o telefone no filtro

        protected static IWebElement SearchName { get; set; } // Clica na pessoa encontrada pelo filtro

        protected static IWebElement Chat { get; set; } // Chat de conversa(Fecha o chat)

        protected static IWebElement CloseButton { get; set; } // Clica no X para fechar a conversa

        protected static IWebElement ConfirmClose { get; set; } // Confirma o encerramento do chat

        protected static IWebElement SendButton { get; set; } // Botão para envio de mensagem
        
        protected static IWebElement PictureButton { get; set; } // Clica na imagem para sair do site
        protected static IWebElement DialogTitle { get; set; }
        protected static IWebElement Exit { get; set; } // Sai do site

        // Metodos

        private static bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private static void ImplicitWait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        private static DialogResult UltimaPessoa()
        {
            return MessageBox.Show(LastInfo, "Ultima pessoa da lista",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected void Login(String user, String pass)
        {
            ImplicitWait();

            //Login
            Email = Driver.FindElement(By.Id("exampleInputEmail"));
            Email.SendKeys(user);

            //Senha
            Password = Driver.FindElement(By.Id("exampleInputPassword"));
            Password.SendKeys(pass);

            //Botão
            LoginButton = Driver.FindElement(By.Id("btnLogin"));
            LoginButton.Click();

        }

        protected void GoToManualService() // Clicar no serviço manual
        {
            ImplicitWait();
            ManualService = Driver.FindElement(By.XPath("/html/body/aside/nav/div[2]/ul/li[8]/a"));
            ManualService.Click();
        }
        
        private static void UltimoTxt(String nome, String Telefone) // Cria arquivo Txt com o ultimo da planilha
        {
            String NomeArquivo = FileDialog.SafeFileName.Replace("xlsx", "txt");
            String Path = systemPath + @"\UltimoPlanilha\Ultimo_" + NomeArquivo;

            using (StreamWriter sw = File.CreateText(Path))
                sw.WriteLine($"Nome\t\tTelefone\n{nome}\t\t{Telefone}");

        }

        private static void Relatorio(String Prefixo, String nome, String DDD, String Telefone)
        {

            String NomeArquivo = FileDialog.SafeFileName.Replace(".xlsx", ".txt");
            String Path = systemPath + @"\Relatorio\NaoEnviada_" + NomeArquivo;


            if (!File.Exists(Path))
            {
                using (StreamWriter sw = File.CreateText(Path))
                {
                    sw.WriteLine("Prefixo\tNome\tDDD\tTelefone");
                }
            }
            if (File.Exists(Path))
            {
                using (StreamWriter sw = File.AppendText(Path))
                {
                    sw.WriteLine($"{Prefixo}\t{nome}\t{DDD}\t{Telefone}");
                }
            }

        }

        private static void BaloonClick()
        {
            //Balão
            Baloon = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/header/a[3]"));
            Baloon.Click();
        }
        private static void CloseChat(String Telefone) {

            SearchCellphone = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[2]/form/div/div[1]/input"));
            //InputCellphone.Click();
            //Thread.Sleep(3000);
            SearchCellphone.SendKeys($"{Telefone}");

            SearchName = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/div/div/ol/li[1]/a"));
            SearchName.Click();

            //caixa-cliente-2686206 id chat
            ///html/body/div[7]/div[2]/div/div/div/div/div/div/div/div[2]/span[2] Caixa de dialogo
            
            Chat = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/div/div/ol/li[1]/a"));
            Chat.Click();

            CloseButton = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[2]/header/div[2]/a[7]/span"));
            //"/html/body/div[1]/div/div[9]/div/div/div[3]/button[1]"));
            //Thread.Sleep(2000);
            CloseButton.Click();

            ConfirmClose = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[9]/div/div/div[3]/button[1]"));
            ConfirmClose.Click();
        }
        

        private static void CloseWarning()
        {

        }
        protected void SendMessage(String Prefixo, String Nome, String DDD, String Telefone, String Mensagem) // Disparar envio
        {
            ImplicitWait();
            if (Telefone.Contains("-"))
            {
                Telefone = Telefone.Replace("-", String.Empty);
            }
            Nome = Nome.Trim();
            Telefone = Telefone.Replace(" ", String.Empty);
            Telefone = DDD + Telefone;
            BaloonClick();

            if (IsElementPresent(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/header/a[2]/span/i")))
            {

                //"/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/header/a[2]/span/i"));

                NamePT = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[8]/div/div/div[2]/form/div[1]/div[1]/div/input"));
                NamePT.SendKeys(Nome);

                CellPhone = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[8]/div/div/div[2]/form/div[1]/div[2]/div/input"));
                CellPhone.Click();
            }
            else
            {
                //Serviço Manual
                GoToManualService();

                Baloon = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/header/a[2]/span/i"));
                Baloon.Click();
                //Thread.Sleep(4000);
                //Client = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[8]/div/div/div[2]/form/div[1]/div[1]/div/input"));

                NamePT = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[5]/div/div/div/div/div[1]/header/a[3]"));
                NamePT.SendKeys(Nome);

                //Thread.Sleep(4000);

                CellPhone = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[8]/div/div/div[2]/form/div[1]/div[2]/div/input"));
                CellPhone.Click();
                //Thread.Sleep(3000);

            }
            for (int i = 0; i < Telefone.Length; i++)
            {

                CellPhone.SendKeys(Convert.ToString(Telefone[i]));


            }


            Message = Driver.FindElement(By.XPath("/html/body/div[1]/div/div[8]/div/div/div[2]/form/div[3]/div/div/textarea"));


            if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour <= 11)
            {
                Message.SendKeys($"Bom dia, {Nome}, tudo bem? {Mensagem}");
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
            {
                Message.SendKeys($"Boa tarde, {Nome}, tudo bem? {Mensagem}");
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 23)
            {
                Message.SendKeys($"Boa noite, {Nome}, tudo bem? {Mensagem}");
            }

            SendButton = Driver.FindElement(By.Id("btnSendMsg"));
            SendButton.Click();

            LastInfo = $"Nome: {Nome}\nTelefone: {Telefone}";
            UltimoTxt(Nome, Telefone);
            //Boolean IsOkayDisplayed = Driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div/div/div/div[4]/button")).Displayed;
            //Thread.Sleep(7000);
            ///html/body/div[7]/div[2]/div/div/div/div/div/div/div Em atendimento
            while(IsElementPresent(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div")))
            {
                DialogTitle = Driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div/div/div/div[3]/div/div"));
                if (DialogTitle.Text == "Aguarde, sua solicitação está sendo processada")
                {


                }
                else
                {
                    break;
                }
                System.Threading.Thread.Sleep(2000);
            }

            if (IsElementPresent(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div")))
            {
                ImplicitWait();
                DialogTitle = Driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div/div/div/div[3]/div/div"));

                Relatorio(Prefixo, Nome, DDD, Telefone);
                //Pega o botão da janela de erro e clica.
                //GoToManualService();
                if (DialogTitle.Text == "Celular não encontrado")
                {
                    Driver.Navigate().GoToUrl(@"https://painel.zapsac.com/admin/atendimentos");
                    GoToManualService();
                }
                else if (DialogTitle.Text == "Esse cliente já está em atendimento pelo atendente: xxxx xxxx")
                {
                    Driver.Navigate().GoToUrl(@"https://painel.zapsac.com/admin/atendimentos");
                    CloseChat(Telefone);
                    Driver.Navigate().GoToUrl(@"https://painel.zapsac.com/admin/atendimentos");
                    GoToManualService();

                }
            }
            else if (IsElementPresent(By.XPath("/html/body/div[7]/div[2]/div/div/div/div/div/div/div/div[4]/button")) == false)
            {


                //Clica no botão de serviço manual novamente
                GoToManualService();
                CloseChat(Telefone);
                Driver.Navigate().GoToUrl(@"https://painel.zapsac.com/admin/atendimentos");
                

            }

        }
        protected void Quit_Site()
        {

            PictureButton = Driver.FindElement(By.XPath("html/body/div[1]/header/div/div[2]/div/a/img"));
            PictureButton.Click();

            Exit = Driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[2]/div/div/a[2]"));
            Exit.Click();

        }
    }
     
 }




