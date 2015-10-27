using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Serveur : Form
    {
        public Form_Serveur()
        {
            InitializeComponent();
        }

        private ENTITE.Serveur RecopiewView()
        {
            ENTITE.Serveur bean = new ENTITE.Serveur();
            bean.getAdresse = txt_adress.Text.Trim();
            bean.getDatabase = txt_db.Text.Trim();
            bean.getPassword = txt_pwd.Text.Trim();
            bean.getUser = txt_user.Text.Trim();
            bean.getPort = Convert.ToInt16((!txt_port.Text.Trim().Equals("")) ? txt_port.Text.Trim() : "5432");
            return bean;
        }

        private void Form_Serveur_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ENTITE.Serveur bean = RecopiewView();
            if (bean.Control())
            {
                if (new BLL.ServeurBll(bean).CreateServeur())
                {
                    Application.Restart();
                }
            }
        }
    }
}
