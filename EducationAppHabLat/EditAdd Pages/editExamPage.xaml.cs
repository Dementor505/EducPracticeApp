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
    /// Логика взаимодействия для editExamPage.xaml
    /// </summary>
    public partial class editExamPage : Page
    {
        public editExamPage()
        {
            InitializeComponent();
            if (App.selectExamForExam != null)
            {
                number.Text = Convert.ToString(App.selectExamForExam.Id_Exam);
                student.Text = Convert.ToString(App.selectExamForExam.Reg_Number);
                dicipline.Text = Convert.ToString(App.selectExamForExam.Code_Discipline);
                grade.Text = Convert.ToString(App.selectExamForExam.Grade);
                dateExam.Text = Convert.ToString(App.selectExamForExam.Date_Exam);
                teacher.Text = Convert.ToString(App.selectExamForExam.Tab_Number);
                auditory.Text = App.selectExamForExam.Auditory;
            }
            if (App.selectExamForExam != null)
            {
                number.IsReadOnly = true;
                number.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void GradeSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectExamForExam == null)
            {
                if (this.student.Text == "" || dicipline.Text == "" || grade.Text == null || Convert.ToInt32(grade.Text) < (2) || Convert.ToInt32(grade.Text) > 5 || number == null || dateExam == null || teacher == null || auditory == null)
                { return; }
                Exam exam = new Exam
                {
                    Id_Exam = Convert.ToInt32(number.Text),
                    Reg_Number = Convert.ToInt32(student.Text),
                    Code_Discipline = Convert.ToInt32(dicipline.Text),
                    Grade = Convert.ToInt32(grade.Text),
                    Date_Exam = DateTime.ParseExact(dateExam.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Tab_Number = Convert.ToInt32(teacher.Text),
                    Auditory = auditory.Text,
                    IsDeleted = false,
                };
                if (App.myDb.Exam.Where(x => x.Id_Exam == exam.Id_Exam).FirstOrDefault() == null && App.myDb.Student.Where(x => x.Reg_Number == exam.Reg_Number).FirstOrDefault() != null && App.myDb.Dicipline.Where(x => x.Code_Dicipline == exam.Code_Discipline).FirstOrDefault() != null && App.myDb.Employee.Where(x => x.Tab_Number == exam.Tab_Number).FirstOrDefault() != null)
                {
                    App.myDb.Exam.Add(exam);
                    App.myDb.SaveChanges();
                    Navigation.NextPage(new PageComponent("backExam", new ExamPage()));
                }
                else
                {
                    return;
                }
            }
            else
            {
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
                App.myDb.Exam.Remove(App.selectExamForExam);
                App.myDb.SaveChanges();
                if (App.myDb.Student.Where(x => x.Reg_Number == secondGrade.Reg_Number).FirstOrDefault() != null && App.myDb.Dicipline.Where(x => x.Code_Dicipline == secondGrade.Code_Discipline).FirstOrDefault() != null && App.myDb.Employee.Where(x => x.Tab_Number == secondGrade.Tab_Number).FirstOrDefault() != null && (Convert.ToInt32(grade.Text) >= 2) || (Convert.ToInt32(grade.Text) <= 5))
                {
                    App.myDb.Exam.Add(secondGrade);
                    App.myDb.SaveChanges();
                    NavigationService.Navigate(new ExamPage());
                    App.selectExamForExam = null;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
