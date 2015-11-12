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
        public static Entete Entete = new Entete();

        public static Form_Caisse_Click form_caisse_click = null;
        public static Form_Caisse_Saisie form_caisse_saisie = null;

        public static Configuration Configuration = null;

        public static bool askQuestion;



        public const string NAME_ADMIN = "A";

        public const int MAX_ERROR_CONNECT = 2;
        public const int MAX_TIME_CONNECT = 30;

        public const string FILE_SEPARATOR = "\\";

        public const string APP_NAME = "Gestion Caisse";

        public const string MOUV_ENTREE = "E";
        public const string MOUV_SORTIE = "S";

        public const string TABLE_EXTERNE_PIECE = "yvs_com_mensualite_facture_vente";

        public const string ETAT_EN_ATTENTE = "En Attente";
        public const string ETAT_EN_COURS = "En Cours";
        public const string ETAT_REGLE = "Réglé";
        public const string ETAT_VALIDE = "Accordé";
        public const string ETAT_RETARD = "En Retard";

        public const string TYPE_FV = "FV";
        public const string TYPE_BCV = "BCV";
        public const string TYPE_FV_NAME = "Facture";
        public const string TYPE_BCV_NAME = "Commande";

        public const string DOC_FACTURE = "Facture Vente";
        public const string DOC_COMMANDE = "Bon Commande Vente";
        public const string DOC_PIECE = "Piece Tresorerie";        

        //Base
        public const string BASE_CA = "CA";
        public const string BASE_QTE = "Qte";

        //Nature Montant
        public const string NATURE_TAUX = "Taux";
        public const string NATURE_MTANT = "Montant";

        //Methode de valorisation
        public const string FIFO = "FIFO";
        public const string LIFO = "LIFO";
        public const string CMPI = "CMPI";
        public const string CMPII = "CMPII";

        //Mode Inventaire
        public const string INV_PERMANENT = "P";
        public const string INV_INTERMITENT = "I";

    }
}
