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
            var std = App.myDb.Student.Where(x => x.Reg_Number.ToString() == LoginTb.Text).FirstOrDefault();
            if (std != null && PasswordPb.Password == "000")
            {
                App.isStudent = true;
                Navigation.NextPage(new PageComponent("Студент", new EmptyPage()));
            }
            else if (LoginTb.Text == "Admin" && PasswordPb.Password == "111")
            {
                App.isAdmin = true;
                Navigation.NextPage(new PageComponent("Админ", new EmptyPage()));
            }
            else
            {
                MessageBox.Show("Кто ты, воин ?");
            }
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MenuVisible();
        }
    }
}
