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
    /// Логика взаимодействия для Supplies.xaml
    /// </summary>
    public partial class Supplies : Window
    {

        public ObservableCollection<object> person;
        XDocument doc;
        
        public Supplies()
        {
            InitializeComponent();
            Boo();
            
        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Supplies.xml");
            var Books = (from x in doc.Element("Supplies").Elements("Supply")
                         orderby x.Element("SupplierCode").Value
                         select new
                         {
                             Код__Поставщика = x.Element("SupplierCode").Value,
                             Код__Детали = x.Element("DetailCode").Value,
                             Количество = x.Element("Quantity").Value,
                             Дата = x.Element("Date").Value
                         }).ToList();

            person = new ObservableCollection<object>(Books);

            dg.ItemsSource = person;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Hide();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Supplies").Elements("Supply")
                              where (string)x.Element("SupplierCode") == text1.Text
                              select new
                              {
                                  Код__Поставщика = x.Element("SupplierCode").Value,
                                  Код__Детали = x.Element("DetailCode").Value,
                                  Количество = x.Element("Quantity").Value,
                                  Дата = x.Element("Date").Value
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
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Supplies.xml");

            XElement root = doc.Element("Supplies");
            XElement newSupply = null;

            foreach (XElement x in root.Elements("Supply"))
            {
                if (x.Element("SupplierCode").Value == textbox10.Text)
                {
                    String a = x.Element("DetailCode").Value;
                    String b = x.Element("Date").Value;

                    newSupply = new XElement("Supply",
                                  new XElement("SupplierCode", textbox10.Text),
                                  new XElement("DetailCode", a),
                                  new XElement("Quantity", textbox11.Text),
                                  new XElement("Date", b));

                    MessageBox.Show("Новые данные добавлены");
                    person.Add(new Person { Код__Поставщика = textbox10.Text, Код__Детали = a, Количество = textbox11.Text, Дата = b });
                }
            }

            if (newSupply != null)
            {
                doc.Element("Supplies").Add(newSupply);
                doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Supplies.xml");
                Boo();
            }
        }


        private void but4_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Supplies").Elements("Supply")
                              where (string)x.Element("DetailCode") == text2.Text
                              select new
                              {
                                  Код__Поставщика = x.Element("SupplierCode").Value,
                                  Код__Детали = x.Element("DetailCode").Value,
                                  Количество = x.Element("Quantity").Value,
                                  Дата = x.Element("Date").Value
                              }).ToList();

            Boo();
            dg.ItemsSource = booksCount;
        }

        private void but5_Click(object sender, RoutedEventArgs e)
        {
            Boo();
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            doc.Element("Supplies").Add(new XElement("Supply",
                      new XElement("SupplierCode", textbox12.Text),
                      new XElement("DetailCode", textbox13.Text),
                      new XElement("Quantity", textbox14.Text),
                      new XElement("Date", textbox15.Text)));

            MessageBox.Show("Новые данные добавлены");
            person.Add(new Person { Код__Поставщика = textbox12.Text, Код__Детали = textbox13.Text, Количество = textbox14.Text, Дата = textbox15.Text });
            doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Supplies.xml");
            Boo();
        }
    }

    public class Person
    {
        public string Код__Поставщика { get; set; }
        public string Код__Детали { get; set; }
        public string Количество { get; set; }
        public string Дата { get; set; }
        

        
    }
}
