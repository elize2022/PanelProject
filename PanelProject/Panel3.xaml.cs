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

namespace PanelProject
{
    /// <summary>
    /// Interaction logic for Panel3.xaml
    /// </summary>
    public partial class Panel3 : Window
    {
        public Panel3()
        {
            InitializeComponent();
        }

        private void rectangle1_Click(object sender, RoutedEventArgs e)
        {
            if (rectangle1.Style == (Style)Application.Current.Resources["RectangleLampGreenOn"])
                rectangle1.Style = (Style)Application.Current.Resources["RectangleLampGreenOff"];
            else
                rectangle1.Style = (Style)Application.Current.Resources["RectangleLampGreenOn"];
        }
    }
}
