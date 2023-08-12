using System;
using System.Linq;
using System.Windows;

namespace DisplayMessage
{
    /// <summary>
    ///     MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                this.TextBox1.Text = string.Join("\r\n\r\n", args.Skip(1));
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}