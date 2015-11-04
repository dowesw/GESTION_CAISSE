using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Caisse_Mensualite : Form
    {
        Form F_parent;
        List<ModePaiement> modes;
        Mensualite mensualite = new Mensualite();
        PieceCaisse reglement = new PieceCaisse();

        public Form_Caisse_Mensualite()
        {
            InitializeComponent();
            modes = new List<ModePaiement>();
            configForm();
        }

        public Form_Caisse_Mensualite(Form parent)
        {
            InitializeComponent();
            modes = new List<ModePaiement>();
            this.F_parent = parent;
            configForm();
        }

        private void configForm()
        {
            this.Text = Constantes.APP_NAME + " : Mensualités";
            LoadAll();
            ResetFicheReglement();
        }

        private void configReglement(PieceCaisse p)
        {
            if ((p != null) ? p.Id > 0 : false)
            {
                txt_numPiece.Text = p.NumPiece;
                txt_montant.Value = (Decimal)p.Montant;
                if (p.OnCompte)
                {
                    rbtn_yes.Checked = true;
                }
                else
                {
                    rbtn_no.Checked = true;
                }
            }
        }

        private void LoadAll()
        {
            LoadAllmensualite();
            LoadAllModes();
        }

        private void LoadAllmensualite()
        {
            if (F_parent != null)
            {
                Form_Caisse_Saisie f = (Form_Caisse_Saisie)F_parent;
                FullMensualite(f.facture);
            }
        }

        public void LoadAllModes()
        {
            modes.Clear();
            string query = "select * FROM yvs_mode_paiement";
            modes = BLL.ModePaiementBll.Liste(query);
            com_mode.Items.Clear();
            com_mode.DisplayMember = "TypePaiement";
            com_mode.ValueMember = "Id";
            com_mode.DataSource = new BindingSource(modes, null);

            foreach (ENTITE.ModePaiement a in modes)
            {
                if ((a.TypePaiement != null) ? !a.TypePaiement.Trim().Equals("") : false)
                {
                    com_mode.AutoCompleteCustomSource.Add(a.TypePaiement);
                }
            }
            com_mode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            com_mode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AddRowMensualite(Mensualite m)
        {
            dgv_mensualite.Rows.Add(new object[] { m.Id, m.DateMensualite, m.Montant, m.MontantVerse, m.MontantReste, m.Etat, m.IsOut });
        }

        private void AddRowReglement(PieceCaisse m)
        {
            dgv_reglement.Rows.Add(new object[] { m.Id, m.DatePiece, m.Montant, m.Mode.TypePaiement });
        }

        private void FullMensualite(Facture f)
        {
            if ((f != null) ? f.Id > 0 : false)
            {
                foreach (Mensualite m in f.Mensualites)
                {
                    AddRowMensualite(m);
                }
            }
        }

        private void FullReglement(Mensualite m)
        {
            if ((m != null) ? m.Id > 0 : false)
            {
                foreach (PieceCaisse p in m.Reglements)
                {
                    AddRowReglement(p);
                }
            }
        }

        private void ResetFicheMensualite()
        {
            mensualite = new Mensualite();
            dgv_reglement.Rows.Clear();
            ResetFicheReglement();
        }

        private void ResetFicheReglement()
        {
            txt_montant.Value = 0;
            txt_numPiece.Text = Utils.GenererReference(Constantes.DOC_PIECE);
        }

        private void PopulateViewMensualite(Mensualite m)
        {
            ResetFicheMensualite();
            mensualite = m;
            FullReglement(m);
        }

        private void dgv_mensualite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_mensualite.CurrentRow.Cells[0].Value != null)
                {
                    long id = Convert.ToInt64(dgv_mensualite.CurrentRow.Cells[0].Value.ToString());
                    if (id > 0)
                    {
                        Form_Caisse_Saisie f = (Form_Caisse_Saisie)F_parent;
                        Mensualite c = f.facture.Mensualites.Find(x => x.Id == id);
                        PopulateViewMensualite(c);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Exception(ex);
            }
        }

        private void dgv_regelement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_mensualite_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int i = e.RowIndex;
            bool isOut = (Boolean)((dgv_mensualite.Rows[i].Cells[6].Value != null) ? dgv_mensualite.Rows[i].Cells[6].Value : false);
            if (isOut)
            {
                this.dgv_mensualite.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ResetFicheReglement();
        }

        private void btn_genere_Click(object sender, EventArgs e)
        {

        }
    }
}
