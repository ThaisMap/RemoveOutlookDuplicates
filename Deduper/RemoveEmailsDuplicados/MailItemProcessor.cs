using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;

namespace RemoveEmailsDuplicados
{
    internal class MailItemProcessor
    {
        private readonly List<string> messageKeys = new List<string>();

        private List<string> Blacklist = new List<string>();

        public void AddToBlacklist(List<string> Lista)
        {
            Blacklist.AddRange(Lista);
        }

        public void AddToBlacklist(string email)
        {
            Blacklist.Add(email);
        }

        public void ResetBlacklist()
        {
            Blacklist.Clear();
        }

        public void CleanKeys()
        {
            messageKeys.Clear();
        }

        public bool ProcessMailItem(MailItem item)
        {
            var key = GetKeys(item);

            if (isBlackListed(item) || messageKeys.Contains(key))
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
            return String.Format("{0} {1} {2} {3} {4:ddMMyyyyhhmmss}",
                 item.SenderEmailAddress, item.Subject, item.To, item.CC, item.SentOn);
        }

        public bool isBlackListed(MailItem item)
        {
            return (Blacklist.Contains(item.SenderEmailAddress.ToLower()) || Blacklist.Contains(item.SenderName.ToLower()));
        }
    }
}