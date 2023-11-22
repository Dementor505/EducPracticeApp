using EducationAppHabLat.EditAdd_Pages;
using EducationAppHabLat.MyBase;
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

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();

            EmployeeList.ItemsSource = App.myDb.Employee.ToList();
            Refresh();
        }

        public void Refresh()
        {
            IEnumerable<Employee> SortedDicipline = App.myDb.Employee;

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Surname);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Surname);
            }


            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Oklad <= 30000);
            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Oklad >= 30000);

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Post.Name_Post.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            EmployeeList.ItemsSource = SortedDicipline.ToList();
        }

        private void FiltrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employee = EmployeeList.SelectedItem as Employee;
            if (CheckDeleted.IsChecked == true && employee != null)
            {
                foreach (var a in App.myDb.Employee)
                {

                    if ((a as Employee).Tab_Number == employee.Tab_Number)
                        a.IsDeleted = Convert.ToBoolean(1);
                }
                App.myDb.SaveChanges();
            }
            EmployeeList.ItemsSource = App.myDb.Employee.ToList().Where(x => x.IsDeleted == false);
        }

        private void EmployeeList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckDeleted.IsChecked == false)
            {
                App.selectEmployee = EmployeeList.SelectedItem as Employee;
                Navigation.NextPage(new PageComponent("edit", new EditAdd_Pages.editEmployeePage()));
            }
        }

        private void EmployeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Add", new editEmployeePage()));
        }

        private void DeleteListEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteLists.DeleteEmployee());
        }
    }
}
