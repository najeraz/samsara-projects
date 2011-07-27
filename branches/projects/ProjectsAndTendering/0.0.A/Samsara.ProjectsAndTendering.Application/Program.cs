
using System;
using System.Diagnostics;
using Samsara.ProjectsAndTendering.Forms.Forms;

namespace Samsara.ProjectsAndTendering.Application
{
    static class Program
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
            System.Windows.Forms.Application.Run(new ManufacturerForm());
        }
    }
}
