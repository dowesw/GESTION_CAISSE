using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GESTION_CAISSE.ENTITE
{
    [Serializable]
    public class Configuration
    {
        private string NomTemplate;
        public string getNomTemplate
        {
            get { return NomTemplate; }
            set { NomTemplate = value; }
        }

        private string CouleurForm;
        public string getCouleurForm
        {
            get { return CouleurForm; }
            set { CouleurForm = value; }
        }

        private string CouleurTextbox;
        public string getCouleurTextbox
        {
            get { return CouleurTextbox; }
            set { CouleurTextbox = value; }
        }

        private string CouleurLabel;
        public string getCouleurLabel
        {
            get { return CouleurLabel; }
            set { CouleurLabel = value; }
        }

        private string CouleurEcritText;
        public string getCouleurEcritText
        {
            get { return CouleurEcritText; }
            set { CouleurEcritText = value; }
        }

        private string PoliceLabel;
        public string getPoliceLabel
        {
            get { return PoliceLabel; }
            set { PoliceLabel = value; }
        }

        private float TaillePoliceLabel;
        public float getTaillePoliceLabel
        {
            get { return TaillePoliceLabel; }
            set { TaillePoliceLabel = value; }
        }

        private string PoliceEcritText;
        public string getPoliceEcritText
        {
            get { return PoliceEcritText; }
            set { PoliceEcritText = value; }
        }

        private float TaillePoliceEcritText;
        public float getTaillePoliceEcritText
        {
            get { return TaillePoliceEcritText; }
            set { TaillePoliceEcritText = value; }
        }

        private string Langue;
        public string getLangue
        {
            get { return Langue; }
            set { Langue = value; }
        }

        private bool Install;
        public bool getInstall
        {
            get { return Install; }
            set { Install = value; }
        }

        private bool update;
        public bool Update
        {
            get { return update; }
            set { update = value; }
        }
    }
}
