using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace RemoveEmailsDuplicadoBasico
{
    public partial class RED_Basico : Form
    {
        static Outlook.Application outlook = new Outlook.Application();
        MailItemProcessorBasico mailItemProcessor = new MailItemProcessorBasico();
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
        bool Continuar = true;
        int cont = 1;

        public RED_Basico()
        {
            InitializeComponent();
        }

        private void RED_Basico_Load(object sender, EventArgs e)
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

                        VerificaSubpastas(f);
                    }
                }
            }
        }

        private void VerificaSubpastas(Outlook.Folder folder)
        {
            Outlook.Folders subPastas = folder.Folders;
            if (subPastas.Count > 0)
            {
                foreach (Outlook.Folder subPasta in subPastas)
                {
                    CheckedListBoxPastas.Items.Add(subPasta.Name);
                    pastasEmailSelecionado.Add(subPasta);
                    VerificaSubpastas(subPasta);
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

            SetupParaComecar();

            thread = new Thread(ProcessarPastas);
            thread.Start();
        }

        private void SetupParaComecar()
        {
            ButtonProcessar.Enabled = false;
            contApagados = 0;
            cont = 1;
            mailItemProcessor.CleanKeys();
            LabelApagados.Text = contApagados.ToString();
        }

        private void ButtonParar_Click(object sender, EventArgs e)
        {
            Continuar = false;
        }

        private void ProcessarPastas()
        {
            int TotalEmails = 0;
            foreach (string nomePasta in pastasSelecionadas)
            {
                if (Continuar)
                {
                    var folder = pastasEmailSelecionado.Where(x => x.Name == nomePasta).FirstOrDefault();

                    TotalEmails += folder.Items.Count;

                    SetupCadaPasta(TotalEmails, nomePasta, folder.Items.Count);

                    for (int i = folder.Items.Count; i > 0; i--) // começa do mais recente
                    {
                        if (Continuar)
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
                                        this.InvokeEx(f => f.LabelApagados.Text = contApagados.ToString());
                                    }
                                    this.InvokeEx(f => f.progressBar1.PerformStep());
                                }
                            }
                            catch (Exception)
                            {
                               // Just ignore the errors
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
            Continuar = true;
        }

        private void SetupCadaPasta(int TotalEmails, string item, int NumItensNaPasta)
        {
            this.InvokeEx(f => f.progressBar1.Value = 0);
            this.InvokeEx(f => f.progressBar1.Maximum = NumItensNaPasta);
            this.InvokeEx(f => f.LabelTotal.Text = TotalEmails.ToString());
            this.InvokeEx(f => f.LabelProgresso.Text = "Progresso em " + item);
        }

        private void ckbTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckedListBoxPastas.Items.Count; i++)
            {
                CheckedListBoxPastas.SetItemChecked(i, ckbTodos.Checked);
            }
        }

        private void RED_Basico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Continuar = false;
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
