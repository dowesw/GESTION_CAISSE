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

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Caisse_Click : Form
    {

        List<FamilleArticle> familles;
        public Form_Caisse_Click()
        {
            InitializeComponent();
            familles = new List<FamilleArticle>();
        }

        private void Form_Caisse_Click_Load(object sender, EventArgs e)
        {
            LoadAllFamille();
        }

        private void LoadAllFamille()
        {
            familles.Clear();
            familles = BLL.FamilleArticleBll.Liste("select * from yvs_base_famille_article");
        }
    }
}
