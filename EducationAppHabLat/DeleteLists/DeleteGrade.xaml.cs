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
    /// Логика взаимодействия для DeleteGrade.xaml
    /// </summary>
    public partial class DeleteGrade : Page
    {
        public DeleteGrade()
        {
            InitializeComponent();
            GradeList.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == true);
        }

        private void BackBtnGrade_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.GradeStatistic());
        }

        private void GradeList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Exam exam = GradeList.SelectedItem as Exam;
            exam.IsDeleted = false;
            App.myDb.SaveChanges();
            GradeList.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == true);
        }
    }
}
