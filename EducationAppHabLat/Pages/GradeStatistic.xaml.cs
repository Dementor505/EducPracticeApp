﻿using System;
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

            StudentGrade.ItemsSource = App.myDb.Exam.ToList();
            Refresh();
        }

        public void Refresh()
        {
            IEnumerable<Exam> SortedDicipline = App.myDb.Exam;

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Reg_Number);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Reg_Number);
            }

            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Grade > 4 && x.Grade < 6);
            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 4);
            if (FiltrList.SelectedIndex == 2)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 3);
            if (FiltrList.SelectedIndex == 3)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 2);

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Dicipline.Name_Dicipline.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            StudentGrade.ItemsSource = SortedDicipline.ToList();
        }

        private void FiltrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
