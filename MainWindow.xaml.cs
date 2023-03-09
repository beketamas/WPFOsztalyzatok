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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sliJegy.Value = 3;
            dpDatum.Text =  DateTime.Now.ToString();

        }

        private void sliJegy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int szam = (int)sliJegy.Value;
            lblJegy.Content = szam.ToString();
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter fjl = new StreamWriter("naplo.csv", true);
            fjl.WriteLine(txtNev.Text.ToString() + ";" + cboTantargy.Text + ";" + dpDatum.Text.ToString() + ";" + sliJegy.Value.ToString());
            fjl.Close();
        }

        private void btnMegnyit_Click(object sender, RoutedEventArgs e)
        {
            List<Osztalyzat> lista = new List<Osztalyzat>();
            StreamReader fjl = new StreamReader("naplo.csv");
            while (!fjl.EndOfStream)
            {
                string[] tomb = fjl.ReadLine().Split(";");
                Osztalyzat gyerek = new Osztalyzat(tomb[0], tomb[1], tomb[2], Convert.ToInt32(tomb[3]));
                lista.Add(gyerek);

            }
            fjl.Close();

            dgData.ItemsSource = lista;
        }
    }
}
