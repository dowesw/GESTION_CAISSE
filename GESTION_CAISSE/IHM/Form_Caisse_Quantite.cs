using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Caisse_Quantite : Form
    {
        Form fParent;
        List<Button> claviers;
        public Form_Caisse_Quantite(Form parent)
        {
            this.Text = TOOLS.Constantes.APP_NAME + " : Entrer La Quantité";

            InitializeComponent();
            fParent = parent;
            claviers = new List<Button> { button1, button2, button3, button4, button5, button6, button7
                , button8, button9, button10 };
            populateEventNumCla();
        }

        private void populateEventNumCla()
        {
            foreach (Button btn in claviers)
            {
                btn.Click += delegate(object senderc, EventArgs ec)
                {
                    if (textBox1.Text.Equals("") && btn.Text.Equals("0"))
                    {
                        
                    }
                    else { this.textBox1.Text += btn.Text; }
                };
            }
        }

        private void EFFACER(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void VALIDER(object sender, EventArgs e)
        {
            Form_Caisse_Click f = (Form_Caisse_Click)fParent;
            if (!textBox1.Text.Equals(""))
                f.contenu.Quantite = Convert.ToDouble(textBox1.Text);
            else
                f.contenu.Quantite = 0;
            this.Close();
        }

        private void FFACERall(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Form_Caisse_Quantite_Load(object sender, EventArgs e)
        {

        }

    }
}
