using ApplicationVeloMax.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ApplicationVeloMax.Views
{
    /// <summary>
    /// Logique d'interaction pour LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void userLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.TestConnectionString(serverInput.Text, dbInput.Text, userLoginInput.Text, userPasswordinput.Password.ToString()))
            {
                AdminView adminViewWindow = new AdminView(serverInput.Text, dbInput.Text, userLoginInput.Text, userPasswordinput.Password.ToString());
                adminViewWindow.Closing += new CancelEventHandler(AnyViewWindow_Closing);
                adminViewWindow.Show();
                this.Visibility = Visibility.Hidden;
            }
        }
        private void AnyViewWindow_Closing(object sender, CancelEventArgs e) { this.Visibility = Visibility.Visible; }

        private void Github_Button_Click(object sender, RoutedEventArgs e) => System.Diagnostics.Process.Start("https://github.com/remSCS/VeloMax.git");
    }
}
