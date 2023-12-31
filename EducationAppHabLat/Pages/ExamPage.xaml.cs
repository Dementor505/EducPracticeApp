﻿using EducationAppHabLat.EditAdd_Pages;
using EducationAppHabLat.MyBase;
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

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamPage.xaml
    /// </summary>
    public partial class ExamPage : Page
    {
        public ExamPage()
        {
            InitializeComponent();

            ExamList.ItemsSource = App.myDb.Exam.ToList();
        }

        public void Refresh()
        {
            IEnumerable<Exam> SortedDicipline = App.myDb.Exam;

            if (SortList.SelectedIndex == 0)
            {
                SortedDicipline = SortedDicipline.OrderBy(x => x.Date_Exam);
            }
            else if (SortList.SelectedIndex == 1)
            {
                SortedDicipline = SortedDicipline.OrderByDescending(x => x.Date_Exam);
            }


            if (FiltrList.SelectedIndex == 0)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 5);
            if (FiltrList.SelectedIndex == 1)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 4);
            if (FiltrList.SelectedIndex == 2)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 3);
            if (FiltrList.SelectedIndex == 3)
                SortedDicipline = SortedDicipline.Where(x => x.Grade == 2);

            if (SearchTb.Text != null)
            {
                SortedDicipline = SortedDicipline.Where(x => x.Student.FIO_Student.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            ExamList.ItemsSource = SortedDicipline.ToList();
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

        private void ExamAddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Add", new editExamPage()));
        }

        private void ExamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var exam = ExamList.SelectedItem as Exam;
            if (CheckDeleted.IsChecked == true && exam != null)
            {
                foreach (var a in App.myDb.Exam)
                {

                    if ((a as Exam).Id_Exam == exam.Id_Exam)
                        a.IsDeleted = Convert.ToBoolean(1);
                }
                App.myDb.SaveChanges();
            }
            ExamList.ItemsSource = App.myDb.Exam.ToList().Where(x => x.IsDeleted == false);
        }

        private void ExamList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckDeleted.IsChecked == false)
            {
                App.selectExamForExam = ExamList.SelectedItem as Exam;
                Navigation.NextPage(new PageComponent("edit", new editExamPage()));
            }
        }

        private void DeleteListExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteLists.DeleteExamPage());
        }
    }
}
