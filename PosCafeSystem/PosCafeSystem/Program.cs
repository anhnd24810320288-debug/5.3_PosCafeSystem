using CafePOSSystem;
using CafePOSSystem;
using System;
using System.Windows.Forms;

namespace CafePOSSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormQuanLyThucDon());
        }
    }
}