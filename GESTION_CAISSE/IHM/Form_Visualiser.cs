using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using GESTION_CAISSE.TOOLS;
using GESTION_CAISSE.ENTITE;

namespace GESTION_CAISSE.IHM
{
    public partial class Form_Visualiser : Form
    {
        Form F_parent;

        public Form_Visualiser()
        {
            InitializeComponent();
            configForm();
        }

        public Form_Visualiser(Form parent)
        {
            InitializeComponent();
            this.F_parent = parent;
            configForm();
        }

        private void configForm()
        {
            this.Text = Constantes.APP_NAME + " : Visionneuse";
            LoadConfigTicket();
        }

        private void Form_Visualiser_Load(object sender, EventArgs e)
        {
            this.report_etat.RefreshReport();
        }

        private void LoadConfigTicket()
        {
            ETAT.Etat_Ticket ticket = new ETAT.Etat_Ticket();

            ticket.SetParameterValue("id", 0);
            this.report_etat.ReportSource = ticket;
            SetDateRangeForOrders(ticket, "Lymytz Sarl", "Lymytz Sarl", "nom_societe");
            //ticket.SetParameterValue("nom_societe", "Lymytz Sarl");
            //ticket.SetParameterValue("nom_agence", "Bessengue");
            //ticket.SetParameterValue("tel_societe", "694 23 40 44");
            //ticket.SetParameterValue("ville_agence", "Douala");
            //ticket.SetParameterValue("nom_caissier", "Dowes Mbella");
            //ticket.SetParameterValue("nom_client", "Zibi Mbazoa");
            //ticket.SetParameterValue("num_ticket", "FA/03/11/15/0000");
            //ticket.SetParameterValue("total_facture", 10000000);
            //ticket.SetParameterValue("total_versee", 15000000);

        }

        private void SetDateRangeForOrders(ReportDocument report, string startData, string endData, string name_parametre)
        {
            ParameterRangeValue param_ = new ParameterRangeValue();
            param_.StartValue = startData;
            param_.EndValue = endData;
            param_.LowerBoundType = RangeBoundType.BoundInclusive;
            param_.UpperBoundType = RangeBoundType.BoundInclusive;
            ParameterFieldDefinitions def_ = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition paramDef_ = def_[name_parametre];
            paramDef_.IsOptionalPrompt = false;
            paramDef_.CurrentValues.Clear();
            paramDef_.CurrentValues.Add(param_);
            paramDef_.ApplyCurrentValues(paramDef_.CurrentValues);
        }
    }
}
