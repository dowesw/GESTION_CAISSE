using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GESTION_CAISSE
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Initialisation();
            //Application.Run(new IHM.Form_Caisse_Saisie());
            StartAppl();
        }

        static void StartAppl()
        {
            if (TOOLS.Connexion.Connection_Test())
            {
                Application.Run(new IHM.Form_Login());
            }
            else
            {
                new IHM.Form_Serveur().ShowDialog();
            }
        }

        static void test()
        {
            Form f = new Form();
            Button b = new Button();
            b.Size = new System.Drawing.Size(100, 50);
            System.Drawing.Bitmap i = global::GESTION_CAISSE.Properties.Resources.article;
            b.Image = new System.Drawing.Bitmap(i,new System.Drawing.Size(16,16));
            f.Controls.Add(b);
            f.ShowDialog();
        }

        static void Initialisation()
        {
            TOOLS.Constantes.Societe = BLL.SocieteBll.One(2288);
            TOOLS.Constantes.Agence = BLL.AgenceBll.One(2299);
            TOOLS.Constantes.Users = BLL.UsersBll.One(2692);
            TOOLS.Constantes.Creneau = BLL.CreneauBll.One(15);
            TOOLS.Utils.SetEnteteOfDay(Convert.ToDateTime("2015-10-10"));
        }
    }
}
