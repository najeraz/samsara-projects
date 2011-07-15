using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ComisionesAgentes
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
