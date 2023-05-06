using System;
using System.Windows;

namespace PanelProject
{
    public partial class VariantWindow : Window
    {
        private Boolean isLearning;

        public VariantWindow(Boolean isLearning)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.isLearning = isLearning;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Panel1 panel1Window = new Panel1(this.isLearning);
            panel1Window.Owner = this;
            panel1Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel1Window.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Panel2 panel2Window = new Panel2(this.isLearning);
            panel2Window.Owner = this;
            panel2Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel2Window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Panel3 panel3Window = new Panel3(this.isLearning);
            panel3Window.Owner = this;
            panel3Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            panel3Window.Show();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Left = this.Left;
            mainWindow.Top = this.Top;
            mainWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            mainWindow.Show();
            this.Close();
        }
    }
}
