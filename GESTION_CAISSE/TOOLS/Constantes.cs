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



        public const String NAME_ADMIN = "A";

        public const int MAX_ERROR_CONNECT = 2;
        public const int MAX_TIME_CONNECT = 30;

        public const string FILE_SEPARATOR = "\\";

        public const string APP_NAME = "Gestion Caisse";

        public const String MOUV_ENTREE = "E";

        public const String TABLE_EXTERNE_PIECE = "yvs_com_mensualite_facture_vente";

        public const String ETAT_EN_ATTENTE = "En Attente";
        public const String ETAT_EN_COURS = "En Cours";
        public const String ETAT_REGLE = "Réglé";
        public const String ETAT_VALIDE = "Accordé";

        public const String TYPE_FV = "FV";
        public const String TYPE_BCV = "BCV";

        public const String DOC_FACTURE = "Facture Vente";
        public const String DOC_COMMANDE = "Bon Commande Vente";
        public const String DOC_PIECE = "Piece Tresorerie";        

        //Base
        public const String BASE_CA = "CA";
        public const String BASE_QTE = "Qte";

        //Nature Montant
        public const String NATURE_TAUX = "Taux";
        public const String NATURE_MTANT = "Montant";
    }
}
