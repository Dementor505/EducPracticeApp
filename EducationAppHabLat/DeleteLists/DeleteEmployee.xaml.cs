using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;
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

namespace EducationAppHabLat.DeleteLists
{
    /// <summary>
    /// Логика взаимодействия для DeleteEmployee.xaml
    /// </summary>
    public partial class DeleteEmployee : Page
    {
        public DeleteEmployee()
        {
            InitializeComponent();
            EmployeeList.ItemsSource = App.myDb.Employee.ToList().Where(x => x.IsDeleted == true);
        }

        private void BackBtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage());
        }

        private void EmployeeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = EmployeeList.SelectedItem as Employee;
            employee.IsDeleted = false;
            App.myDb.SaveChanges();
            EmployeeList.ItemsSource = App.myDb.Employee.ToList().Where(x => x.IsDeleted == true);
        }
    }
}
