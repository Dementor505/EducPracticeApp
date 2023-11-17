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
using EducationAppHabLat.MyBase;

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {            
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LoginTb.Text == "Dima" && PasswordPb.Password == "12345")
            {
                MessageBox.Show("Добро пожаловать АДМИН =)");
                App.isAdmin = true;
            }
            else
            {
                MessageBox.Show("Привет ученик. Вперёд к мечтам!");
                App.isAdmin = false;
            }

            Navigation.NextPage(new PageComponent("Пустота", new EmptyPage()));

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MenuVisible();


        }
    }
}
