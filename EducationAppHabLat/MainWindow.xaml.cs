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
using EducationAppHabLat.Pages;
using EducationAppHabLat.MyBase;

namespace EducationAppHabLat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.mainWindow = this;

            Navigation.NextPage(new PageComponent("Авторизация", new Authorization()));

            this.Top = SystemParameters.PrimaryScreenHeight/2 - this.Height/2;
            this.Left = SystemParameters.PrimaryScreenWidth/2 - this.Width/2;

            GradeBtn.Visibility = Visibility.Hidden;
            EmployeeBtn.Visibility = Visibility.Hidden;
            ExamsBtn.Visibility = Visibility.Hidden;
            DiciplineBtn.Visibility = Visibility.Hidden;
            StudentBtn.Visibility = Visibility.Hidden;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Statistic.Content = $"H: {this.Height}   W: {this.Width}"; 
        }
        public void MenuVisible()
        {
            if (App.isAdmin == true)
            {
                GradeBtn.Visibility = Visibility.Visible;
                EmployeeBtn.Visibility = Visibility.Visible;
                ExamsBtn.Visibility = Visibility.Visible;
                DiciplineBtn.Visibility = Visibility.Visible;
                StudentBtn.Visibility = Visibility.Visible;
            }
            else
            {
                GradeBtn.Visibility = Visibility.Visible;
                EmployeeBtn.Visibility = Visibility.Hidden;
                ExamsBtn.Visibility = Visibility.Hidden;
                DiciplineBtn.Visibility = Visibility.Hidden;
                StudentBtn.Visibility = Visibility.Hidden;
            }
        }

        private void GradeBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Оценки", new GradeStatistic()));
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Сотрудники", new EmployeePage()));
        }

        private void DiciplineBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Дисциплины", new DiciplinePage()));
        }

        private void StudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Студенты", new StudentPage()));
        }

        private void ExamsBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Экзамены", new ExamPage()));
        }
    }
}
