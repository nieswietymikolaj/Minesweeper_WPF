using Saper.Classes;
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

namespace Saper.Pages
{
    public partial class SongsPage : Page
    {
        MainMenu mainMenu;
        string pathLeft = "../Images/Menu/SmallBombLeft.png";
        string pathRight = "../Images/Menu/SmallBombRight.png";

        public SongsPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;

            if(mainMenu.musicFlag != false)
            {
                if (mainMenu.musicPath == "Music/Chiptune.wav")
                {
                    FirstSong.Foreground = new SolidColorBrush(Color.FromRgb(47, 46, 60));
                    BombLeft1.Source = SetCheck(pathLeft);
                    BombRigth1.Source = SetCheck(pathRight);
                }
                else if (mainMenu.musicPath == "Music/WhatIsLove.wav")
                {
                    SecondSong.Foreground = new SolidColorBrush(Color.FromRgb(47, 46, 60));
                    BombLeft2.Source = SetCheck(pathLeft);
                    BombRigth2.Source = SetCheck(pathRight);
                }
            }
        }

        private void FirstSong_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.musicPath = "Music/Chiptune.wav";
            mainMenu.PlaySong();
            FirstSong.Foreground = new SolidColorBrush(Color.FromRgb(47, 46, 60));
            SecondSong.Foreground = new SolidColorBrush(Color.FromRgb(255, 235, 59));

            SetUncheck();
            BombLeft1.Source = SetCheck(pathLeft);
            BombRigth1.Source = SetCheck(pathRight);
        }

        private void SecondSong_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.musicPath = "Music/WhatIsLove.wav";
            mainMenu.PlaySong();
            SecondSong.Foreground = new SolidColorBrush(Color.FromRgb(47, 46, 60));
            FirstSong.Foreground = new SolidColorBrush(Color.FromRgb(255, 235, 59));

            SetUncheck();
            BombLeft2.Source = SetCheck(pathLeft);
            BombRigth2.Source = SetCheck(pathRight);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MusicPage(mainMenu));
        }

        private void Return_MouseEnter(object sender, MouseEventArgs e)
        {
            ReturnButton.Width = 250;
            ReturnButton.Background = Brushes.LightYellow;
            ReturnButton.BorderBrush = Brushes.LightYellow;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ReturnButton.Width = 220;
            ReturnButton.Background = new SolidColorBrush(Color.FromRgb(255, 235, 59));
            ReturnButton.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 235, 59));
        }

        private BitmapImage SetCheck(string path)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@path, UriKind.Relative);
            image.EndInit();
            return image;
        }

        private void SetUncheck()
        {
            BombLeft1.Source = null;
            BombRigth1.Source = null;
            BombLeft2.Source = null;
            BombRigth2.Source = null;
        }
    }
}
