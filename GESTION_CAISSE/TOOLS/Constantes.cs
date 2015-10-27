using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.IHM;

namespace GESTION_CAISSE.TOOLS
{
    class Constantes
    {
        public static Users Users;
        public static Societe Societe = new Societe(2288);
        public static Agence Agence = new Agence(2299);
        public static Creneau Creneau = new Creneau();

        public static Form_Caisse_Click form_caisse_click = null;
        public static Form_Caisse_Saisie form_caisse_saisie = null;

        public static Configuration Configuration = null;

        public static bool askQuestion;

        public static String NAME_ADMIN = "A";

        public static int MAX_ERROR_CONNECT = 2;
        public static int MAX_TIME_CONNECT = 30;

        public static string FILE_SEPARATOR = "\\";

        public static string APP_NAME = "Gestion Caisse";

        public static String MOUV_ENTREE = "E";

        public static String TABLE_EXTERNE_PIECE = "yvs_com_mensualite_facture_vente";

        public static String ETAT_EN_ATTENTE = "En Attente";
        public static String ETAT_EN_COURS = "En Cours";
        public static String ETAT_REGLE = "Réglé";
    }
}
