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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Login());
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if(username.Text == "" || password.Password == "" || passwordConfirm.Password == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            if(password.Password != passwordConfirm.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if(password.Password.Length <= 6)
            {
                MessageBox.Show("Пароль должен быть больше 6 символов");
                return;
            }

            Singleton.DB.User.Add(new User()
            {
                Username = username.Text,
                Password = password.Password,
                Role_ID = 2
            });

            Singleton.DB.SaveChanges();

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Test2());
        }
    }
}
