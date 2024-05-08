using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new Login());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.User.ToList();
            table.ItemsSource = Singleton.DB.User.Local;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(filter.Text != "")
            {
                table.ItemsSource = Singleton.DB.User.Where(u =>
                u.Username.Contains(filter.Text) ||
                u.Password.Contains(filter.Text)).ToList();
            }
            else
            {
                Singleton.DB.User.ToList();
                table.ItemsSource = Singleton.DB.User.Local;
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if(table.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для изменения");
                return;
            }

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.frame.Navigate(new EditUser(table.SelectedItem as User));
        }
    }
}
