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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NBLsystem.Pages.Register.Stock {
    /// <summary>
    /// Interaction logic for addItem.xaml
    /// </summary>
    public partial class addItem : Window {
        Storyboard storyboard = new Storyboard();
        public addItem() {
            InitializeComponent();
        }

        private void btnProduto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            storyboard.Remove();
            storyboard = this.FindResource("Produto") as Storyboard; // ANIMAÇÃO 1
            storyboard.Begin();
        }

        private void btnTributacao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            storyboard.Remove();
            storyboard = this.FindResource("Tributacao") as Storyboard; // ANIMAÇÃO 1
            storyboard.Begin();
        }
    }
}
