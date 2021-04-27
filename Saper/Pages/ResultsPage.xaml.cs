using Saper.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    public partial class ResultsPage : Page
    {
        MainMenu mainMenu;

        public ResultsPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;

            ShowScoreboard(GetScoreboard());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage(mainMenu));
        }

        private List<Winner> GetScoreboard()
        {
            List<Winner> scores = new List<Winner>();

            StreamReader reader = new StreamReader("scoreboard.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                scores.Add(new Winner()
                {
                    place = "",
                    time = data[0],
                    nickname = data[1],
                    level = data[2],
                    bombAmount = data[3],
                    mapSize = data[4]
                });
            }
            reader.Close();

            scores.Sort(delegate (Winner x, Winner y)
            {
                return x.time.CompareTo(y.time);
            });

            int counter = 1;

            foreach (Winner person in scores)
            {
                person.place = counter.ToString();
                counter++;
            }

            return scores;
        }

        private void ShowScoreboard(List<Winner> scores)
        {
            DataGrid.ItemsSource = scores;
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
    }
}
