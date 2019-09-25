using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace RemoveEmailsDuplicados
{
    public partial class Form1 : Form
    {
        static Outlook.Application outlook = new Outlook.Application();
        MailItemProcessor mailItemProcessor = new MailItemProcessor();
        Outlook.NameSpace outlookNamespace = outlook.GetNamespace("MAPI");
        List<Outlook.Folder> pastasEmailSelecionado = new List<Outlook.Folder>();
        List<string> pastasSelecionadas = new List<string>();
        string[] ignorarPastas = {"Itens Excluídos","Contatos Sugeridos", "Itens Enviados",
            "Calendário","Configurações de Ação de Conversa", "Lixo eletrônico",
            "Contatos","Diário","Anotações",
            "Tarefas","Rascunhos","RSS Feeds",
            "Configurações de Etapa Rápida", "News Feed", "Caixa de Saída" };

        Thread thread;
        int contApagados = 0;
        bool keepGoing = true;
        int cont = 1;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var folders = outlookNamespace.Folders;

            foreach (Outlook.Folder f in folders)
            {
                ListBoxCaixas.Items.Add(f.Name);
            }
        }

        private void ListBoxCaixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxCaixas.SelectedIndex > -1)
            {
                CheckedListBoxPastas.Items.Clear();
                pastasEmailSelecionado.Clear();

                foreach (Outlook.Folder f in outlookNamespace.Folders[ListBoxCaixas.SelectedItem].Folders)
                {
                    if (!ignorarPastas.Contains(f.Name))
                    {
                        CheckedListBoxPastas.Items.Add(f.Name);
                        pastasEmailSelecionado.Add(f);
                        EnumerateFolders(f);
                    }
                }
            }
        }

        private void EnumerateFolders(Outlook.Folder folder)
        {
            Outlook.Folders subPastas = folder.Folders;
            if (subPastas.Count > 0)
            {
                foreach (Outlook.Folder subPasta in subPastas)
                {
                    CheckedListBoxPastas.Items.Add(subPasta.Name);
                    pastasEmailSelecionado.Add(subPasta);
                    EnumerateFolders(subPasta);
                }
            }
        }

        private void ButtonProcessar_Click(object sender, EventArgs e)
        {
            pastasSelecionadas.Clear();
            foreach (string item in CheckedListBoxPastas.CheckedItems)
            {
                pastasSelecionadas.Add(item);
            }

            ButtonProcessar.Enabled = false;
            contApagados = 0;
            cont = 1;
            mailItemProcessor.CleanKeys();
            LabelApagados.Text = contApagados.ToString();

            thread = new Thread(ProcessarPastas);
            thread.Start();
        }

        private void ButtonParar_Click(object sender, EventArgs e)
        {
            keepGoing = false;
        }
          
        private void ProcessarPastas()
        {
            foreach (string item in pastasSelecionadas)
            {
                if (keepGoing)
                {
                    var folder = pastasEmailSelecionado.Where(x => x.Name == item).FirstOrDefault();
                    
                    this.InvokeEx(f => f.progressBar1.Maximum = folder.Items.Count);
                    this.InvokeEx(f => f.progressBar1.Value = (int)NumeroComeco.Value);
                    this.InvokeEx(f => f.LabelTotal.Text = (folder.Items.Count).ToString());
                    this.InvokeEx(f => f.LabelProgresso.Text = "Progresso em " + item);
                    cont = (int)NumeroComeco.Value;
                    for (int i = folder.Items.Count - (int)NumeroComeco.Value; i > 0; i--) // para pessoas usarem no email atual
                    //for (int i = 1; i < folder.Items.Count; i++) // para arquivos mortos
                    {
                        if (keepGoing)
                        {
                            cont++;
                            this.InvokeEx(f => f.LabelProcessados.Text = cont.ToString());
                            try
                            {
                                if (folder.Items[i] is Outlook.MailItem mailItem)
                                {
                                    if (mailItemProcessor.ProcessMailItem(mailItem))
                                    {
                                        contApagados++;
                                       // i--;
                                        this.InvokeEx(f => f.LabelApagados.Text = contApagados.ToString());
                                    }
                                    this.InvokeEx(f => f.progressBar1.PerformStep());
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        else
                            break;
                    }

                    this.InvokeEx(f => f.progressBar1.Value = progressBar1.Maximum);
                }
                else
                    break;
            }
            this.InvokeEx(f => f.ButtonProcessar.Enabled = true);
            keepGoing = true;
        }
    }

    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }
}
