namespace GESTION_CAISSE.IHM
{
    partial class Form_Ticket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Ticket));
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.lb_rendu = new System.Windows.Forms.Label();
            this.lb_reglement = new System.Windows.Forms.Label();
            this.lb_total = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.prixTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.designation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_contenu = new System.Windows.Forms.ListView();
            this.lb_num_ticket = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_nom_client = new System.Windows.Forms.Label();
            this.lb_nom_caissier = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_ville_agence = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_tel_societe = new System.Windows.Forms.Label();
            this.lb_name_agence = new System.Windows.Forms.Label();
            this.print = new System.Drawing.Printing.PrintDocument();
            this.lb_name_societe = new System.Windows.Forms.Label();
            this.context_form = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool_fermer = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.context_form.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ContextMenuStrip = this.context_form;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lb_rendu);
            this.panel1.Controls.Add(this.lb_reglement);
            this.panel1.Controls.Add(this.lb_total);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lv_contenu);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lb_nom_client);
            this.panel1.Controls.Add(this.lb_nom_caissier);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lb_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lb_ville_agence);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lb_tel_societe);
            this.panel1.Controls.Add(this.lb_name_agence);
            this.panel1.Controls.Add(this.lb_name_societe);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 313);
            this.panel1.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 295);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(253, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "Les marchandises vendues ne sont ni reprises, ni échangées";
            // 
            // lb_rendu
            // 
            this.lb_rendu.AutoSize = true;
            this.lb_rendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rendu.Location = new System.Drawing.Point(201, 271);
            this.lb_rendu.Name = "lb_rendu";
            this.lb_rendu.Size = new System.Drawing.Size(74, 12);
            this.lb_rendu.TabIndex = 34;
            this.lb_rendu.Text = "1 000 000 000";
            this.lb_rendu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_reglement
            // 
            this.lb_reglement.AutoSize = true;
            this.lb_reglement.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_reglement.Location = new System.Drawing.Point(201, 258);
            this.lb_reglement.Name = "lb_reglement";
            this.lb_reglement.Size = new System.Drawing.Size(74, 12);
            this.lb_reglement.TabIndex = 33;
            this.lb_reglement.Text = "1 000 000 000";
            this.lb_reglement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total.Location = new System.Drawing.Point(201, 244);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(74, 12);
            this.lb_total.TabIndex = 32;
            this.lb_total.Text = "1 000 000 000";
            this.lb_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "Rendu : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Reglement : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "Total : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(260, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" +
    " - - - - - - - - - - ";
            // 
            // prixTotal
            // 
            this.prixTotal.Text = "Prix.Total";
            this.prixTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.prixTotal.Width = 70;
            // 
            // prix
            // 
            this.prix.Text = "Prix.U";
            this.prix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.prix.Width = 55;
            // 
            // designation
            // 
            this.designation.Text = "Désignation";
            this.designation.Width = 96;
            // 
            // qte
            // 
            this.qte.Text = "Qte";
            this.qte.Width = 35;
            // 
            // lv_contenu
            // 
            this.lv_contenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.qte,
            this.designation,
            this.prix,
            this.prixTotal});
            this.lv_contenu.FullRowSelect = true;
            this.lv_contenu.GridLines = true;
            this.lv_contenu.Location = new System.Drawing.Point(12, 144);
            this.lv_contenu.Name = "lv_contenu";
            this.lv_contenu.Size = new System.Drawing.Size(260, 97);
            this.lv_contenu.TabIndex = 28;
            this.lv_contenu.UseCompatibleStateImageBehavior = false;
            this.lv_contenu.View = System.Windows.Forms.View.Details;
            // 
            // lb_num_ticket
            // 
            this.lb_num_ticket.AutoSize = true;
            this.lb_num_ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_num_ticket.Location = new System.Drawing.Point(50, 5);
            this.lb_num_ticket.Name = "lb_num_ticket";
            this.lb_num_ticket.Size = new System.Drawing.Size(88, 12);
            this.lb_num_ticket.TabIndex = 1;
            this.lb_num_ticket.Text = "FA/031115/0002";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" +
    " - - - - - - - - - - ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ticket N° : ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_num_ticket);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(67, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 25);
            this.panel2.TabIndex = 27;
            // 
            // lb_nom_client
            // 
            this.lb_nom_client.AutoSize = true;
            this.lb_nom_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_client.Location = new System.Drawing.Point(149, 113);
            this.lb_nom_client.Name = "lb_nom_client";
            this.lb_nom_client.Size = new System.Drawing.Size(114, 12);
            this.lb_nom_client.TabIndex = 25;
            this.lb_nom_client.Text = "Zibi Mbazoa Francois";
            // 
            // lb_nom_caissier
            // 
            this.lb_nom_caissier.AutoSize = true;
            this.lb_nom_caissier.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_caissier.Location = new System.Drawing.Point(12, 113);
            this.lb_nom_caissier.Name = "lb_nom_caissier";
            this.lb_nom_caissier.Size = new System.Drawing.Size(77, 12);
            this.lb_nom_caissier.TabIndex = 26;
            this.lb_nom_caissier.Text = "Dowes Mbella";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "Client : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "Caissier : ";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Location = new System.Drawing.Point(184, 76);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(89, 12);
            this.lb_date.TabIndex = 22;
            this.lb_date.Text = "03/11/2015 20:15:48";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "-----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ville : ";
            // 
            // lb_ville_agence
            // 
            this.lb_ville_agence.AutoSize = true;
            this.lb_ville_agence.Location = new System.Drawing.Point(193, 23);
            this.lb_ville_agence.Name = "lb_ville_agence";
            this.lb_ville_agence.Size = new System.Drawing.Size(52, 12);
            this.lb_ville_agence.TabIndex = 15;
            this.lb_ville_agence.Text = "Bafoussam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Phone : ";
            // 
            // lb_tel_societe
            // 
            this.lb_tel_societe.AutoSize = true;
            this.lb_tel_societe.Location = new System.Drawing.Point(193, 6);
            this.lb_tel_societe.Name = "lb_tel_societe";
            this.lb_tel_societe.Size = new System.Drawing.Size(82, 12);
            this.lb_tel_societe.TabIndex = 13;
            this.lb_tel_societe.Text = "(+237) 694 234 044";
            // 
            // lb_name_agence
            // 
            this.lb_name_agence.AutoSize = true;
            this.lb_name_agence.Location = new System.Drawing.Point(12, 23);
            this.lb_name_agence.Name = "lb_name_agence";
            this.lb_name_agence.Size = new System.Drawing.Size(31, 12);
            this.lb_name_agence.TabIndex = 17;
            this.lb_name_agence.Text = "Balem";
            // 
            // lb_name_societe
            // 
            this.lb_name_societe.AutoSize = true;
            this.lb_name_societe.Location = new System.Drawing.Point(12, 6);
            this.lb_name_societe.Name = "lb_name_societe";
            this.lb_name_societe.Size = new System.Drawing.Size(105, 12);
            this.lb_name_societe.TabIndex = 12;
            this.lb_name_societe.Text = "Boulangerie La Paix Plus";
            // 
            // context_form
            // 
            this.context_form.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_fermer});
            this.context_form.Name = "context_form";
            this.context_form.Size = new System.Drawing.Size(153, 48);
            // 
            // tool_fermer
            // 
            this.tool_fermer.Image = global::GESTION_CAISSE.Properties.Resources.agt_stop;
            this.tool_fermer.Name = "tool_fermer";
            this.tool_fermer.Size = new System.Drawing.Size(152, 22);
            this.tool_fermer.Text = "Fermer";
            this.tool_fermer.Click += new System.EventHandler(this.tool_fermer_Click);
            // 
            // Form_Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(287, 316);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "From_Ticket";
            this.Load += new System.EventHandler(this.Form_Ticket_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.context_form.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lb_rendu;
        private System.Windows.Forms.Label lb_reglement;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView lv_contenu;
        private System.Windows.Forms.ColumnHeader qte;
        private System.Windows.Forms.ColumnHeader designation;
        private System.Windows.Forms.ColumnHeader prix;
        private System.Windows.Forms.ColumnHeader prixTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_num_ticket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_nom_client;
        private System.Windows.Forms.Label lb_nom_caissier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_ville_agence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_tel_societe;
        private System.Windows.Forms.Label lb_name_agence;
        private System.Windows.Forms.Label lb_name_societe;
        private System.Windows.Forms.Timer timer;
        private System.Drawing.Printing.PrintDocument print;
        private System.Windows.Forms.ContextMenuStrip context_form;
        private System.Windows.Forms.ToolStripMenuItem tool_fermer;

    }
}