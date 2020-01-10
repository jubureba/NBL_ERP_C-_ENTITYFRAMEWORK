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

namespace NBLsystem.Users.Register {
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window {
        Cryptography.PasswordCrypt Crypt = new Cryptography.PasswordCrypt();
        Framework.Login.DadosModel Cad;

        public RegisterUser() {
            InitializeComponent();

           
        }
        private void button_Click(object sender, RoutedEventArgs e) {
            Cad = new Framework.Login.DadosModel();
            if (tb_nome.Text == string.Empty || tb_usuario.Text == string.Empty
                || tb_senha.Password == string.Empty || tb_cpf.Text == string.Empty || cb_permissao.SelectedIndex == -1) {
                MessageBox.Show("Tente preencher todos os campos antes de clicar em Cadastrar novamente! :P", "Algo Errado!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                Cad.users.Add(new Framework.Login.users {
                    nome = tb_nome.Text,
                    usuario = tb_usuario.Text,
                    senha = Crypt.md5(tb_senha.Password),
                    cpf = tb_cpf.Text,
                    level = cb_permissao.SelectedIndex
                });
                Cad.SaveChanges();
                MessageBox.Show("Usuário " + tb_nome.Text + " cadastrado!\nVocê já pode fazer login.", "Legal!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //FIM BOTAO CADASTRAR

        private void button1_Click(object sender, RoutedEventArgs e) {
            Login.login login = new Login.login();
            login.Show();
            this.Close();
        }
    }
}
