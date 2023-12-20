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

namespace Autoworld
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void Button_Post_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Hide();
        }

        private void Button_Det_Click(object sender, RoutedEventArgs e)
        {
            Details details = new Details();
            details.Show();
            this.Hide();
        }

        private void Button_Sup_Click(object sender, RoutedEventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.Show();
            this.Hide();
        }
    }
}
