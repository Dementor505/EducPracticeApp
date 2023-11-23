using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для editDiciplinePage.xaml
    /// </summary>
    public partial class editDiciplinePage : Page
    {
        public editDiciplinePage()
        {
            InitializeComponent();

            if (App.selectDicipline != null)
            {
                code.Text = Convert.ToString(App.selectDicipline.Code_Dicipline);
                space.Text = Convert.ToString(App.selectDicipline.Space_Dicipline);
                nameDicipline.Text = Convert.ToString(App.selectDicipline.Name_Dicipline);
                cathedra.Text = Convert.ToString(App.selectDicipline.Id_Cathedra);
            }
            if (App.selectDicipline != null)
            {
                code.IsReadOnly = true;
                code.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void DiciplineSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectDicipline == null)
            {
                if (code.Text == "" || cathedra.Text == "" || nameDicipline.Text == "" || space.Text == "")
                { return; }
                Dicipline dicipline = new Dicipline
                {
                    Code_Dicipline = Convert.ToInt32(code.Text),
                    Name_Dicipline = nameDicipline.Text,
                    Space_Dicipline = Convert.ToInt32(space.Text),
                    Id_Cathedra = Convert.ToInt32(cathedra.Text),
                    IsDeleted = false,
                };
                if (App.myDb.Dicipline.Where(x => x.Code_Dicipline == dicipline.Code_Dicipline).FirstOrDefault() == null && App.myDb.Cathedra.Where(x => x.Id_Cathedra == dicipline.Id_Cathedra).FirstOrDefault() != null && App.myDb.Dicipline.Where(x => x.Name_Dicipline == dicipline.Name_Dicipline).FirstOrDefault() == null)
                {
                    App.myDb.Dicipline.Add(dicipline);
                    App.myDb.SaveChanges();
                    Navigation.NextPage(new PageComponent("backDicipline", new DiciplinePage()));
                }
                else
                {
                    return;
                }
            }
            else
            {
                try
                {
                    Dicipline secondDicipline = new Dicipline
                    {
                        Code_Dicipline = Convert.ToInt32(code.Text),
                        Name_Dicipline = nameDicipline.Text,
                        Space_Dicipline = Convert.ToInt32(space.Text),
                        Id_Cathedra = Convert.ToInt32(cathedra.Text),
                    };
                    //App.myDb.Dicipline.Remove(App.selectDicipline);
                    App.myDb.SaveChanges();
                    if (App.myDb.Cathedra.Where(x => x.Id_Cathedra == secondDicipline.Id_Cathedra).FirstOrDefault() != null && App.myDb.Dicipline.Where(x => x.Name_Dicipline == secondDicipline.Name_Dicipline).FirstOrDefault() == null)
                    {
                        App.myDb.Dicipline.Add(secondDicipline);
                        App.myDb.SaveChanges();
                        NavigationService.Navigate(new DiciplinePage());
                        App.selectDicipline = null;

                        App.myDb.Dicipline.AddOrUpdate();
                    }
                }
                catch { }
            }
        }
    }
}

