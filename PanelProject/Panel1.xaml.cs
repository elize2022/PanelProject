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
using System.Reflection;

namespace PanelProject
{
    /// <summary>
    /// Interaction logic for Panel1.xaml
    /// </summary>
    public partial class Panel1 : Window
    {
        private Boolean isOnSwitch1;
        public Panel1()
        {
            InitializeComponent();
            isOnSwitch1 = false;
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isOnSwitch1)
                {
                    var uriSource = new Uri(@"/PanelProject;component/images/switchDown.png", UriKind.Relative);
                    img1.Source = new BitmapImage(uriSource);
                    isOnSwitch1 = false;
                }
                else
                {
                    var uriSource = new Uri(@"/PanelProject;component/images/switchUp.png", UriKind.Relative);
                    img1.Source = new BitmapImage(uriSource);
                    isOnSwitch1 = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
