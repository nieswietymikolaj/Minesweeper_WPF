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

    public partial class BombAmountPage : Page
    {
        MainMenu mainMenu;
        int bombAmount, mapSize;

        public BombAmountPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
            this.bombAmount = mainMenu.bombAmount;
            this.mapSize = mainMenu.mapSize;

            TextBox.Text = bombAmount.ToString();
            MapTextBlock.Text = "ROZMIAR MAPY: " + mapSize + " x " + mapSize;
            BombTextBlock.Text = "(10 - " + (mapSize * mapSize - mapSize - 3) + ")";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage(mainMenu));
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

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (bombAmount >= 11)
            {
                bombAmount--;
                mainMenu.SetBombAmount(bombAmount);
                TextBox.Text = bombAmount.ToString();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox.Text != null)
            {
                Int32.TryParse(TextBox.Text, out int bombs);

                if (bombs >= 11 && bombs <= mapSize * mapSize - mapSize - 4)
                {
                    bombAmount = bombs;
                    mainMenu.SetBombAmount(bombAmount);
                }
                else if (bombs < 11)
                {
                    bombAmount = 10;
                    mainMenu.SetBombAmount(bombAmount);
                }
                else if (bombs > mapSize * mapSize - mapSize - 4)
                {
                    bombAmount = mapSize * mapSize - mapSize - 3;
                    mainMenu.SetBombAmount(bombAmount);
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox.Text = bombAmount.ToString();
            }
        }

        private void BombGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox.Text = bombAmount.ToString();
            Keyboard.ClearFocus();
        }

        private void RigthArrow_Click(object sender, RoutedEventArgs e)
        {
            if (bombAmount <= mapSize * mapSize - mapSize - 4)
            {
                bombAmount++;
                mainMenu.SetBombAmount(bombAmount);
                TextBox.Text = bombAmount.ToString();
            }
        }
    }
}
