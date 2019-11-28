using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace RemoveEmailsDuplicadoBasico
{
    internal class MailItemProcessorBasico
    {
        private readonly List<string> MensagensUnicas = new List<string>();

        public void CleanKeys()
        {
            MensagensUnicas.Clear();
        }

        public bool ProcessMailItem(MailItem item)
        {
            var key = GetKeys(item);

            if (MensagensUnicas.Contains(key))
            {
                item.Delete();
                return true;
            }
            else
            {
                MensagensUnicas.Add(key);
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
