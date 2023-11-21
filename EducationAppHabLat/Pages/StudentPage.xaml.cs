using EducationAppHabLat.MyBase;
using EducationAppHabLat.Windows;
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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            App.sp = this;

            StudentList.ItemsSource = App.myDb.Student.ToList().Where(x => x.IsDeleted == false);
            Refresh();
        }

        public void Refresh()
        {
            IEnumerable<Student> SortedDicipline = App.myDb.Student;

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Id_Speciality);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Id_Speciality);
            }

            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality == "Прикладная математика");
            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality == "Информационные системы и технологии");
            if (FiltrList.SelectedIndex == 2)
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality == "Прикладная информатика");
            if (FiltrList.SelectedIndex == 3)
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality == "Ядерные физика и технологии");
            if (FiltrList.SelectedIndex == 4)
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality == "Бизнес-информатика");

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Speciality.Direction_Speciality.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            StudentList.ItemsSource = SortedDicipline.ToList().Where(x => x.IsDeleted == false);
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

        Student student;
        public void StudentAddBtn_Click(object sender, RoutedEventArgs e)
        {
                Navigation.NextPage(new PageComponent("Add", new editStudentPage()));
        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var student = StudentList.SelectedItem as Student;
            if (CheckDeleted.IsChecked == true && student != null)
            {
                foreach (var a in App.myDb.Student)
                {

                    if ((a as Student).Reg_Number == student.Reg_Number)
                        a.IsDeleted = Convert.ToBoolean(1);
                }
                App.myDb.SaveChanges();
            }
            StudentList.ItemsSource = App.myDb.Student.ToList().Where(x => x.IsDeleted == false);
        }
        private void StudentList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckDeleted.IsChecked == false)
            {
                App.selectStudent = StudentList.SelectedItem as Student;
                Navigation.NextPage(new PageComponent("edit", new editStudentPage()));
            }
        }

        private void DeleteListStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteLists.DeleteStudent());
        }
    }
}
