using Saper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    public partial class SettingsPage : Page
    {
        MainMenu mainMenu;

        public SettingsPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void LevelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DificultyLevelPage(mainMenu));
        }

        private void MapSizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MapSizePage(mainMenu));
        }

        private void BombAmountButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BombAmountPage(mainMenu));
        }

        private void MusicButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MusicPage(mainMenu));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage(mainMenu));
        }

        private void Level_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/Level.png";
            ChangeValues(LevelButton, path, buttonWidth);
        }

        private void MapSize_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/MapSize.png";
            ChangeValues(MapSizeButton, path, buttonWidth);
        }

        private void BombAmount_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 250;
            string path = "../Images/Menu/BombAmount.png";
            ChangeValues(BombAmountButton, path, buttonWidth);
        }

        private void Music_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 250;
            string path = "../Images/Menu/Music.png";
            ChangeValues(MusicButton, path, buttonWidth);
        }

        private void Return_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 250;
            string path = "../Images/Menu/Return.png";
            ChangeValues(ReturnButton, path, buttonWidth);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeValuesBack(LevelButton, 300);
            ChangeValuesBack(MapSizeButton, 300);
            ChangeValuesBack(BombAmountButton, 220);
            ChangeValuesBack(MusicButton, 220);
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