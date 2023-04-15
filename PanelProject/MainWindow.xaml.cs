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

namespace PanelProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Panel1 panel1Window = new Panel1();
            panel1Window.Owner = this;
            panel1Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel1Window.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Panel2 panel2Window = new Panel2();
            panel2Window.Owner = this;
            panel2Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel2Window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Panel3 panel3Window = new Panel3();
            panel3Window.Owner = this;
            panel3Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel3Window.Show();
        }
    }
}
