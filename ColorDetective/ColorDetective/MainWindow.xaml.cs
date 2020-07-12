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

            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp = new Bitmap(screenWidth, screenHeight))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                }

                // Do something with the Bitmap here, like save it to a file:
                bmp.Save("temp.png", ImageFormat.Png);
            }

            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp = new Bitmap((int)this.Width, (int)this.Height))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(X, Y, 0, 0, bmp.Size);
                }

                // Do something with the Bitmap here, like save it to a file:
                bmp.Save("temp1.png", ImageFormat.Png);
            }

            Bitmap mybitmap;
            Bitmap bmp2 = new Bitmap(200, 200);
            // Create a bitmap of the appropriate size to receive the screenshot.
            //using (Bitmap bmp = new Bitmap(200, 200))
            //{
            // Draw the screenshot into our bitmap.
            using (Graphics g = Graphics.FromImage(bmp2))
            {
                g.CopyFromScreen(X + 38, Y + 207, 0, 0, bmp2.Size);
            }

            // Do something with the Bitmap here, like save it to a file:
            bmp2.Save("temp2.png", ImageFormat.Png);
            mybitmap = bmp2;
            //}


            // color

            // Load bitmap from image
            //Bitmap mybitmap = bmp;


            Color[,] pixelArray = new Color[10, 10];

            int Wi = mybitmap.Width / 2;
            int He = mybitmap.Height / 2;
            int W = Wi - 11;
            int H = He - 9;

            int i, j;

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    pixelArray[i, j] = mybitmap.GetPixel(W, H);
                    H++;
                }
                W++;
            }

            //while (i < 10)
            //{
            //    while (j < 10)
            //    {
            //        pixelArray[i, j] = mybitmap.GetPixel(W,H);
            //        H++;
            //        j++;
            //    }
            //    W++;
            //    i++;
            //}

            Bitmap newBlks = new Bitmap(500, 500);
            for (i = 0; i < 500; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    newBlks.SetPixel(i, j, pixelArray[i / 50, j / 50]);
                }
            }
            newBlks.Save("pixelBlocks.png", ImageFormat.Png);


            //// Set new pixel relative width and heights
            //int newPicW = mybitmap.Width;
            //int newPicH = mybitmap.Height;
            //int newPixelW = mybitmap.Width / 10;
            //int newPixelH = mybitmap.Height / 10;

            //Color c;
            //int tot = 0;
            //int A = 0;
            //int R = 0;
            //int G = 0;
            //int B = 0;
            //for (i = 0; i < newPixelW; i++)
            //{
            //    for (j = 0; j < newPixelH; j++)
            //    {
            //        c = mybitmap.GetPixel(i, j);
            //        A += c.A; 
            //        R += c.R;
            //        G += c.G;
            //        B += c.B;
            //        tot++;
            //    }
            //}

            //A /= tot;
            //R /= tot;
            //G /= tot;
            //B /= tot;

            //Color avg = Color.FromArgb(A,R,G,B);




            //Color c = mybitmap.GetPixel(200, 200);
            //Console.WriteLine($"A: " + c.A + " R: " + c.R + " G: " + c.G + " B: " + c.B);

            //Bitmap newP = new Bitmap(newPicW, newPicH);

            //for (i = 0; i < newPicW; i++)
            //{
            //    for (j = 0; j < newPicH; j++)
            //    {
            //        if (i < 50 && j < 50) {
            //            newP.SetPixel(i, j, avg);
            //        }
            //        else
            //        {
            //            newP.SetPixel(i, j, mybitmap.GetPixel(i,j));
            //        }
            //    }
            //}

            //Color c = Color.FromArgb(alpha, red, green, blue);
            //newP.SetPixel()

            Bitmap newP = new Bitmap(mybitmap.Width, mybitmap.Height);

            for (i = 0; i < mybitmap.Width; i++)
            {
                for (j = 0; j < mybitmap.Height; j++)
                {
                    if (i >= 150 && j >= 150 && i < 160 && j < 160)
                    {
                        newP.SetPixel(i, j, mybitmap.GetPixel(i, j));
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

