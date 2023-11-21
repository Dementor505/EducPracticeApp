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
        StudentPage sp = new StudentPage();
        public string action;
        public editStudentPage()
        {
            InitializeComponent();
            //student = _student;
            //action = _action;
            //this.DataContext = student;
            //if (student != null && student.Reg_Number > 0) regNumber.IsReadOnly = true;
            ////SpecCbx.ItemsSource = App.myDb.Specs.ToList();
            ////SpecCbx.DisplayMemberPath = "Direction";

            ////if (student.Reg_Number > 0)
            ////{
            ////    var sss = App.myDb.Speciality.ToList().Where(x => x.Id_Speciality == student.Id_Speciality).First();
            ////    SpecCbx.SelectedIndex = SpecCbx.Items.IndexOf(sss);
            ////}
            if (App.selectStudent != null)
            {
                fioStudent.Text = App.selectStudent.FIO_Student;
                idSpeciality.Text = Convert.ToString(App.selectStudent.Id_Speciality);
                regNumber.Text = Convert.ToString(App.selectStudent.Reg_Number);
            }
        }

        private void StudentSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //bool errors = false;
            //if (idSpeciality.Text == "" || regNumber.Text == "0" || fioStudent.Text == "")
            //{
            //    errors = true;
            //    MessageBox.Show("Заполните обязательные данные!");
            //}
            //if (App.myDb.Student.Any(x => x.Reg_Number == student.Reg_Number) && action == "add")
            //{
            //    errors = true;
            //    MessageBox.Show("Такой таб.номер уже есть!");
            //}
            //if (!errors)
            //{
            //    if (action == "add")
            //    {
            //        App.myDb.Student.Add(new Student()
            //        {
            //            Reg_Number = student.Reg_Number,
            //            FIO_Student = student.FIO_Student,
            //            Id_Speciality = 1,
            //            IsDeleted = Convert.ToBoolean(0)
            //        });
            //    }

            //    MessageBox.Show("Сохранено!");
            //    App.myDb.SaveChanges();
            //    NavigationService.Navigate(new StudentPage());
            //}
            if (App.selectStudent == null)
            {
                if(fioStudent.Text == "" || idSpeciality.Text == null || regNumber.Text == null)
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
                App.myDb.Student.Remove(App.selectStudent);
                App.myDb.SaveChanges();
                Student secondStudent = new Student
                {
                    FIO_Student = fioStudent.Text,
                    Id_Speciality = Convert.ToInt32(idSpeciality.Text),
                    Reg_Number = Convert.ToInt32(regNumber.Text),
                    IsDeleted = false,
                };
                App.myDb.Student.Add(secondStudent);
                App.myDb.SaveChanges();
                NavigationService.Navigate(new StudentPage());
                App.selectStudent = null;
            }

        }
    }
}
