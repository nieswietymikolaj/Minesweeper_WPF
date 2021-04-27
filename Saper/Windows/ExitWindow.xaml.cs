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
using System.Windows.Shapes;

namespace Saper.Windows
{
    public partial class ExitWindow : Window
    {
        MainMenu mainMenu;

        public ExitWindow(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.gameOn = false;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
