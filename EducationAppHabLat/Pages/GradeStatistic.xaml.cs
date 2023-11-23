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
using EducationAppHabLat.EditAdd_Pages;
using EducationAppHabLat.MyBase;
using EducationAppHabLat.Windows;

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradeStatistic.xaml
    /// </summary>
    public partial class GradeStatistic : Page
    {
        Exam exam { get; set; }
        public GradeStatistic()
        {
            InitializeComponent();

            if (App.isStudent == true)
            {
                StudentGrade.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false && x.Reg_Number == App.studentLogin);
            }
            else
            {
                StudentGrade.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false);
            }
            Refresh();

            if(App.isStudent == true)
            {
                GradeAddBtn.Visibility = Visibility.Hidden;
                CheckDeleted.Visibility = Visibility.Hidden;
                textDelete.Visibility = Visibility.Hidden;
                DeleteListGrade.Visibility = Visibility.Hidden;
            }
        }

        public void Refresh()
        {
            IEnumerable<Exam> SortedDicipline = App.myDb.Exam;

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Id_Exam);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Id_Exam);
            }

            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Grade > 4 && x.Grade < 6);
            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 4);
            if (FiltrList.SelectedIndex == 2)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 3);
            if (FiltrList.SelectedIndex == 3)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 2);

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Dicipline.Name_Dicipline.ToLower().Contains(SearchTb.Text.ToLower()));
            }
           
            if (App.isStudent == true)
            {
                StudentGrade.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false && x.Reg_Number == App.studentLogin);
            }
            else
            {
                StudentGrade.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false);
            }
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

        private void StudentGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var studentGrade = StudentGrade.SelectedItem as Exam;
            if (CheckDeleted.IsChecked == true && studentGrade != null)
            {
                foreach (var a in App.myDb.Exam)
                {

                    if ((a as Exam).Id_Exam == studentGrade.Id_Exam)
                        a.IsDeleted = Convert.ToBoolean(1);
                }
                App.myDb.SaveChanges();
            }
            StudentGrade.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false);
        }

        private void GradeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Add", new editGradePage()));
        }

        private void DeleteListGrade_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteLists.DeleteGrade());
        }

        private void StudentGrade_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckDeleted.IsChecked == false && App.isStudent == false)
            {
                App.selectExam = StudentGrade.SelectedItem as Exam;
                Navigation.NextPage(new PageComponent("edit", new editGradePage()));
            }
        }
    }
}
