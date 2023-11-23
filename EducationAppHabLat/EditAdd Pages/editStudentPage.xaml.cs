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
using EducationAppHabLat.Pages;

namespace EducationAppHabLat.Windows
{
    /// <summary>
    /// Логика взаимодействия для editStudentPage.xaml
    /// </summary>
    public partial class editStudentPage : Page
    {
        public editStudentPage()
        {
            InitializeComponent();

            if (App.selectStudent != null)
            {
                fioStudent.Text = App.selectStudent.FIO_Student;
                idSpeciality.Text = Convert.ToString(App.selectStudent.Id_Speciality);
                regNumber.Text = Convert.ToString(App.selectStudent.Reg_Number);
            }
            if (App.selectStudent != null)
            {
                regNumber.IsReadOnly = true;
                regNumber.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void StudentSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectStudent == null)
            {
                if (fioStudent.Text == "" || idSpeciality.Text == null || regNumber.Text == null)
                { return; }
                Student student = new Student
                {
                    FIO_Student = fioStudent.Text,
                    Id_Speciality = Convert.ToInt32(idSpeciality.Text),
                    Reg_Number = Convert.ToInt32(regNumber.Text),
                    IsDeleted = false,
                };
                if (App.myDb.Student.Where(x => x.FIO_Student == student.FIO_Student).FirstOrDefault() == null && App.myDb.Speciality.Where(x => x.Id_Speciality == student.Id_Speciality).FirstOrDefault() != null && App.myDb.Student.Where(x => x.Reg_Number == student.Reg_Number).FirstOrDefault() == null)
                {
                    App.myDb.Student.Add(student);
                    App.myDb.SaveChanges();
                    Navigation.NextPage(new PageComponent("backStudent", new StudentPage()));
                }
                else
                {
                    return;
                }
            }
            else
            {

                Student secondStudent = new Student
                {
                    FIO_Student = fioStudent.Text,
                    Id_Speciality = Convert.ToInt32(idSpeciality.Text),
                    Reg_Number = Convert.ToInt32(regNumber.Text),
                    IsDeleted = false,
                };
                App.myDb.Student.Remove(App.selectStudent);
                App.myDb.SaveChanges();
                if (App.myDb.Student.Where(x => x.FIO_Student == secondStudent.FIO_Student).FirstOrDefault() == null && App.myDb.Speciality.Where(x => x.Id_Speciality == secondStudent.Id_Speciality).FirstOrDefault() != null)
                {
                    App.myDb.Student.Add(secondStudent);
                    App.myDb.SaveChanges();
                    NavigationService.Navigate(new StudentPage());
                    App.selectStudent = null;
                }
                else
                {
                    return;
                }
            }

        }
    }
}
