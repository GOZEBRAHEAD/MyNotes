namespace MyList
{
    partial class FormDashboard
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
            this.panelDASHBOARD = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNOTES_TOTALCREATED = new System.Windows.Forms.Label();
            this.labelNOTES_FAVORITES = new System.Windows.Forms.Label();
            this.labelNOTES_DELETED = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNOTES_USERSCREATED = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelDASHBOARD.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDASHBOARD
            // 
            this.panelDASHBOARD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDASHBOARD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.panelDASHBOARD.Controls.Add(this.labelNOTES_USERSCREATED);
            this.panelDASHBOARD.Controls.Add(this.label6);
            this.panelDASHBOARD.Controls.Add(this.labelNOTES_DELETED);
            this.panelDASHBOARD.Controls.Add(this.label5);
            this.panelDASHBOARD.Controls.Add(this.labelNOTES_FAVORITES);
            this.panelDASHBOARD.Controls.Add(this.labelNOTES_TOTALCREATED);
            this.panelDASHBOARD.Controls.Add(this.label4);
            this.panelDASHBOARD.Controls.Add(this.label2);
            this.panelDASHBOARD.Controls.Add(this.label1);
            this.panelDASHBOARD.Location = new System.Drawing.Point(12, 12);
            this.panelDASHBOARD.Name = "panelDASHBOARD";
            this.panelDASHBOARD.Size = new System.Drawing.Size(776, 531);
            this.panelDASHBOARD.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(308, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 33);
            this.label1.TabIndex = 32;
            this.label1.Text = "Dashboard";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(93, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 22);
            this.label2.TabIndex = 33;
            this.label2.Text = "Total notes created:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(96, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Total favorite notes:";
            // 
            // labelNOTES_TOTALCREATED
            // 
            this.labelNOTES_TOTALCREATED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelNOTES_TOTALCREATED.AutoSize = true;
            this.labelNOTES_TOTALCREATED.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelNOTES_TOTALCREATED.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelNOTES_TOTALCREATED.Location = new System.Drawing.Point(301, 195);
            this.labelNOTES_TOTALCREATED.Name = "labelNOTES_TOTALCREATED";
            this.labelNOTES_TOTALCREATED.Size = new System.Drawing.Size(15, 22);
            this.labelNOTES_TOTALCREATED.TabIndex = 35;
            this.labelNOTES_TOTALCREATED.Text = ".";
            // 
            // labelNOTES_FAVORITES
            // 
            this.labelNOTES_FAVORITES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelNOTES_FAVORITES.AutoSize = true;
            this.labelNOTES_FAVORITES.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelNOTES_FAVORITES.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelNOTES_FAVORITES.Location = new System.Drawing.Point(301, 297);
            this.labelNOTES_FAVORITES.Name = "labelNOTES_FAVORITES";
            this.labelNOTES_FAVORITES.Size = new System.Drawing.Size(15, 22);
            this.labelNOTES_FAVORITES.TabIndex = 36;
            this.labelNOTES_FAVORITES.Text = ".";
            // 
            // labelNOTES_DELETED
            // 
            this.labelNOTES_DELETED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelNOTES_DELETED.AutoSize = true;
            this.labelNOTES_DELETED.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelNOTES_DELETED.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelNOTES_DELETED.Location = new System.Drawing.Point(658, 195);
            this.labelNOTES_DELETED.Name = "labelNOTES_DELETED";
            this.labelNOTES_DELETED.Size = new System.Drawing.Size(15, 22);
            this.labelNOTES_DELETED.TabIndex = 38;
            this.labelNOTES_DELETED.Text = ".";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label5.Location = new System.Drawing.Point(453, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 22);
            this.label5.TabIndex = 37;
            this.label5.Text = "Total deleted notes:";
            // 
            // labelNOTES_USERSCREATED
            // 
            this.labelNOTES_USERSCREATED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelNOTES_USERSCREATED.AutoSize = true;
            this.labelNOTES_USERSCREATED.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.labelNOTES_USERSCREATED.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelNOTES_USERSCREATED.Location = new System.Drawing.Point(658, 297);
            this.labelNOTES_USERSCREATED.Name = "labelNOTES_USERSCREATED";
            this.labelNOTES_USERSCREATED.Size = new System.Drawing.Size(15, 22);
            this.labelNOTES_USERSCREATED.TabIndex = 40;
            this.labelNOTES_USERSCREATED.Text = ".";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label6.Location = new System.Drawing.Point(456, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 22);
            this.label6.TabIndex = 39;
            this.label6.Text = "Total users created:";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.panelDASHBOARD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panelDASHBOARD.ResumeLayout(false);
            this.panelDASHBOARD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDASHBOARD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNOTES_TOTALCREATED;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNOTES_FAVORITES;
        private System.Windows.Forms.Label labelNOTES_DELETED;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNOTES_USERSCREATED;
        private System.Windows.Forms.Label label6;
    }
}