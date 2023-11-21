using EducationAppHabLat.MyBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;
using EducationAppHabLat.MyBase;
using System.Windows.Navigation;
using EducationAppHabLat.Pages;

namespace EducationAppHabLat.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        static string connectionString = "Data Source=sql-ser-larisa\\serv1215;Initial Catalog=Practic321P_Lat_and_Hab4;User Id=;Password=;";
        SqlConnection connection = new SqlConnection(connectionString);
        public Student student;
        public string action;
        public StudentWindow(Student _student, string _action)
        {
            InitializeComponent();
            student = _student;
            action = _action;
        }

        public void StudentSaveBtn_Click(object sender, RoutedEventArgs e)
        {   
            StudentPage sp = new StudentPage();

            bool errors = false;
            
            if (idSpeciality.Text == "0" || regNumber.Text == "0" || fioStudent.Text == "")
            {
                errors = true;
                MessageBox.Show("Заполните обязательные данные!");
            }
            if (regNumber.Text.Length < 5)
            {
                errors = true;
                MessageBox.Show("Длина таб.номера должна быть 5 символа!");
            }
            if (App.myDb.Student.Any(x => x.Reg_Number == student.Reg_Number) && action == "add")
            {
                errors = true;
                MessageBox.Show("Такой таб.номер уже есть!");
            }
            if (!errors)
            {
                if (action == "add")
                {
                    App.myDb.Student.Add(new Student()
                    {
                        Reg_Number = Convert.ToInt32(regNumber.Text),
                        FIO_Student = fioStudent.Text,
                        Id_Speciality = Convert.ToInt32(idSpeciality.Text),
                        IsDeleted = false
                    });
                }

                MessageBox.Show("Сохранено!");
                App.myDb.SaveChanges();
                
                
            }
        }
    }
}

