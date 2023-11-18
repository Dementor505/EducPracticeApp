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
    /// Логика взаимодействия для DiciplinePage.xaml
    /// </summary>
    public partial class DiciplinePage : Page
    {
        public DiciplinePage()
        {
            InitializeComponent();

            DiciplineList.ItemsSource = App.myDb.Dicipline.ToList();

            Refresh();
        }

        public void Refresh()
        {
            IEnumerable<Dicipline> SortedDicipline = App.myDb.Dicipline;

            if(SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Name_Dicipline);
            }
            else if(SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Name_Dicipline);
            }



            DiciplineList.ItemsSource = SortedDicipline.ToList();
        }

        private void SortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
