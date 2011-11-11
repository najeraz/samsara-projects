using System;
using System.Net;

namespace SamsaraWebsiteUpdateDataService
{
    public class FTPHelper
    {
        public static bool ExistsFile(string ftpServerIP, string ftpUser, string ftpPassword, string fileName)
        {
            string uri = "ftp://" + ftpServerIP + "/" + fileName;
            FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(uri);
            reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
            }

            return true;
        }

        public static long FileSize(string ftpServerIP, string ftpUser, string ftpPassword, string fileName)
        {
            string uri = "ftp://" + ftpServerIP + "/" + fileName;
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
            reqFTP.UseBinary = true;

            FtpWebResponse loginresponse = (FtpWebResponse)reqFTP.GetResponse();
            FtpWebResponse respSize = (FtpWebResponse)reqFTP.GetResponse();
            respSize = (FtpWebResponse)reqFTP.GetResponse();
            long size = respSize.ContentLength;

            respSize.Close();

            return size;
        }
    }
}
