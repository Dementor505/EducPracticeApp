using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Globalization;

namespace EducationAppHabLat.EditAdd_Pages
{
    /// <summary>
    /// Логика взаимодействия для editGradePage.xaml
    /// </summary>
    public partial class editGradePage : Page
    {
        public editGradePage()
        {
            InitializeComponent();

            if (App.selectExam != null)
            {
                number.Text = Convert.ToString(App.selectExam.Id_Exam);
                student.Text = Convert.ToString(App.selectExam.Reg_Number);
                dicipline.Text = Convert.ToString(App.selectExam.Code_Discipline);
                grade.Text = Convert.ToString(App.selectExam.Grade);
                dateExam.Text = Convert.ToString(App.selectExam.Date_Exam);
                teacher.Text = Convert.ToString(App.selectExam.Tab_Number);
                auditory.Text = App.selectExam.Auditory;
            }
        }

        private void GradeSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectExam == null)
            {
                if (this.student.Text == "" || dicipline.Text == "" || grade.Text == null || Convert.ToInt32(grade.Text) < (2) || Convert.ToInt32(grade.Text) > 5 || number == null || dateExam == null || teacher == null || auditory == null)
                { return; }
                Exam exam = new Exam
                {
                    Id_Exam = Convert.ToInt32(number.Text),
                    Reg_Number = Convert.ToInt32(student.Text),
                    Code_Discipline = Convert.ToInt32(dicipline.Text),
                    Grade = Convert.ToInt32(grade.Text),
                    Date_Exam = DateTime.ParseExact(dateExam.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Tab_Number = Convert.ToInt32(teacher.Text),
                    Auditory = auditory.Text,
                    IsDeleted = false,
                };
                if (App.myDb.Exam.Where(x => x.Id_Exam == exam.Id_Exam).FirstOrDefault() == null)
                {
                    App.myDb.Exam.Add(exam);
                    App.myDb.SaveChanges();
                    Navigation.NextPage(new PageComponent("backGrade", new GradeStatistic()));
                }
                else
                {
                    return;
                }
            }
            else
            {
                App.myDb.Exam.Remove(App.selectExam);
                App.myDb.SaveChanges();
                Exam secondGrade = new Exam
                {
                    Id_Exam = Convert.ToInt32(number.Text),
                    Reg_Number = Convert.ToInt32(student.Text),
                    Code_Discipline = Convert.ToInt32(dicipline.Text),
                    Grade = Convert.ToInt32(grade.Text),
                    Date_Exam = Convert.ToDateTime(dateExam.Text),
                    IsDeleted = false,
                    Tab_Number = Convert.ToInt32(teacher.Text),
                    Auditory = auditory.Text,
                };
                App.myDb.Exam.Add(secondGrade);
                App.myDb.SaveChanges();
                NavigationService.Navigate(new GradeStatistic());
                App.selectExam = null;
            }
        }
    }
}
