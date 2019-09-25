using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System;

namespace RemoveEmailsDuplicados
{
    internal class MailItemProcessor
    {
        private readonly List<string> messageKeys = new List<string>();
       
        public void CleanKeys()
        {
            messageKeys.Clear();
        }
        
        public bool ProcessMailItem(MailItem item)
        {
            var key = GetKeys(item);

            if (messageKeys.Contains(key))
            {
                item.Delete();
                return true;
            }
            else
            {
                messageKeys.Add(key);
            }

            return false;
        }

        private string GetKeys(MailItem item)
        {
            return String.Format("{0} {1} {2:yyyyMMddhhmmss}",
                 item.SenderEmailAddress, item.Subject, item.SentOn);
        }


    }
}