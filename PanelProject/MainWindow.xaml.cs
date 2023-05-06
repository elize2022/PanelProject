using System.Windows;

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
            VariantWindow varWindow = new VariantWindow(true);
            varWindow.Left = this.Left;
            varWindow.Top = this.Top;
            varWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            varWindow.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            VariantWindow varWindow = new VariantWindow(false);
            varWindow.Left = this.Left;
            varWindow.Top = this.Top;
            varWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            varWindow.Show();
            this.Close();
        }

    }
}
