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
    public partial class LostGamePage : Page
    {
        MainMenu mainMenu;

        public LostGamePage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void EndGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(mainMenu.musicFlag == true)
            {
                mainMenu.PlaySong();
            }
            this.NavigationService.Navigate(new MainMenuPage(mainMenu));
        }
    }
}
