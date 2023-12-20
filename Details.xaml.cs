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
    /// Логика взаимодействия для Details.xaml
    /// </summary>
    public partial class Details : Window
    {

        public ObservableCollection<object> detail;
        XDocument doc;
        public Details()
        {
            InitializeComponent();
            Boo();
        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Details.xml");
            var Books = (from x in doc.Element("Details").Elements("Detail")
                         orderby x.Element("DetailCode").Value
                         select new
                         {
                             Код__Детали = x.Element("DetailCode").Value,
                             Название = x.Element("Name").Value,
                             Артикул = x.Element("Article").Value,
                             Цена = x.Element("Price").Value,
                             Примечание = x.Element("Note").Value
                         }).ToList();

            detail = new ObservableCollection<object>(Books);

            dg.ItemsSource = detail;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            this.Hide();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Details").Elements("Detail")
                              where (string)x.Element("DetailCode") == text1.Text
                              select new
                              {
                                  Код__Детали = x.Element("DetailCode").Value,
                                  Название = x.Element("Name").Value,
                                  Артикул = x.Element("Article").Value,
                                  Цена = x.Element("Price").Value,
                                  Примечание = x.Element("Note").Value
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
            doc = XDocument.Load("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Details.xml");

            XElement root = doc.Element("Details");
            bool found = false; 

            foreach (XElement x in root.Elements("Detail"))
            {
                if (x.Element("DetailCode").Value == textbox10.Text)
                {
                    String a = x.Element("Name").Value;
                    String b = x.Element("Article").Value;
                    String c = x.Element("Note").Value;

                    doc.Element("Details").Add(new XElement("Detail",
                              new XElement("DetailCode", textbox10.Text),
                              new XElement("Name", a),
                              new XElement("Article", b),
                              new XElement("Price", textbox11.Text),
                              new XElement("Note", "Цена изменена")));

                    MessageBox.Show("Новые данные добавлены");
                    detail.Add(new Detail { Код__Детали = textbox10.Text, Название = a, Артикул = b, Цена = textbox11.Text, Примечание = c });
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Элемент не найден");
            }

            doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Details.xml");
            Boo();
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Details").Elements("Detail")
                              where (string)x.Element("Article") == text2.Text
                              select new
                              {
                                  Код__Детали = x.Element("DetailCode").Value,
                                  Название = x.Element("Name").Value,
                                  Артикул = x.Element("Article").Value,
                                  Цена = x.Element("Price").Value,
                                  Примечание = x.Element("Note").Value
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
            doc.Element("Details").Add(new XElement("Detail",
                      new XElement("DetailCode", textbox12.Text),
                      new XElement("Name", textbox13.Text),
                      new XElement("Article", textbox14.Text),
                      new XElement("Price", textbox15.Text),
                      new XElement("Note", textbox16.Text)));

            MessageBox.Show("Новые данные добавлены");
            detail.Add(new Detail { Код__Детали = textbox12.Text, Название = textbox13.Text, Артикул = textbox14.Text, Цена = textbox15.Text, Примечание = textbox16.Text });
            doc.Save("C:\\Users\\King\\source\\repos\\Autoworld\\Autoworld\\Details.xml");
            Boo();
        }
    }

    public class Detail
    {
        public string Код__Детали { get; set; }
        public string Название { get; set; }
        public string Артикул { get; set; }
        public string Цена { get; set; }
        public string Примечание { get; set; }



    }
}
