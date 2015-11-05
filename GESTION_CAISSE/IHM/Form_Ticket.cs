using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.BLL;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Ticket : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private Bitmap memoryImage;
        int compteur = 0;

        Form F_parent;
        Facture facture;


        public Form_Ticket()
        {
            InitializeComponent();
            configForm();
        }

        public Form_Ticket(Form parent)
        {
            InitializeComponent();
            this.F_parent = parent;
            configForm();
        }

        public Form_Ticket(Facture facture)
        {
            InitializeComponent();
            this.facture = facture;
            configForm();
        }

        private void configForm()
        {
            if ((facture != null) ? facture.Id > 0 : false)
            {
                LoadContenu(facture);
                lb_num_ticket.Text = facture.NumDoc;
                if ((facture.Client != null) ? facture.Client.Id > 0 : false)
                {
                    lb_nom_client.Text = facture.Client.Nom_prenom;
                }
                lb_total.Text = facture.MontantTTC.ToString();
                lb_reglement.Text = facture.MontantAvance.ToString();
                lb_rendu.Text = facture.MontantReste.ToString();
            }
            lb_date.Text = DateTime.Now.ToString();
            lb_nom_caissier.Text = Constantes.Users.NomUser;
            lb_name_societe.Text = Constantes.Societe.Designation;
            lb_name_agence.Text = Constantes.Agence.Designation;
            if ((Constantes.Agence.Ville != null) ? Constantes.Agence.Ville.Id > 0 : false)
                lb_ville_agence.Text = Constantes.Agence.Ville.Libelle;
            lb_tel_societe.Text = Constantes.Societe.Telephone;
        }

        private void lb_name_societe_TextChanged(object sender, EventArgs e)
        {
            lb_name_societe.Text = lb_name_societe.Text.ToUpper();
        }

        private void Form_Ticket_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void LoadContenu(Facture facture)
        {
            lv_contenu.Items.Clear();
            if ((facture != null) ? facture.Id > 0 : false)
            {
                string[] arr = new string[4];
                ListViewItem itm;
                foreach (Contenu c in facture.Contenus)
                {
                    arr[0] = c.Quantite.ToString();
                    arr[1] = c.Article.Designation;
                    arr[2] = c.Prix.ToString();
                    arr[3] = c.PrixTotal.ToString();
                    itm = new ListViewItem(arr);
                    lv_contenu.Items.Add(itm);
                }
            }
        }

        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void Imprimer()
        {
            CaptureScreen();
            print.Print();
            this.Dispose();
        }

        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (compteur == 2)
            {
                timer.Stop();
                Imprimer();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                compteur++;
            }
        }

        private void tool_fermer_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Dispose();
        }
    }
}
