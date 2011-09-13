
using System.IO;

namespace Samsara.Support.Util
{
    public class FilesUtil
    {
        public static byte[] StreamFile(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] fileData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(fileData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return fileData; //return the byte data
        }
    }
}
