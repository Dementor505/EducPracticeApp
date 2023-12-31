﻿using EducationAppHabLat.MyBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace EducationAppHabLat.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutUs.xaml
    /// </summary>
    public partial class AboutUs : Page
    {
        public AboutUs()
        {
            InitializeComponent();
            // Ссылка на XL таблицу
            string soucer_xl = "https://www.youtube.com/watch?v=tn70kB4Whlw";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                QrCode.Source = bitmapimage;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.isStudent == true)
            {
                Navigation.NextPage(new PageComponent("empty", new EmptyPage()));
            }
            if(App.isAdmin == true)
            {
                Navigation.NextPage(new PageComponent("empty", new EmptyPage()));
            }
            if(App.isStudent == false && App.isAdmin == false)
            {
                Navigation.NextPage(new PageComponent("authorization", new Authorization()));
            }
        }
    }
}