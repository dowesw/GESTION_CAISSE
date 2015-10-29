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
            Initialisation();
            Application.Run(new IHM.Form_Caisse_Click());
        }

        static void StartAppl()
        {
            if (BLL.ServeurBll.ReturnServeur().Control())
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
          var t =  TOOLS.Utils.GenererReference(TOOLS.Constantes.DOC_COMMANDE);
        }
        
        static void Initialisation()
        {
            TOOLS.Constantes.Societe = BLL.SocieteBll.One(2288);
            TOOLS.Constantes.Agence = BLL.AgenceBll.One(2299);
            TOOLS.Constantes.Users = BLL.UsersBll.One(2692);
            TOOLS.Constantes.Creneau = BLL.CreneauBll.One(15);
        }
    }
}
