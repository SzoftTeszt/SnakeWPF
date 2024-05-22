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

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image[,] palya = new Image[20, 20];
        int[,] racs = new int[20, 20];
        public List<Position> SnakeBody = new List<Position>();

        public MainWindow()
        {
            InitializeComponent();
            Init();
            
        }
        private void InitSnake() {
            for (int i = 0; i < 10; i++)
            {
                SnakeBody.Add(new Position(9, i));               
            }
            DrawSnake();
        }
        private void Init() {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    Image img = new Image();
                    img.Width = 30;
                    img.Height = 30;
                    Canvas.SetLeft(img, i * 30);
                    Canvas.SetTop(img, j * 30);
               
                    palya[i, j] = img;
                    canvas.Children.Add(palya[i, j]);
                }
            Position gyumi = new Position();
            racs[gyumi.X, gyumi.Y] = 2;
            InitSnake();
            Draw();
        }
        private void DrawSnake() {

            foreach (var item in SnakeBody)
            {
                racs[item.X, item.Y] = 1;
            }
        }

        private void stepDown() {
            Position head = SnakeBody[SnakeBody.Count - 1];
            Position newHead = new Position(head.X, head.Y+1);
            SnakeBody.Add(newHead);
            racs[SnakeBody[0].X, SnakeBody[0].Y] = 0;
            racs[newHead.X, newHead.Y] = 1;
            SnakeBody.Remove(SnakeBody[0]);
            Draw();

        }

         private void Draw() {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    if (racs[i,j]==0)
                        palya[i,j].Source = new BitmapImage(new Uri("Images/TileGreen.png", UriKind.Relative)); 
                    if (racs[i,j]==1)
                        palya[i,j].Source = new BitmapImage(new Uri("Images/TileBlue.png", UriKind.Relative)); 
                    if (racs[i,j]==2)
                        palya[i,j].Source = new BitmapImage(new Uri("Images/TilePurple.png", UriKind.Relative));
                }
                   

        }
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    stepDown();
                    break;

            }
        }
    }
}
