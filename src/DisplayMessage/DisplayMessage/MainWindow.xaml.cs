using System;
using System.Linq;
using System.Threading.Tasks;
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
                string message;

                if (int.TryParse(args[1], out var seconds))
                {
                    message = string.Join("\r\n\r\n", args.Skip(2));

                    Task.Delay(TimeSpan.FromSeconds(seconds))
                        .ContinueWith(
                            _ =>
                                {
                                    this.Dispatcher.Invoke(
                                        () =>
                                            {
                                                Application.Current.Shutdown();
                                            });
                                });
                }
                else
                {
                    message = string.Join("\r\n\r\n", args.Skip(1));
                }

                this.TextBox1.Text = message;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}