using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace ColorDetective
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimizeButton_OnClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitButton_OnClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            //System.Windows.Point relativePoint = 
            int X = (int)System.Windows.Application.Current.MainWindow.Left;
            int Y = (int)System.Windows.Application.Current.MainWindow.Top;

            Bitmap mybitmap;
            Bitmap bmp2 = new Bitmap(200, 200);
    
            using (Graphics g = Graphics.FromImage(bmp2))
            {
                g.CopyFromScreen(X + 38, Y + 207, 0, 0, bmp2.Size);
            }

            // Do something with the Bitmap here, like save it to a file:
            bmp2.Save("temp2.png", ImageFormat.Png);
            mybitmap = bmp2;


            // color

            // Load bitmap from image
            //Bitmap mybitmap = bmp;


            Color[,] pixelArray = new Color[10, 10];

            int midW = mybitmap.Width / 2;
            int midH = mybitmap.Height / 2;
            int W = midW - 5;
            int H = midH - 5;

            int i, j;

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    pixelArray[i, j] = mybitmap.GetPixel(W + i, H + j);
                    //W++;
                }
                //H++;
            }

            Bitmap newBlks = new Bitmap(500, 500);
            for (i = 0; i < 500; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    newBlks.SetPixel(i, j, pixelArray[i / 50, j / 50]);
                }
            }
            newBlks.Save("pixelBlocks.png", ImageFormat.Png);

            //Bitmap newBlks = new Bitmap(10, 10);
            //for (i = 0; i < 10; i++)
            //{
            //    for (j = 0; j < 10; j++)
            //    {
            //        newBlks.SetPixel(i, j, pixelArray[i, j]);
            //    }
            //}
            //newBlks.Save("pixelBlocks.png", ImageFormat.Png);

            Bitmap newP = new Bitmap(mybitmap.Width, mybitmap.Height);

            int cnt = 0;

            for (i = 0; i < mybitmap.Width; i++)
            {
                for (j = 0; j < mybitmap.Height; j++)
                {
                    if (i >= midW-5 && j >= midH-5 && i < midW+5 && j < midH+5)
                    {
                        newP.SetPixel(i, j, mybitmap.GetPixel(i, j));
                        cnt++;
                    }
                    else
                    {
                        newP.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                    }
                    
                }
            }

            newP.Save("pixelated.png", ImageFormat.Png);
        }
    }
}

