
using System;
using System.Collections.Generic;

namespace Samsara.Framework.Util
{
    public class ExceptionsUtil
    {
        public static string InnerExceptionsMessages(Exception exception)
        {
            string allMessages = string.Empty;
            Stack<string> lstMessages = new Stack<string>();

            do
            {
                lstMessages.Push(exception.Message);
                exception = exception.InnerException;
            }while(exception != null);

            foreach (string message in lstMessages)
            {
                allMessages += message + Environment.NewLine + Environment.NewLine;
            }

            return allMessages;
        }
    }
}
