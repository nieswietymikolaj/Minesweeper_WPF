using Saper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Saper.Pages
{
    public partial class AnimatedBombPage : Page
    {
        MainMenu mainMenu;
        float counter;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public AnimatedBombPage(MainMenu mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;

            counter = 0;

            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.25);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            counter++;

            if(counter == 10)
            {
                mainMenu.PlayExplosion();
            }
            else if (counter == 13)
            {
                dispatcherTimer.Stop();
                this.NavigationService.Navigate(new LostGamePage(mainMenu));
            }
        }
    }
}
