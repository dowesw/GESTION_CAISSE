using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Windows.Forms;

namespace GESTION_CAISSE.TOOLS
{
    class Messages
    {
        static public DialogResult Message(String text, String titre, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult reponse = MessageBox.Show(text, titre, buttons, icon);
            return reponse;
        }
        static public DialogResult ChampsVide()
        {
            DialogResult reponse = MessageBox.Show("Les champs doivent contenir une valeur", Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return reponse;
        }

        static public DialogResult ChampsVide(string element)
        {
            DialogResult reponse = MessageBox.Show("Veuillez entrer la valeur de '" + element + "'", Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return reponse;
        }

        static public DialogResult Confirmation_Infos(string action)
        {
            DialogResult reponse = MessageBox.Show("Etes sûr de vouloir " + action + " les informations?", Constantes.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return reponse;
        }

        static public DialogResult Confirmation(string action)
        {
            DialogResult reponse = MessageBox.Show("Etes sûr de vouloir " + action + "?", Constantes.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return reponse;
        }

        static public DialogResult Annulation()
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous annuler l'action?", Constantes.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return reponse;
        }

        static public DialogResult FermerApplication()
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous fermer l'application?", Constantes.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return reponse;
        }

        static public DialogResult Exception(Exception ex)
        {
            DialogResult reponse = MessageBox.Show("L'erreur suivante a été detectée : " + ex.Message, Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return reponse;
        }

        static public DialogResult Exception(NpgsqlException ex)
        {
            DialogResult reponse = MessageBox.Show("L'erreur suivante a été detectée : " + ex.Message, Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return reponse;
        }

        static public DialogResult Inexistant(string element)
        {
            DialogResult reponse = MessageBox.Show(element + " n'existe pas", Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return reponse;
        }

        static public DialogResult Succes()
        {
            DialogResult reponse = MessageBox.Show("succès", Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return reponse;
        }

        static public DialogResult Succes(string element, string action)
        {
            DialogResult reponse = MessageBox.Show(element + " " + action + " avec succès", Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return reponse;
        }

        static public DialogResult Erreur(string message)
        {
            DialogResult reponse = MessageBox.Show(message, Constantes.APP_NAME, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            return reponse;
        }

        static public DialogResult ShowErreur(string message)
        {
            DialogResult reponse = MessageBox.Show(message, Constantes.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return reponse;
        }

        static public DialogResult Show(string message)
        {
            DialogResult reponse = MessageBox.Show(message, Constantes.APP_NAME, MessageBoxButtons.OK);
            return reponse;
        }
    }
}
