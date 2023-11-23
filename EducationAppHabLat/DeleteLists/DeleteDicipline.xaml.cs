using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;
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

namespace EducationAppHabLat.DeleteLists
{
    /// <summary>
    /// Логика взаимодействия для DeleteDicipline.xaml
    /// </summary>
    public partial class DeleteDicipline : Page
    {
        public DeleteDicipline()
        {
            InitializeComponent();
            DiciplineList.ItemsSource = App.myDb.Dicipline.ToList().Where(x => x.IsDeleted == true);
        }

        private void BackBtnDicipline_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiciplinePage());
        }

        private void DiciplineList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Dicipline dicipline = DiciplineList.SelectedItem as Dicipline;
            dicipline.IsDeleted = false;
            App.myDb.SaveChanges();
            DiciplineList.ItemsSource = App.myDb.Dicipline.ToList().Where(x => x.IsDeleted == true);
        }
    }
}
