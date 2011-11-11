using System.ServiceProcess;

namespace SamsaraWebsiteUpdateDataService
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
				new UpdateWebsiteProductsService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
