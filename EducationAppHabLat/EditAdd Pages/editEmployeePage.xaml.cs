using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace EducationAppHabLat.EditAdd_Pages
{
    /// <summary>
    /// Логика взаимодействия для editEmployeePage.xaml
    /// </summary>
    public partial class editEmployeePage : Page
    {
        public editEmployeePage()
        {
            InitializeComponent();

            if (App.selectEmployee != null)
            {
                tabNumber.Text = Convert.ToString(App.selectEmployee.Tab_Number);
                cathedra.Text = Convert.ToString(App.selectEmployee.Id_Cathedra);
                employeeFio.Text = Convert.ToString(App.selectEmployee.Surname);
                money.Text = Convert.ToString(App.selectEmployee.Oklad);
                expMainCathedra.Text = Convert.ToString(App.selectEmployee.Exp);
                post.Text = Convert.ToString(App.selectEmployee.Id_Post);
                mainPerson.Text = Convert.ToString(App.selectEmployee.Shef);
            }
            if (App.selectEmployee != null)
            {
                tabNumber.IsReadOnly = true;
                tabNumber.Background = new SolidColorBrush(Colors.LightPink);
            }

        }

        private void GradeSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectEmployee == null)
            {
                if (tabNumber.Text == "" || cathedra.Text == "" || employeeFio.Text == "" || money.Text == "" || expMainCathedra.Text == "" || post.Text == "" || mainPerson.Text == "")
                { return; }
                Employee employee = new Employee
                {
                    Tab_Number = Convert.ToInt32(tabNumber.Text),
                    Id_Cathedra = Convert.ToInt32(cathedra.Text),
                    Surname = employeeFio.Text,
                    Oklad = Convert.ToInt32(money.Text),
                    Exp = Convert.ToInt32(expMainCathedra.Text),
                    Id_Post = Convert.ToInt32(post.Text),
                    Shef = Convert.ToInt32(mainPerson.Text),
                    IsDeleted = false,
                };
                if (App.myDb.Employee.Where(x => x.Tab_Number == employee.Tab_Number).FirstOrDefault() == null && App.myDb.Cathedra.Where(x => x.Id_Cathedra == employee.Id_Cathedra).FirstOrDefault() != null && App.myDb.Post.Where(x => x.Id_Post == employee.Id_Post).FirstOrDefault() != null)
                {
                    App.myDb.Employee.Add(employee);
                    App.myDb.SaveChanges();
                    Navigation.NextPage(new PageComponent("backEmployee", new EmployeePage()));
                }
                else
                {
                    return;
                }
            }
            else
            {
                if(expMainCathedra.Text == "")
                {
                    expMainCathedra.Text = Convert.ToString(0);
                }
                Employee secondEmployee = new Employee
                {
                    Tab_Number = Convert.ToInt32(tabNumber.Text),
                    Id_Cathedra = Convert.ToInt32(cathedra.Text),
                    Surname = employeeFio.Text,
                    Oklad = Convert.ToDecimal(money.Text),
                    Exp = Convert.ToInt32(expMainCathedra.Text),
                    Id_Post = Convert.ToInt32(post.Text),
                    Shef = Convert.ToInt32(mainPerson.Text),
                };
              
                App.myDb.Employee.Remove(App.selectEmployee);
                App.myDb.SaveChanges();
                if (App.myDb.Cathedra.Where(x => x.Id_Cathedra == secondEmployee.Id_Cathedra).FirstOrDefault() != null && App.myDb.Post.Where(x => x.Id_Post == secondEmployee.Id_Post).FirstOrDefault() != null)
                {
                    App.myDb.Employee.Add(secondEmployee);
                    App.myDb.SaveChanges();
                    NavigationService.Navigate(new EmployeePage());
                    App.selectEmployee = null;
                }
            }
        }
    }
}
