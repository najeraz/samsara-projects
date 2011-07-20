using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Forms.Forms;

namespace Samsara.ProjectsAndTendering.Application
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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new TenderingForm());
        }
    }
}
