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
using System.Windows.Shapes;

namespace EducationAppHabLat.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void StudentSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            student.Reg_Number = Convert.ToInt32(regNumber.Text);
            int rNumber = int.Parse(regNumber.Text);
            
            if (App.myDb.Student.Where(x => x.Reg_Number == rNumber).FirstOrDefault() != null)
            {
                AreYouSerious ays = new AreYouSerious();
                ays.Show();
                if (App.choiceEdit == true)
                {

                    foreach (var a in App.myDb.Student)
                    {

                        if ((a as Student).Reg_Number == student.Reg_Number) App.myDb.Student.Remove(a);
                    }
                    App.myDb.SaveChanges();

                    App.myDb.Student.Add(student);
                }
                else
                {
                    return;
                }
            }
            student.FIO_Student = fioStudent.Text;
            if (App.myDb.Student.Where(x => x.FIO_Student == fioStudent.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("фио уже есть");
                return;
            }
            student.Id_Speciality = Convert.ToInt32(idSpeciality.Text);
            App.myDb.Student.Add(student);
            App.myDb.SaveChanges();

            this.Close();
            App.sp.StudentList.ItemsSource = App.myDb.Student.ToList();
        }
    }
}

