
using System;

namespace Samsara.Framework.Util
{
    public class ExceptionsUtil
    {
        public static string InnerExceptionsMessages(Exception exception)
        {
            string allMessages = string.Empty;

            do
            {
                allMessages += exception.Message + Environment.NewLine + Environment.NewLine;
                exception = exception.InnerException;
            }while(exception != null);

            return allMessages;
        }
    }
}
