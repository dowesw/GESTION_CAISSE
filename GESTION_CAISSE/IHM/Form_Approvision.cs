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
    public partial class Form_Approvision : Form
    {
        Form F_parent;

        public Form_Approvision()
        {
            InitializeComponent();
            configForm();
        }

        public Form_Approvision(Form parent)
        {
            InitializeComponent();
            this.F_parent = parent;
            configForm();
        }

        private void configForm()
        {
            this.Text = Constantes.APP_NAME + " : Historique Approvisionnement";
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "mouv";
            iconColumn.HeaderText = "";
            dgv_approvision.Columns.Insert(3, iconColumn);
        }

        private void LoadAllHistorique()
        {
            if ((Constantes.Creneau != null) ? Constantes.Creneau.Depot != null : false)
            {
                foreach (MouvementStock m in Constantes.Creneau.Depot.Mouvements)
                {
                    AddRowApprovision(m);
                }
            }
        }

        private void AddRowApprovision(MouvementStock m)
        {
            dgv_approvision.Rows.Add(new object[] { m.Id, m.Article.Designation, m.Quantite, m.Image });
        }

        private void Form_Approvision_Load(object sender, EventArgs e)
        {
            LoadAllHistorique();
        }
    }
}
