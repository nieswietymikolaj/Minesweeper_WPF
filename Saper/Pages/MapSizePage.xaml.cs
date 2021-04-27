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
    public partial class MapSizePage : Page
    {
        MainMenu mainMenu;
        int bombAmount, mapSize;

        public MapSizePage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
            this.mapSize = mainMenu.mapSize;
            this.bombAmount = mainMenu.bombAmount;

            TextBox.Text = mapSize.ToString();
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
            if (mapSize >= 9)
            {
                mapSize--;
                mainMenu.SetMapSize(mapSize);
                TextBox.Text = mapSize.ToString();

                if (bombAmount > mapSize * mapSize - mapSize)
                {
                    mainMenu.bombAmount = mapSize * mapSize - mapSize;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox.Text != null)
            {
                Int32.TryParse(TextBox.Text, out int map);

                if (map >= 9 && map <= 23)
                {
                    mapSize = map;
                    mainMenu.SetMapSize(mapSize);
                }
                else if (map < 9)
                {
                    mapSize = 8;
                    mainMenu.SetMapSize(mapSize);

                    if (bombAmount > mapSize * mapSize - mapSize)
                    {
                        mainMenu.bombAmount = mapSize * mapSize - mapSize;
                    }
                }
                else if (map > 23)
                {
                    mapSize = 24;
                    mainMenu.SetMapSize(mapSize);
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox.Text = mapSize.ToString();
            }
        }

        private void BombGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox.Text = mapSize.ToString();
            Keyboard.ClearFocus();
        }

        private void RigthArrow_Click(object sender, RoutedEventArgs e)
        {
            if (mapSize <= 23)
            {
                mapSize++;
                mainMenu.SetMapSize(mapSize);
                TextBox.Text = mapSize.ToString();
            }
        }
    }
}
