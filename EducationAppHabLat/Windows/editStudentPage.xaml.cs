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

namespace EducationAppHabLat.Windows
{
    /// <summary>
    /// Логика взаимодействия для editStudentPage.xaml
    /// </summary>
    public partial class editStudentPage : Page
    {
        public editStudentPage(Student _student, string _action)
        {
            InitializeComponent();
        }
    }
}
