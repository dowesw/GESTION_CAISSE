using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class PieceCaisse
    {
        public PieceCaisse()
        {

        }

        public PieceCaisse(long id)
        {
            this.id = id;
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String libelle;
        public String Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        private DateTime datePiece = DateTime.Now;
        public DateTime DatePiece
        {
            get { return datePiece; }
            set { datePiece = value; }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private String mouvement = TOOLS.Constantes.MOUV_ENTREE;
        public String Mouvement
        {
            get { return mouvement; }
            set { mouvement = value; }
        }

        private long idExterne;
        public long IdExterne
        {
            get { return idExterne; }
            set { idExterne = value; }
        }

        private String tableEterne = TOOLS.Constantes.TABLE_EXTERNE_PIECE;
        public String TableEterne
        {
            get { return tableEterne; }
            set { tableEterne = value; }
        }

        private double montant;
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        private ModePaiement mode = new ModePaiement();
        internal ModePaiement Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private String numPiece;
        public String NumPiece
        {
            get { return numPiece; }
            set { numPiece = value; }
        }

        private String numRef;
        public String NumRef
        {
            get { return numRef; }
            set { numRef = value; }
        }

        private String statut = TOOLS.Constantes.ETAT_REGLE;
        public String Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        private bool onCompte;
        public bool OnCompte
        {
            get { return onCompte; }
            set { onCompte = value; }
        }

        private bool update;
        public bool Update
        {
            get { return update; }
            set { update = value; }
        }

        private bool select;
        public bool Select
        {
            get { return select; }
            set { select = value; }
        }

        private bool new_;
        public bool New_
        {
            get { return new_; }
            set { new_ = value; }
        }
    }
}
