using System;
using System.Windows.Forms;

namespace SamsaraCommissions
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        [System.Diagnostics.DebuggerStepThrough]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ComisionesForm());
        }
    }
}
