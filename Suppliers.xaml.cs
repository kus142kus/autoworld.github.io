using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace Autoworld
{
    /// <summary>
    /// Логика взаимодействия для Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Window
    {
        public ObservableCollection<object> supplier;
        XDocument doc;

        public Suppliers()
        {
            InitializeComponent();
            Boo();

        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Suppliers.xml");
            var Books = (from x in doc.Element("Suppliers").Elements("supplier")
                         orderby x.Element("SupplierCode").Value
                         select new
                         {
                             Код__Поставщика = x.Element("SupplierCode").Value,
                             Название = x.Element("Name").Value,
                             Адрес = x.Element("Address").Value,
                             Телефон = x.Element("Phone").Value
                         }).ToList();

            supplier = new ObservableCollection<object>(Books);

            dg.ItemsSource = supplier;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Hide();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Suppliers").Elements("supplier")
                              where (string)x.Element("SupplierCode") == text1.Text
                              select new
                              {
                                  Код__Поставщика = x.Element("SupplierCode").Value,
                                  Название = x.Element("Name").Value,
                                  Адрес = x.Element("Address").Value,
                                  Телефон = x.Element("Phone").Value
                              }).ToList();

            Boo();
            dg.ItemsSource = booksCount;
        }


        private void but2_Click(object sender, RoutedEventArgs e)
        {
            Boo();
        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Suppliers.xml");

            XElement root = doc.Element("Suppliers");
            XElement newSupply = null;

            foreach (XElement x in root.Elements("supplier"))
            {
                if (x.Element("SupplierCode").Value == textbox10.Text)
                {
                    String a = x.Element("Name").Value;
                    String b = x.Element("Phone").Value;

                    newSupply = new XElement("supplier",
                                  new XElement("SupplierCode", textbox10.Text),
                                  new XElement("Name", a),
                                  new XElement("Address", b),
                                  new XElement("Phone", textbox11.Text));

                    MessageBox.Show("Новые данные добавлены");
                    supplier.Add(new Supplier { Код__Поставщика = textbox10.Text, Название = a, Адрес = b, Телефон = textbox11.Text });
                }
            }

            if (newSupply != null)
            {
                doc.Element("Suppliers").Add(newSupply);
                doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Suppliers.xml");
                Boo();
            }
        }

        private void but5_Click(object sender, RoutedEventArgs e)
        {
            Boo();
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            doc.Element("Suppliers").Add(new XElement("supplier",
                      new XElement("SupplierCode", textbox12.Text),
                      new XElement("Name", textbox13.Text),
                      new XElement("Address", textbox14.Text),
                      new XElement("Phone", textbox15.Text)));

            MessageBox.Show("Новые данные добавлены");
            supplier.Add(new Supplier { Код__Поставщика = textbox12.Text, Название = textbox13.Text, Адрес = textbox14.Text, Телефон = textbox15.Text });
            doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Suppliers.xml");
            Boo();
        }
    }

    public class Supplier
    {
        public string Код__Поставщика { get; set; }
        public string Название { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }



    }
}

