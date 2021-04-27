using Saper.Classes;
using Saper.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class GamePage : Page
    {
        MainMenu mainMenu;

        MainWindow window = (MainWindow)Application.Current.MainWindow;

        int mapSize, bombAmount;
        int bombsLeft = 0, playTime = 0;
        bool newGame = false;
        string endFlag = "";

        char[,] map = new char[50, 50], checkMap = new char[50, 50];
        int[,] bombMap = new int[50, 50];
        int[] bombsList = new int[668];

        BitmapImage facingDown = new BitmapImage();
        BitmapImage flagged = new BitmapImage();
        BitmapImage redBomb = new BitmapImage();

        List<BitmapImage> numbers;

        System.Timers.Timer timer;

        public GamePage(MainMenu mainMenu)
        {
            InitializeComponent();

            if (mainMenu.mapSize > 16)
            {
                window.Height = 660 + (mainMenu.mapSize - 16) * 32;
            }

            Loaded += (x, y) => Keyboard.Focus(GameCanvas);

            this.mainMenu = mainMenu;
            this.mapSize = mainMenu.mapSize;
            this.bombAmount = mainMenu.bombAmount;

            SetGame();
            NewGame();
        }

        private void SetGame()
        {
            GameInterface.Width = mapSize * 32;
            GameCanvas.Width = mapSize * 32;
            GameCanvas.Height = mapSize * 32;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += ShowLeftTime;
            timer.AutoReset = true;

            LoadAllImages();
        }

        private void NewGame()
        {
            bombsLeft = bombAmount;
            playTime = 0;

            TimeText.Text = (playTime / 100).ToString() + (playTime % 100 / 10).ToString() + (playTime % 10).ToString();

            mainMenu.gameOn = true;
            newGame = true;

            ShowLeftBombs();
            StartMap();
        }

        private void StartMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '#';
                    checkMap[i, j] = '#';
                    bombMap[i, j] = 0;
                }
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Rectangle rectangle = new Rectangle();

                    rectangle.Fill = new ImageBrush
                    {
                        ImageSource = facingDown
                    };

                    rectangle.MouseLeftButtonUp += Cell_LeftButtonClick;
                    rectangle.MouseRightButtonUp += Cell_RightButtonClick;

                    rectangle.Width = 32;
                    rectangle.Height = 32;

                    Canvas.SetLeft(rectangle, j * 32);
                    Canvas.SetTop(rectangle, i * 32);

                    GameCanvas.Children.Add(rectangle);
                }
            }
        }

        public void Cell_LeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            if (!mainMenu.gameOn || IsGameWin())
            {
                return;
            }

            if (timer.Enabled == false)
            {
                timer.Enabled = true;
            }

            Point point = e.GetPosition(GameCanvas);

            int posX = (int)point.X / 32;
            int posY = (int)point.Y / 32;

            CheckCell(posX, posY);

            if (IsGameWin())
            {
                timer.Enabled = false;
                mainMenu.playTime = playTime;
                endFlag = "win";
            }

            if (mainMenu.gameOn == false)
            {
                ShowMap(true);
                timer.Enabled = false;
                endFlag = "lose";
            }

            ShowLeftBombs();
            ShowMap(false);
        }

        public void Cell_RightButtonClick(object sender, MouseButtonEventArgs e)
        {
            if (!mainMenu.gameOn || IsGameWin())
            {
                return;
            }

            Point point = e.GetPosition(GameCanvas);

            int posX = (int)point.X / 32;
            int posY = (int)point.Y / 32;

            FlagCell(posX, posY);
            ShowLeftBombs();
            ShowMap(false);
        }

        private void ShowLeftTime(Object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                if (playTime < 999)
                {
                    playTime++;
                }

                string time;
                time = (playTime / 100).ToString() + (playTime % 100 / 10).ToString() + (playTime % 10).ToString();

                TimeText.Text = time;
            });
        }

        private void ShowLeftBombs()
        {
            string bombs;

            if (bombsLeft >= 0)
            {
                bombs = (bombsLeft % 1000 / 100).ToString() + (bombsLeft % 100 / 10).ToString() + (bombsLeft % 10).ToString();
            }
            else if (bombsLeft < 0 && bombsLeft > -10)
            {
                bombs = "-0" + ((bombsLeft % 10) * (-1)).ToString();
            }
            else
            {
                bombs = bombsLeft.ToString();
            }

            BombsText.Text = bombs;
        }

        private void ShowMap(bool isGameOver)
        {
            Rectangle rectangle;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] != checkMap[i, j] || isGameOver)
                    {
                        rectangle = new Rectangle();

                        if (bombMap[i, j] == 1 && isGameOver)
                        {
                            rectangle.Fill = new ImageBrush
                            {
                                ImageSource = redBomb
                            };
                        }
                        else if (map[i, j] == '#')
                        {
                            rectangle.Fill = new ImageBrush
                            {
                                ImageSource = facingDown
                            };

                            if (!isGameOver)
                            {
                                rectangle.MouseRightButtonUp += Cell_RightButtonClick;
                            }
                        }
                        else if (map[i, j] == ' ')
                        {
                            rectangle.Fill = new SolidColorBrush(Colors.LightGray);
                        }
                        else if (map[i, j] == 'F')
                        {
                            rectangle.Fill = new ImageBrush
                            {
                                ImageSource = flagged
                            };

                            if (!isGameOver)
                            {
                                rectangle.MouseRightButtonUp += Cell_RightButtonClick;
                            }
                        }
                        else
                        {
                            rectangle.Fill = new ImageBrush
                            {
                                ImageSource = numbers[Convert.ToInt32(map[i, j] - 49)]
                            };
                        }

                        rectangle.Width = 32;
                        rectangle.Height = 32;

                        if (!isGameOver)
                        {
                            rectangle.MouseLeftButtonUp += Cell_LeftButtonClick;
                        }

                        Canvas.SetLeft(rectangle, i * 32);
                        Canvas.SetTop(rectangle, j * 32);

                        GameCanvas.Children.Add(rectangle);

                        checkMap[i, j] = map[i, j];
                    }
                }
            }
        }

        private bool IsGameWin()
        {
            int counter = 0;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == '#' || map[i, j] == 'F')
                    {
                        counter++;
                    }
                }
            }

            if (counter > bombAmount)
            {
                return false;
            }
            return true;
        }

        private void CheckCell(int posX, int posY)
        {
            if (map[posX, posY] == 'F')
            {
                return;
            }

            if (newGame)
            {
                InitMap(posX, posY);
                bombsLeft = bombAmount;
                playTime = 0;
                newGame = false;
            }

            if (bombMap[posX, posY] == 1)
            {
                mainMenu.gameOn = false;
                return;
            }

            char counter = '0';

            if (map[posX, posY] != '#' && map[posX, posY] != ' ' && map[posX, posY] != 'F')
            {
                for (int i = Math.Max(0, posX - 1); i <= Math.Min(mapSize - 1, posX + 1); i++)
                {
                    for (int j = Math.Max(0, posY - 1); j <= Math.Min(mapSize - 1, posY + 1); j++)
                    {
                        if (map[i, j] == 'F')
                        {
                            counter++;
                        }
                    }
                }

                if (counter == map[posX, posY])
                {
                    for (int i = Math.Max(0, posX - 1); i <= Math.Min(mapSize - 1, posX + 1); i++)
                    {
                        for (int j = Math.Max(0, posY - 1); j <= Math.Min(mapSize - 1, posY + 1); j++)
                        {
                            if (map[i, j] == '#')
                            {
                                CheckCell(i, j);
                            }
                        }
                    }
                }
            }

            RevealField(posX, posY);
        }

        private void RevealField(int posX, int posY)
        {
            char counter = '0';

            for (int i = Math.Max(0, posX - 1); i <= Math.Min(mapSize - 1, posX + 1); i++)
            {
                for (int j = Math.Max(0, posY - 1); j <= Math.Min(mapSize - 1, posY + 1); j++)
                {
                    if (bombMap[i, j] == 1)
                    {
                        counter++;
                    }
                }
            }

            if (counter != '0')
            {
                map[posX, posY] = counter;
                return;
            }

            map[posX, posY] = ' ';

            for (int i = Math.Max(0, posX - 1); i <= Math.Min(mapSize - 1, posX + 1); i++)
            {
                for (int j = Math.Max(0, posY - 1); j <= Math.Min(mapSize - 1, posY + 1); j++)
                {
                    if (bombMap[i, j] == 0 && map[i, j] == '#')
                    {
                        RevealField(i, j);
                    }
                }
            }
        }

        private void FlagCell(int posX, int posY)
        {
            if (map[posX, posY] == 'F')
            {
                map[posX, posY] = '#';
                bombsLeft++;
            }
            else if (map[posX, posY] == '#')
            {
                map[posX, posY] = 'F';
                bombsLeft--;
            }
            else return;
        }

        private void InitMap(int posX, int posY)
        {
            Random random = new Random();

            int[] notBomb = new int[9];
            notBomb[0] = (posX * mapSize) + posY;

            for (int i = 1; i < 9; i++)
            {
                notBomb[i] = -1;
            }

            int counter = 1;

            for (int i = Math.Max(0, posX - 1); i <= Math.Min(mapSize - 1, posX + 1); i++)
            {
                for (int j = Math.Max(0, posY - 1); j <= Math.Min(mapSize - 1, posY + 1); j++)
                {
                    if (i == posX && j == posY)
                    {
                        continue;
                    }
                    notBomb[counter] = i * mapSize + j;
                    counter++;
                }
            }

            for (int i = 0; i < bombAmount; i++)
            {
                int bomb = random.Next(mapSize * mapSize);

                while (true)
                {
                    if (!Array.Exists(bombsList, element => element == bomb) && !Array.Exists(notBomb, element => element == bomb))
                    {
                        break;
                    }
                    bomb = random.Next(mapSize * mapSize);
                }

                bombsList[i] = bomb;
            }

            for (int i = 0; i < bombAmount; i++)
            {
                bombMap[bombsList[i] / mapSize, bombsList[i] % mapSize] = 1;
            }
        }

        private void BombButton_Click(object sender, RoutedEventArgs e)
        {
            endFlag = "";
            timer.Enabled = false;
            NewGame();
        }

        private void GameCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Keyboard.Focus(GameCanvas);
        }

        private void NewGamePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (endFlag == "win")
            {
                endFlag = "";
                window.Height = 650;
                this.NavigationService.Navigate(new WinGamePage(mainMenu));
            }
            else if (endFlag == "lose")
            {
                endFlag = "";
                window.Height = 650;
                this.NavigationService.Navigate(new AnimatedBombPage(mainMenu));
            }
        }

        public void LoadAllImages()
        {
            LoadImage(facingDown, "Images/Game/facingDown.png");
            LoadImage(flagged, "Images/Game/flagged.png");
            LoadImage(redBomb, "Images/Game/redBomb.png");

            numbers = new List<BitmapImage>();

            for (int i = 1; i <= 8; i++)
            {
                BitmapImage number = new BitmapImage();

                LoadImage(number, "Images/Game/" + i + ".png");

                numbers.Add(number);
            }
        }

        public void LoadImage(BitmapImage bitmapImage, string path)
        {
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@path, UriKind.Relative);
            bitmapImage.EndInit();
        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                timer.Enabled = false;

                ExitWindow exitWindow = new ExitWindow(mainMenu) { Owner = Window.GetWindow(this) };
                exitWindow.ShowDialog();

                if (mainMenu.gameOn == false)
                {
                    endFlag = "";
                    window.Height = 650;
                    this.NavigationService.Navigate(new MainMenuPage(mainMenu));
                }

                if (newGame == false)
                {
                    timer.Enabled = true;
                }
            }
        }
    }
}
