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

        public List<string> Blacklist = new List<string>
        {
            "administrador do sistema nf-e", 
            "cobranca@platinacsc.com.br",
            "cte@expressorodominas.com.br", 
            "ems@santher.com.br", 
            "higietopp@higietopp.com.br", 
            "info@webmail-seguro.com.br",
            "mailer-daemon@googlemail.com",
            "marilannfe@marilan.com",
            "mensageiro@weblayer.com.br",
            "microsiga@belesso.com.br" ,
            "Microsoft Outlook",
            "msaf_dfe@peccin.com.br" ,
            "naoresponder@oobj-dfe.com.br",
            "nfe.out.brasil@cmpc.com.br",
            "nfe@casteloalimentos.com.br" ,
            "nfe@davekmcasa.com.br",
            "totvs@davekmcasa.com.br",
            "nfe@docile.com.br", 
            "nf-e@santher.com.br",
            "nfe2@wyda.com",
            "nfe@melitta.com.br",
            "nfeprafesta@prafesta.com.br",
            "nfeunimarka@unimarka.com.br", 
            "no-reply-bacardi",
            "postmaster",
            "sap basis infraestructura",
            "webmaster",
            "nfe_s@riclan.com.br",
            "xml@danacosmeticos.com.br"            
        };
    }


}