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
using System.Windows.Media.Animation;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using NBLsystem.Framework.Cliente;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;

namespace NBLsystem.Pages.Register.Client {
    /// <summary>
    /// Interaction logic for ClientRegister.xaml
    /// </summary>
    public partial class ClientRegister : Window {
        Storyboard storyboard = new Storyboard();
        bool isInsertMode = false;
        bool isBeingEdited = false;
        int count;
        private int totalPag = 0;
        private int tamanhoPag = 0;
        private int countPag = 0;
        private int atualPag = 1;
        int intSkip;
        DadosModel Cad = new DadosModel();

        public ClientRegister() {
            InitializeComponent();

  


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

        private void btnEditarVisualizar_Click(object sender, RoutedEventArgs e) {
            storyboard = this.FindResource("cadastraCliente") as Storyboard; // ANIMAÇÃO 1
            storyboard.Remove();
            storyboard = this.FindResource("editarVisualizar") as Storyboard; // ANIMAÇÃO 2
            storyboard.Begin();
            
        }

        private void tbCep_GotFocus(object sender, RoutedEventArgs e) {
            if (tbCep.Text == " CEP " ) {
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

        private void btnCadastrar_Click(object sender, RoutedEventArgs e) {

        }

        private void editar_Loaded(object sender, RoutedEventArgs e) {
            fillGrid();
        }



        private void dataGridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            
        }

        private void dataGridView_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
            try {
                Cliente c = new Cliente();
                Cliente emp = e.Row.DataContext as Cliente;
                if (isInsertMode) {
                    var InsertRecord = MessageBox.Show("Do you want to add " + emp.nomeFantasia + " as a new emploee?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (InsertRecord == MessageBoxResult.Yes) {
                        c.razaoSocial = emp.razaoSocial;
                        c.nomeFantasia = emp.nomeFantasia;
                        c.CPFCNPJ = emp.CPFCNPJ;
                        c.RG = emp.RG;
                        c.Telefone1 = emp.Telefone1;
                        c.Telefone2 = emp.Telefone2;
                        c.Celular = emp.Celular;
                        c.email = emp.email;
                        c.cep = emp.cep;
                        c.endereco = emp.endereco;
                        c.municipio = emp.municipio;
                        c.estado = emp.estado;
                        c.bairro = emp.bairro;
                        Cad.Cliente.Add(c);
                        Cad.SaveChanges();
                        dataGridView.ItemsSource = GetEmployeeList();
                        MessageBox.Show(c.nomeFantasia + "  has being added!", "Inserting Record", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } else {
                    dataGridView.ItemsSource = GetEmployeeList();
                }
                Cad.SaveChanges();
            } catch(DbEntityValidationException ex) {
                foreach (var eve in ex.EntityValidationErrors) {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors) {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
            }
        }// FIM EDITENDING

        public void btnEditarTab(object sender, RoutedEventArgs e) {
            

        }
        public void btnExcluirTab(object sender, RoutedEventArgs e) {


        }

        private void dataGridView_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Delete && !isBeingEdited) {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0) {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " Employees?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes) {
                        foreach (var row in grid.SelectedItems) {
                            Cliente employee = row as Cliente;
                            Cad.Cliente.Remove(employee);
                        }
                        Cad.SaveChanges();
                        MessageBox.Show(grid.SelectedItems.Count + " Employees have being deleted!");
                    } else
                        dataGridView.ItemsSource = GetEmployeeList();
                }
            }
        }

        private void dataGridView_AddingNewItem(object sender, AddingNewItemEventArgs e) {
            isInsertMode = true;
        }

        private void dataGridView_BeginningEdit(object sender, DataGridBeginningEditEventArgs e) {
            isBeingEdited = true;
        }

        /*
         * 
         * 
         * MONTAR E PAGINAR TABELA
         * 
         */ 
        public int Contador() {
            this.count = Cad.Cliente.Count();
            return count;
        }

        public void fillGrid() {
            try {
                // For Page view.
                tamanhoPag = int.Parse(tbNumPag.Text);
                this.totalPag = Contador(); //numero de paginas no bd total
                countPag = totalPag / tamanhoPag;

                // Adjust page count if the last page contains partial page.
                if ((totalPag % tamanhoPag) > 0) {
                    countPag = countPag + 1;
                }
                atualPag = 0;
                loadPage();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadPage() {
            try {
                dataGridView.ItemsSource = GetEmployeeList();
                this.NavTextBlock.Text = (this.atualPag + 1).ToString() + " / " + this.countPag.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ObservableCollection<Cliente> GetEmployeeList() {
            intSkip = (this.atualPag * this.tamanhoPag);
            var list = (from e in Cad.Cliente orderby e.Idcliente select e).Skip(intSkip).Take(tamanhoPag);
            return new ObservableCollection<Cliente>(list);
        }

        private void goFirst() {
            this.atualPag = 0;

            loadPage();
        }

        private void goPrevious() {
            if (this.atualPag == this.countPag)
                this.atualPag = this.countPag - 1;

            this.atualPag--;

            if (this.atualPag < 1)
                this.atualPag = 0;

            loadPage();
        }

        private void goNext() {
            this.atualPag++;

            if (this.atualPag > (this.countPag - 1))
                this.atualPag = this.countPag - 1;
            loadPage();

        }

        private void goLast() {
            this.atualPag = this.countPag - 1;

            loadPage();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e) {
            goFirst();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e) {
            goPrevious();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            goNext();
        }

        private void LastButton_Click(object sender, RoutedEventArgs e) {
            goLast();
        }

        private void tbNumPag_TextChanged(object sender, TextChangedEventArgs e) {
            fillGrid();
        }


        //=======================================================================
    }



}
