using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Caisse_Reglement : Form
    {
        Form fParent;
        public Form_Caisse_Reglement(Form parent)
        {
            InitializeComponent();
            textBox1.Text = "0";
            fParent = parent;

        }

        private void ZeroClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "0";
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void UnClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "1";
            }
            else
            {
                textBox1.Text = "1";
            }
        }

        private void DeuxClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "2";
            }
            else
            {
                textBox1.Text = "2";
            }
        }

        private void TroisClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "3";
            }
            else
            {
                textBox1.Text = "3";
            }
        }

        private void QuatreClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "4";
            }
            else
            {
                textBox1.Text = "4";
            }
        }

        private void CinqClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "5";
            }
            else
            {
                textBox1.Text = "5";
            }
        }

        private void SixClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "6";
            }
            else
            {
                textBox1.Text = "6";
            }
        }

        private void SeptClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "7";
            }
            else
            {
                textBox1.Text = "7";
            }
        }

        private void HuitClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "8";
            }
            else
            {
                textBox1.Text = "8";
            }
        }

        private void NeufClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("0"))
            {
                textBox1.Text += "9";
            }
            else
            {
                textBox1.Text = "9";
            }
        }

        private void VirguleClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.EndsWith(",") && !textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }

        private void EffacerClick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1); 
        }

        private void CalculerClick(object sender, EventArgs e)
        {
            Form_Caisse_Click f = (Form_Caisse_Click)fParent;
            //f.remboursement = f.apayer - Convert.ToDouble(textBox1.Text);
            f.Relicat.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) - Convert.ToDouble(f.SommeP.Text));
            this.Close();
        }

        private void NouveauClick(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void parseTbx()
        {

        }

        private void Form_Caisse_Reglement_Load(object sender, EventArgs e)
        {

        }

    }
}
