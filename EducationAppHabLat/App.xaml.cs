using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EducationAppHabLat.MyBase;
using EducationAppHabLat.Pages;

namespace EducationAppHabLat
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool isAdmin = false;
        public static  Practic321P_Lat_and_Hab4Entities4 myDb = new Practic321P_Lat_and_Hab4Entities4();

        public static StudentPage sp = new StudentPage();

        public static bool choiceEdit;
        //public static bool isEdit;

         ////public static var studentic;
    }
}

