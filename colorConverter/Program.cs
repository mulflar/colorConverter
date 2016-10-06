using System;
using System.Drawing;
using System.IO;

namespace colorConverter
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Introduzca valor de R");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca valor de G");
            int g = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca valor de B");
            int b = int.Parse(Console.ReadLine());
            try
            {
                Bitmap bmp = null;
                //The Source Directory in debug\bin\original\
                string[] files = Directory.GetFiles("original\\");
                foreach (string filename in files)
                {
                    bmp = (Bitmap)Image.FromFile(filename);
                    bmp = ChangeColor(bmp,r,g,b);
                    string[] spliter = filename.Split('\\');
                    //Destination Directory debug\bin\retocada\
                    bmp.Save("retocada\\" + spliter[1]);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static Bitmap ChangeColor(Bitmap scrBitmap,int r, int g, int b)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
            Color newColor = Color.Transparent;
            Color actualColor;
            //make an empty bitmap the same size as scrBitmap
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    //get the pixel from the scrBitmap image
                    actualColor = scrBitmap.GetPixel(i, j);
                    if (actualColor.R == r && actualColor.G==g && actualColor.B==b)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, actualColor);
                }
            }
            return newBitmap;
        }
    }
}