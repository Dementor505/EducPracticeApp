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

namespace EducationAppHabLat.DeleteLists
{
    /// <summary>
    /// Логика взаимодействия для DeleteExamPage.xaml
    /// </summary>
    public partial class DeleteExamPage : Page
    {
        public DeleteExamPage()
        {
            InitializeComponent();
            ExamList.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == true);
        }

        private void BackBtnExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ExamPage());
        }

        private void ExamList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Exam exam = ExamList.SelectedItem as Exam;
            exam.IsDeleted = false;
            App.myDb.SaveChanges();
            ExamList.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == true);
        }
    }
}
