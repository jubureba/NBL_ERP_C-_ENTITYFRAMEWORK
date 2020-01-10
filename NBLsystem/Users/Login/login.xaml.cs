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
using Facebook;
using System.Dynamic;
using System.Windows.Media.Animation;

namespace NBLsystem.Login {
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window {
        //VARIAVEIS GLOBAIS
        public string UsuarioNome;
        Principal principal;
        Cryptography.PasswordCrypt Crypt = new Cryptography.PasswordCrypt();
        Framework.Login.DadosModel TabUsers;
        Storyboard storyboard = new Storyboard();
        Cryptography.PasswordCrypt Crypt1 = new Cryptography.PasswordCrypt();
        Framework.Login.DadosModel Cad;

        public string AccessToken { get; set; }
        private FacebookClient FBClient = new FacebookClient();
        private const string AppId = "634555460083008";
        private const string _ExtendedPermissions = "";

        public login() {

            InitializeComponent();
            btnLogin.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

          //  WBrowser.Navigate(new Uri("https://graph.facebook.com/oauth/authorize?client_id=559878724040104&redirect_uri=http://www.facebook.com/connect/login_success.html&type=user_agent&display=popup", UriKind.Absolute));


        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e) {
            storyboard = this.FindResource("Login") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            TabUsers = new Framework.Login.DadosModel();
            foreach (var user in TabUsers.users) {
                if ((tb_usuario.Text == string.Empty) || (tb_senha.Password == string.Empty)) {
                    MessageBox.Show("Preencha todos os campos antes de continuar", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                    storyboard.Remove();
                    return;
                } else if ((tb_usuario.Text == user.usuario) && (Crypt.md5(tb_senha.Password) == user.senha)) {
                    MessageBox.Show("Login realizado com sucesso, " + user.usuario,"Info",MessageBoxButton.OK, MessageBoxImage.Information);
                    principal = new Principal(user.nome, user.Id_users, user.level);
                    principal.Show();
                    UsuarioNome = user.nome;
                    this.Close();
                    storyboard.Remove();
                    return;                   
                }
               
            }
        }
        private void tb_usuario_KeyUp(object sender, KeyEventArgs e) {
            VerificaCaracter((TextBox)sender);
        }
        //METODO PARA VERIFICAR CARACTERES DIGITADOS
        public static void VerificaCaracter(TextBox txt) {
            string CharacIlegal = @"'!@#$%¨&*() -_=+£¢¬§|\.;/<>:?´~[]`^{}"; 
            txt.Text = String.Join("", txt.Text.Split(CharacIlegal.ToCharArray()));
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e) {
            //CONFIRMAÇÃO PARA FINALIZAR O SISTEMA
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                this.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            Users.Register.RegisterUser RegisterUser = new Users.Register.RegisterUser();
            RegisterUser.Show();
            this.Close();
        }

        private void lblEntrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            OpenLogin();
        }

        /* ============
        * ============
        * ANIMAÇÕES - METODOS
        * ============
        * ============
        */
        public void OpenLogin() {
            storyboard = this.FindResource("OpenRegister") as Storyboard; // ANIMAÇÃO 2
            storyboard.Remove();

            storyboard = this.FindResource("OpenLogin") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
        }
        public void OpenRegister() {

            storyboard = this.FindResource("OpenLogin") as Storyboard; // ANIMAÇÃO 2
            storyboard.Remove();

            storyboard = this.FindResource("OpenRegister") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
        }

        private void lblCadastrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            OpenRegister();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            OpenLogin();
        }

        private void btnCadastrarNovoUser_Click(object sender, RoutedEventArgs e) {
          
            Cad = new Framework.Login.DadosModel();
            if (tb_nomeCadastro.Text == string.Empty || tb_usuarioCadastro.Text == string.Empty
                || tb_senhaCadastro.Password == string.Empty || tb_cpfCadastro.Text == string.Empty || cb_permissaoCadastro.SelectedIndex == -1) {
                MessageBox.Show("Tente preencher todos os campos antes de clicar em Cadastrar novamente! :P", "Algo Errado!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                Cad.users.Add(new Framework.Login.users {
                    nome = tb_nomeCadastro.Text,
                    usuario = tb_usuarioCadastro.Text,
                    senha = Crypt.md5(tb_senhaCadastro.Password),
                    cpf = tb_cpfCadastro.Text,
                    level = cb_permissaoCadastro.SelectedIndex
                });
                Cad.SaveChanges();
                tb_nomeCadastro.Text = "";
                tb_usuarioCadastro.Text = "";
                tb_senhaCadastro.Password = "";
                tb_cpfCadastro.Text = "";
                cb_permissaoCadastro.SelectedIndex = -1;
                MessageBox.Show("Usuário " + tb_nomeCadastro.Text + " cadastrado!\nVocê já pode fazer login.", "Legal!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }// FIM EVENTO PARA CADASTRAR

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e) {
         /*   if (e.Uri.ToString().StartsWith("http://www.facebook.com/connect/login_success.html")) {
                AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=", "");
                FBClient = new FacebookClient(AccessToken);
                WBrowser.Visibility = Visibility.Hidden;
                dynamic me = FBClient.Get("Me");
                tb_nomeCadastro.Text = ""+ me.name.ToString();
               // tb_usuarioCadastro.Text = "" + me.username.ToString();
               // tb_senhaCadastro.Password = "" + me.password.ToString();
            }*/
        }

        private void btnCadFacebook_Click(object sender, RoutedEventArgs e) {
          /*  storyboard = this.FindResource("OpenFacebook") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();*/
        }
    }

}
