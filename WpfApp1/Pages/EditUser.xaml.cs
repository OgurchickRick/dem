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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        User user = null;
        public EditUser()
        {
            InitializeComponent();
        }

        public EditUser(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Test());
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "" || role.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            if (password.Password.Length <= 6)
            {
                MessageBox.Show("Пароль должен быть больше 6 символов");
                return;
            }

            user.Username = username.Text;
            user.Password = password.Password;
            user.Role = role.SelectedItem as Role;

            Singleton.DB.SaveChanges();

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Test2());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            role.ItemsSource = Singleton.DB.Role.ToList();
            if (user != null)
            {
                username.Text = user.Username;
                password.Password = user.Password; 
                role.SelectedItem = user.Role;
            }
        }
    }
}
