using System;
using System.Windows.Forms;

namespace ConsciousbetApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new UI.Form1()); // inicia o Form1
        }
    }
}
