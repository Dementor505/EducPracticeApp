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
using EducationAppHabLat.EditAdd_Pages;
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

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Name_Dicipline);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Name_Dicipline);
            }


            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Space_Dicipline <= 200);
            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Space_Dicipline >= 200);

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Name_Dicipline.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            DiciplineList.ItemsSource = SortedDicipline.ToList();
        }

        private void SortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FiltrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void DiciplineAddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Add", new editDiciplinePage()));
        }

        private void DeleteListDicipline_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteLists.DeleteDicipline());
        }

        private void DiciplineList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckDeleted.IsChecked == false)
            {
                App.selectDicipline = DiciplineList.SelectedItem as Dicipline;
                Navigation.NextPage(new PageComponent("edit", new EditAdd_Pages.editDiciplinePage()));
            }
        }

        private void DiciplineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dicipline = DiciplineList.SelectedItem as Dicipline;
            if (CheckDeleted.IsChecked == true && dicipline != null)
            {
                foreach (var a in App.myDb.Dicipline)
                {

                    if ((a as Dicipline).Code_Dicipline == dicipline.Code_Dicipline)
                        a.IsDeleted = Convert.ToBoolean(1);
                }
                App.myDb.SaveChanges();
            }
            DiciplineList.ItemsSource = App.myDb.Dicipline.ToList().Where(x => x.IsDeleted == false);
        }
    }
}
