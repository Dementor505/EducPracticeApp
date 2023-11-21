using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace EducationAppHabLat.MyBase
{
    static class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;

        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }

        private static void Update(PageComponent pageComponent)
        {
            //mainWindow.LableName.Content = pageComponent.Title;
            //mainWindow.BtnNext.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            //mainWindow.BtnBack.Visibility = App.isAdmin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }
    }

    static class NavigationEdit
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;

        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }

        private static void Update(PageComponent pageComponent)
        {
            //mainWindow.LableName.Content = pageComponent.Title;
            //mainWindow.BtnNext.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            //mainWindow.BtnBack.Visibility = App.isAdmin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.editFrame.Navigate(pageComponent.Page);
        }
    }

    class PageComponent
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public PageComponent(string title, Page page)
        {
            Title = title;
            Page = page;
        }
    }

}

