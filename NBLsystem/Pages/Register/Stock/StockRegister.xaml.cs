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

namespace NBLsystem.Pages.Register.Stock {
    /// <summary>
    /// Interaction logic for StockRegister.xaml
    /// </summary>
    public partial class StockRegister : Window {
        public StockRegister() {
            InitializeComponent();
        }

        private void btnNovoProduto_Click(object sender, RoutedEventArgs e) {
            Pages.Register.Stock.addItem addItem = new Pages.Register.Stock.addItem();
            addItem.Show();
        }
    }
}
