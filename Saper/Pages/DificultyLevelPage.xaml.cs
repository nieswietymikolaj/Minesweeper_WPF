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
    public partial class DificultyLevelPage : Page
    {
        MainMenu mainMenu;
        string level;
        string pathLeft = "../Images/Menu/SmallBombLeft.png";
        string pathRight = "../Images/Menu/SmallBombRight.png";

        public DificultyLevelPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
            this.level = mainMenu.level;

            if(level == "początkujący")
            {
                BombLeft1.Source = SetCheck(pathLeft);
                BombRigth1.Source = SetCheck(pathRight);
            }
            else if (level == "zaawansowany")
            {
                BombLeft2.Source = SetCheck(pathLeft);
                BombRigth2.Source = SetCheck(pathRight);
            }
            else if (level == "ekspert")
            {
                BombLeft3.Source = SetCheck(pathLeft);
                BombRigth3.Source = SetCheck(pathRight);
            }
        }

        private void EasyLevelButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.SetLevel(8, 10, "początkujący");

            SetUncheck();
            BombLeft1.Source = SetCheck(pathLeft);
            BombRigth1.Source = SetCheck(pathRight);
        }

        private void MiddleLevelButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.SetLevel(16, 40, "zaawansowany");

            SetUncheck();
            BombLeft2.Source = SetCheck(pathLeft);
            BombRigth2.Source = SetCheck(pathRight);
        }

        private void HardLevelButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.SetLevel(24, 99, "ekspert");

            SetUncheck();
            BombLeft3.Source = SetCheck(pathLeft);
            BombRigth3.Source = SetCheck(pathRight);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage(mainMenu));
        }

        private void EasyLevel_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/Easy.png";
            ChangeValues(EasyButton, path, buttonWidth);
        }

        private void MiddleLevel_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/Middle.png";
            ChangeValues(MiddleButton, path, buttonWidth);
        }

        private void HardLevel_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 310;
            string path = "../Images/Menu/Hard.png";
            ChangeValues(HardButton, path, buttonWidth);
        }

        private void Return_MouseEnter(object sender, MouseEventArgs e)
        {
            int buttonWidth = 250;
            string path = "../Images/Menu/Return.png";
            ChangeValues(ReturnButton, path, buttonWidth);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeValuesBack(EasyButton, 280);
            ChangeValuesBack(MiddleButton, 280);
            ChangeValuesBack(HardButton, 280);
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
            BombLeft3.Source = null;
            BombRigth3.Source = null;
        }
    }
}
