using Saper.Classes;
using System;
using System.Collections.Generic;
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

namespace Saper.Pages
{
    public partial class SaveResultPage : Page
    {
        MainMenu mainMenu;

        public SaveResultPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;

            TextBox.DataContext = mainMenu;
            TextBox.Focus();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mainMenu.nickname == null || mainMenu.nickname.Length == 0)
            {
                ValidationText.Visibility = Visibility.Visible;
            }
            else
            {
                ValidationText.Visibility = Visibility.Hidden;
            }
        }

        private void SaveScore()
        {
            StreamWriter writer = File.AppendText("scoreboard.txt");
            writer.WriteLine(mainMenu.playTime.ToString().PadLeft(4, '0') + " " + mainMenu.nickname + " " + mainMenu.level.ToUpper() + " " + mainMenu.bombAmount + " " + mainMenu.mapSize);
            writer.Close();
            mainMenu.nickname = null;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainMenu.nickname != null && mainMenu.nickname.Length != 0)
            {
                mainMenu.nickname = mainMenu.nickname.Replace(" ", "_");

                SaveScore();
                this.NavigationService.Navigate(new MainMenuPage(mainMenu));
            }
            else
            {
                ValidationText.Visibility = Visibility.Visible;
            }
        }
    }
}
