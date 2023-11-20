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
using System.Windows.Shapes;

namespace EducationAppHabLat.Windows
{
    /// <summary>
    /// Логика взаимодействия для AreYouSerious.xaml
    /// </summary>
    public partial class AreYouSerious : Window
    {
        public AreYouSerious()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            App.choiceEdit = true;
            this.Close();
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            App.choiceEdit = false;
            this.Close();
        }
    }
}