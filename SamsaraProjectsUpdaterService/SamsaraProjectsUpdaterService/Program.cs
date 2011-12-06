using System.ServiceProcess;

namespace SamsaraProjectsUpdaterService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new SamsaraProjectsUpdaterService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
