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
        public static bool isStudent = false;

        public static  DataBaseEndEntities myDb = new DataBaseEndEntities();

        public static StudentPage sp = new StudentPage();

        public static bool choiceEdit;
        //public static bool isEdit;

        ////public static var studentic;

        public static Student selectStudent;
        public static Exam selectExam;
        public static Employee selectEmployee;
        public static Exam selectExamForExam;
    }
}

