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
    public partial class MainMenuPage : Page
    {
        MainMenu mainMenu;

        public MainMenuPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage(mainMenu));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage(mainMenu));
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ResultsPage(mainMenu));
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InformationsPage(mainMenu));
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }

        private void Game_MouseEnter(object sender, MouseEventArgs e)
        {
            string path = "../Images/Menu/Game.png";
            ChangeValues(GameButton, path);
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            string path = "../Images/Menu/Settings.png";
            ChangeValues(SettingsButton, path);
        }

        private void Results_MouseEnter(object sender, MouseEventArgs e)
        {
            string path = "../Images/Menu/Results.png";
            ChangeValues(ResultsButton, path);
        }

        private void Informations_MouseEnter(object sender, MouseEventArgs e)
        {
            string path = "../Images/Menu/Informations.png";
            ChangeValues(InformationsButton, path);
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            string path = "../Images/Menu/Exit.png";
            ChangeValues(ExitButton, path);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeValuesBack(GameButton, 220);
            ChangeValuesBack(SettingsButton, 220);
            ChangeValuesBack(ResultsButton, 220);
            ChangeValuesBack(InformationsButton, 220);
            ChangeValuesBack(ExitButton, 220);

            PictureLeft.Source = null;
            PictureRigth.Source = null;
        }

        private void ChangeValuesBack(Button button, int buttonWidth)
        {
            button.Width = buttonWidth;
            button.Background = new SolidColorBrush(Color.FromRgb(255, 235, 59));
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 235, 59));
        }

        private void ChangeValues(Button button, string path)
        {
            button.Width = 250;
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