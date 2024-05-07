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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = Singleton.DB.User.FirstOrDefault(u =>
            u.Username == username.Text
            && u.Password == password.Password);
            if (user == null)
            {
                MessageBox.Show("Нельзя сотворить здесь");
            }
            else { 
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.frame.Navigate(new Test());
            }
        }
    }
}
