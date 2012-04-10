
using System.Collections.Generic;
using System.IO;

namespace Samsara.Framework.Util
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

        public static void Write(Dictionary<string, string> dictionary, string file)
        {
            using (FileStream fs = File.OpenWrite(file))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Put count.
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        public static Dictionary<string, string> Read(string file)
        {
            var result = new Dictionary<string, string>();
            using (FileStream fs = File.OpenRead(file))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Get count.
                int count = reader.ReadInt32();
                // Read in all pairs.
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    result[key] = value;
                }
            }
            return result;
        }

    }
}
