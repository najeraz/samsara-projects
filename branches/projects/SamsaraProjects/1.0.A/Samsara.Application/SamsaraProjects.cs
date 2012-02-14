
using System;
using System.Diagnostics;
using Samsara.Main.Forms.Forms;

namespace Samsara.Application
{
    static class SamsaraProjects
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        [DebuggerStepThrough]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
        }
    }
}
