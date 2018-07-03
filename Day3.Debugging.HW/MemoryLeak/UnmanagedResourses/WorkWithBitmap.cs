using System;
using System.Drawing;

namespace MemoryLeak.UnmanagedResourses
{
    public static class WorkWithBitmap
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static IntPtr GetHbitmapDemo(string path)
        {
            Bitmap bmp = new Bitmap(path);
            IntPtr hBitmap = bmp.GetHbitmap();

            // do something whith bitmap

            //DeleteObject(hBitmap);

            return hBitmap;
        }
    }
}
