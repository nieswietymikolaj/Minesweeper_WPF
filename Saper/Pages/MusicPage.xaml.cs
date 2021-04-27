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
    public partial class MusicPage : Page
    {
        MainMenu mainMenu;

        public MusicPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void SongsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SongsPage(mainMenu));
        }

        private void TurnMusicButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();

            if (mainMenu.musicFlag == true)
            {
                mainMenu.StopMusic();
                TurnButton.Content = "WŁ MUZYKĘ";
                image.UriSource = new Uri(@"../Images/Play.png", UriKind.Relative);
            }
            else
            {
                mainMenu.PlaySong();
                TurnButton.Content = "WYŁ MUZYKĘ";
                image.UriSource = new Uri(@"../Images/Mute.png", UriKind.Relative);
            }

            PictureLeft.Source = image;
            PictureRigth.Source = image;
            image.EndInit();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage(mainMenu));
        }

        private void Songs_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/Song.png";
            ChangeValues(SongsButton, path, buttonWidth);
        }

        private void TurnMusic_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path;
            if (mainMenu.musicFlag == true)
            {
                path = "../Images/Menu/Mute.png";
            }
            else
            {
                path = "../Images/Menu/Play.png";
            }
            ChangeValues(TurnButton, path, buttonWidth);
        }

        private void Return_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 250;
            string path = "../Images/Menu/Return.png";
            ChangeValues(ReturnButton, path, buttonWidth);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeValuesBack(SongsButton, 280);
            ChangeValuesBack(TurnButton, 280);
            ChangeValuesBack(ReturnButton, 220);

            PictureLeft.Source = null;
            PictureRigth.Source = null;
        }

        private void ChangeValuesBack(Button button, int buttonWidth)
        {
            button.Width = buttonWidth;
            button.Background = new SolidColorBrush(Color.FromRgb(255, 235, 59));
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 235, 59));
        }

        private void ChangeValues(Button button, string path, int buttonWidth)
        {
            button.Width = buttonWidth;
            button.Background = Brushes.LightYellow;
            button.BorderBrush = Brushes.LightYellow;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@path, UriKind.Relative);
            image.EndInit();
            PictureLeft.Source = image;
            PictureRigth.Source = image;
        }
    }
}
