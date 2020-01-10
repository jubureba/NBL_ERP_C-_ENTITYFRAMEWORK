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

namespace NBLsystem.Pages.Register.Client {
    /// <summary>
    /// Interaction logic for ClienteAdd.xaml
    /// </summary>
    public partial class ClienteAdd : Window {
        Framework.Cliente.DadosModel Cad;
        public ClienteAdd() {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e) {
            Cad = new Framework.Cliente.DadosModel();
            if (tbCPF_CNPJ.Text == string.Empty || tbRazaoSocial.Text == string.Empty) {
                MessageBox.Show("Tente preencher todos os campos antes de clicar em Cadastrar novamente! :P", "Algo Errado!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                Cad.Cliente.Add(new Framework.Cliente.Cliente {
                    razaoSocial = tbRazaoSocial.Text,
                    nomeFantasia = tbFantasia.Text,
                    CPFCNPJ = tbCPF_CNPJ.Text,
                    RG = tbRG.Text,
                    Telefone1 = tb_telefone1.Text,
                    Telefone2 = tb_telefone2.Text,
                    Celular = tb_celular.Text,
                    email = tb_email.Text,
                    cep = tbCep.Text,
                    endereco = tbEndereco.Text,
                    municipio = tbMunicipio.Text,
                    estado = Convert.ToString(cbEstado.SelectedItem),
                    bairro = tbBairro.Text
                });
                Cad.SaveChanges();
                MessageBox.Show("Cliente " + tbRazaoSocial.Text + " cadastrado!\n", "Legal!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void tbRazaoSocial_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbRazaoSocial.Text)) {
                tbRazaoSocial.Text = " Razão Social ";
            }
        }

        private void tbRazaoSocial_GotFocus(object sender, RoutedEventArgs e) {
            if (tbRazaoSocial.Text == " Razão Social ") {
                tbRazaoSocial.Text = "";
            }
        }

        private void tbFantasia_GotFocus(object sender, RoutedEventArgs e) {
            if (tbFantasia.Text == " Nome Fantasia ") {
                tbFantasia.Text = "";
            }
        }

        private void tbFantasia_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbFantasia.Text)) {
                tbFantasia.Text = " Nome Fantasia ";
            }
        }

        private void tbRG_GotFocus(object sender, RoutedEventArgs e) {
            if (tbRG.Text == " RG ") {
                tbRG.Text = "";
            }
        }

        private void tbRG_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbRG.Text)) {
                tbRG.Text = " RG ";
            }
        }

        private void btnCadCliente_Click(object sender, RoutedEventArgs e) {
            ClienteAdd ClienteAdd = new ClienteAdd();
            ClienteAdd.Show();
        }


        private void tbCep_GotFocus(object sender, RoutedEventArgs e) {
            if (tbCep.Text == " CEP ") {
                tbCep.Text = "";
            }
        }

        private void tbCep_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbCep.Text)) {
                tbCep.Text = " CEP ";
            }
        }

        private void tbEndereco_GotFocus(object sender, RoutedEventArgs e) {
            if (tbEndereco.Text == " Endereço ") {
                tbEndereco.Text = "";
            }
        }

        private void tbEndereco_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbEndereco.Text)) {
                tbEndereco.Text = " Endereço ";
            }
        }

        private void tbMunicipio_GotFocus(object sender, RoutedEventArgs e) {
            if (tbMunicipio.Text == " Município ") {
                tbMunicipio.Text = "";
            }
        }

        private void tbMunicipio_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbMunicipio.Text)) {
                tbMunicipio.Text = " Município ";
            }
        }

        private void tbBairro_GotFocus(object sender, RoutedEventArgs e) {
            if (tbBairro.Text == " Bairro ") {
                tbBairro.Text = "";
            }
        }

        private void tbBairro_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tbBairro.Text)) {
                tbBairro.Text = " Bairro ";
            }
        }

        private void tb_email_GotFocus(object sender, RoutedEventArgs e) {
            if (tb_email.Text == " E-mail ") {
                tb_email.Text = "";
            }
        }

        private void tb_email_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(tb_email.Text)) {
                tb_email.Text = " E-mail ";
            }
        }


        private void cbCnpjCPF_DropDownClosed(object sender, EventArgs e) {
            if (cbCnpjCPF.SelectedIndex == 1) {
                tbCPF_CNPJ.Mask = "000.000.000-00";
            } else if (cbCnpjCPF.SelectedIndex == 2) {
                tbCPF_CNPJ.Mask = "00.000.000/0000-00";
            }
        }

    }
}
