
using System.Management;
using System.Linq;

namespace Samsara.Support.Util
{
    public class NetworkUtil
    {
        public static string GetMACAddresses()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            return string.Join(" ", moc.Cast<ManagementObject>().Where(x => (bool)x["IPEnabled"]).Select(x => x["MacAddress"].ToString()).ToArray());
        }
    }
}
    
