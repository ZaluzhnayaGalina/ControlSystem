using System.Windows;

namespace ControlSystemClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var lvm = new LoginViewModel();
            var loginForm = new LoginForm { DataContext = lvm };
            loginForm.ShowDialog();
            if (Session.Current.User!=null)
            {
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                new MainWindow().Show();
            }
            else
            {
                Current.Shutdown();
            }
        }
    }
}
