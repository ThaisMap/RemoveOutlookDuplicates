using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        bool Continuar = true;
        int cont = 1;
        List<string> Blacklist = new List<string>();
        string BlacklistFileName = "Blacklist.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var folders = outlookNamespace.Folders;

            foreach (Outlook.Folder f in folders)
            {
                ListBoxCaixas.Items.Add(f.Name);
            }

            try
            {
                Blacklist.AddRange(File.ReadAllLines(BlacklistFileName));
                mailItemProcessor.AddToBlacklist(Blacklist);
            }
            catch { }
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
            cont = (int)NumeroComeco.Value;
            mailItemProcessor.CleanKeys();
            LabelApagados.Text = contApagados.ToString();
            if(emailRemoverTxt.Text != "@expressorodominas.com.br")
                mailItemProcessor.AddToBlacklist(emailRemoverTxt.Text);
        }

        private void ButtonParar_Click(object sender, EventArgs e)
        {
            Continuar = false;
        }
          
        private void ProcessarPastas()
        {
            double porcentagemApagada = 0.0;
            foreach (string nomePasta in pastasSelecionadas)
            {
                    int TotalEmails = 0;
                if (Continuar)
                {
                    var folder = pastasEmailSelecionado.Where(x => x.Name == nomePasta).FirstOrDefault();

                    TotalEmails += folder.Items.Count;

                    SetupCadaPasta(TotalEmails, nomePasta);
                    
                    for (int i = folder.Items.Count - (int)NumeroComeco.Value; i > 0; i--) // começa do mais recente
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
                                    }
                                    porcentagemApagada = ((double)contApagados / cont) *100;

                                    this.InvokeEx(f => f.LabelApagados.Text = contApagados.ToString()+" ("+ Math.Round(porcentagemApagada, 2)  + "%)");
                                    this.InvokeEx(f => f.progressBar1.PerformStep());
                                }
                            }
                            catch (Exception)
                            {
                                //if(Continuar)
                                //    MessageBox.Show(e.Message);
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

        private void SetupCadaPasta(int TotalEmails, string item)
        {
            this.InvokeEx(f => f.progressBar1.Maximum = TotalEmails);
            this.InvokeEx(f => f.progressBar1.Value = (int)NumeroComeco.Value);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {            
                Continuar = false;
        }

        private void ButtonBlacklist_Click(object sender, EventArgs e)
        {
            if (DialogListaNegra.ShowDialog() == DialogResult.OK)
            {
                string[] linhasLidas = File.ReadAllLines(DialogListaNegra.FileName);
                Blacklist.AddRange(linhasLidas);
                File.AppendAllLines(BlacklistFileName, linhasLidas);
            }
            mailItemProcessor.AddToBlacklist(Blacklist);
        }

        private void BtnResetBlacklist_Click(object sender, EventArgs e)
        {
            mailItemProcessor.ResetBlacklist();
            File.WriteAllText(BlacklistFileName, "");
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
