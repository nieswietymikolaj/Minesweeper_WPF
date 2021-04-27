using Saper.Classes;
using Saper.Pages;
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

namespace Saper
{
    public partial class MainWindow : Window
    {
        MainMenu mainMenu = new MainMenu("Music/Chiptune.wav", true, 8, 10, "początkujący");

        public MainWindow()
        {
            InitializeComponent();

            mainMenu.PlaySong();

            MainFrame.NavigationService.Navigate(new MainMenuPage(mainMenu));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
