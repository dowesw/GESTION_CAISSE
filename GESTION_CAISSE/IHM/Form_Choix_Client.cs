using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Choix_Client : Form
    {
        public Form_Choix_Client()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form_Choix_Client_Load(object sender, EventArgs e)
        {
            BLL.ConfigurationBLL.getConfigurerForm(this);
        }
    }
}
