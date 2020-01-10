using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation; //reference para storyboard
using NBLsystem;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace NBLsystem {
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window {
        Storyboard storyboard = new Storyboard();
        Pages.Register.Client.ClientRegister Client;
        bool reverse = false;

        //VARIAVEIS DO CHAT
        // Trata o nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;
        //=================================


        private delegate void AtualizaStatusCallback(string strMensagem);
        public Principal(string nome, int idUser, int permissao) {
            
            InitializeComponent();
            lblNomeUsuario.Content = nome;



            //DATA E HORA =========================================
            lblData.Content = DateTime.Now.ToString("dd/MM/yyyy");
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.lbl_Hora.Content = DateTime.Now.ToString("HH:mm:ss");
            }, this.Dispatcher);
            //====================================================

            //PERMISSAO
            if (permissao == 1) lblPermissao.Content = "Administrador";
            else if (permissao == 1) lblPermissao.Content = "Usuário";
            else lblPermissao.Content = "Visitante";
            

        }

        private void button_Click(object sender, RoutedEventArgs e) {
            if (reverse == false) {
                hamburgueAnimationOpen();
            } else {
                hamburgueAnimationClose();
            }
        }

        private void btnCloseWindows_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if(MessageBox.Show("Saindo do Sistema!\nSalve todas suas operações em andamento.\nClique em OK para sair:","Atenção!!!",MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK) {
                // Fecha as conexões, streams, etc...
                this.Close();
            }
            
        }

        private void btnMinimizeWindows_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCadastrar_click(object sender, RoutedEventArgs e) {
            
            if(reverse == false) {

                cadastrarAnimationOpen();
            } else {
                cadastrarAnimationClose();      
            }
        }// BTN CADASTRAR


        private void btnConsultar_Click(object sender, RoutedEventArgs e) {

            if (reverse == false) {
                consultarAnimationOpen();
            } else {
                consultarAnimationClose();
            }
        }// BTN CONSULTAR


        /* ============
         * ============
         * ANIMAÇÕES - METODOS
         * ============
         * ============
         */
        public void editarPerfil() {
            storyboard = this.FindResource("editarPerfil") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
        }
        public bool hamburgueAnimationOpen() {
            storyboard = this.FindResource("HamburgueMenu") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            return reverse = true;
        }

        public bool hamburgueAnimationClose() {
            storyboard = this.FindResource("HamburgueMenu_reverse") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            return reverse = false;
        }
        public bool cadastrarAnimationOpen() {
            storyboard = this.FindResource("cadastrar") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            return reverse = true;
            btnConsultar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        public bool cadastrarAnimationClose() {
            storyboard = this.FindResource("cadastrar_reverse") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            return reverse = false;
        }

        public bool consultarAnimationOpen() {
            storyboard = this.FindResource("consultar") as Storyboard; //Animação 3
            storyboard.Begin();
            return reverse = true;
            btnCadastrar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        public bool consultarAnimationClose() {
            storyboard = this.FindResource("consultar_reverse") as Storyboard; //Animação 3
            storyboard.Begin();
            return reverse = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            Client = new Pages.Register.Client.ClientRegister();
            Client.Show();
        }

        private void lblEditarPerfil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            editarPerfil();
        }

        private void btnFecharEditarPerfil_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            storyboard = this.FindResource("editarPerfil") as Storyboard; // ANIMAÇÃO 2
            storyboard.Remove();
        }

        private void btnCadastrar_estoque_Click(object sender, RoutedEventArgs e) {
            Pages.Register.Stock.StockRegister StockRegister = new Pages.Register.Stock.StockRegister();
            StockRegister.Show();
        }


        private void txtMensagem_GotFocus(object sender, RoutedEventArgs e) {
            if (txtMensagem.Text == "Digite sua mensagem...") {
                txtMensagem.Text = "";
            }
        }

        private void txtMensagem_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(txtMensagem.Text)) {
                txtMensagem.Text = "Digite sua mensagem...";
            }
        }

        private void btnEnviarMsg_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Em desenvolvimento", "Atencão", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e) {
            Login.login Login = new NBLsystem.Login.login();
            Login.Show();
            this.Close();
        }




        /*    public void OnApplicationExit(object sender, EventArgs e) {
                if (Conectado == true) {
                    // Fecha as conexões, streams, etc...
                    Conectado = false;
                  //  stwEnviador.Close();
                 //   strReceptor.Close();
                 //   tcpServidor.Close();

                }
            }*/
        /*
         * 
         *  CODIGOS PARA O CHAT - FIM 
         * 
         * 
         * 
        */


    }
}
