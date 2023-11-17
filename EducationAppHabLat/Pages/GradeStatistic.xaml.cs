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

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradeStatistic.xaml
    /// </summary>
    public partial class GradeStatistic : Page
    {
        Exam exam { get; set; }
        public GradeStatistic()
        {
            InitializeComponent();

            StudentGrade.ItemsSource = App.myDb.Student.ToList();
        }
    }
}
