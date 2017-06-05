namespace Jarvis
{
    partial class frmJarvis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJarvis));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LblVoce = new System.Windows.Forms.Label();
            this.LblJarvis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(294, 273);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(108, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // LblVoce
            // 
            this.LblVoce.AutoSize = true;
            this.LblVoce.BackColor = System.Drawing.Color.Transparent;
            this.LblVoce.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVoce.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LblVoce.Location = new System.Drawing.Point(12, 18);
            this.LblVoce.Name = "LblVoce";
            this.LblVoce.Size = new System.Drawing.Size(98, 19);
            this.LblVoce.TabIndex = 1;
            this.LblVoce.Text = "Reconhecido";
            // 
            // LblJarvis
            // 
            this.LblJarvis.AutoSize = true;
            this.LblJarvis.BackColor = System.Drawing.Color.Transparent;
            this.LblJarvis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJarvis.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LblJarvis.Location = new System.Drawing.Point(12, 47);
            this.LblJarvis.Name = "LblJarvis";
            this.LblJarvis.Size = new System.Drawing.Size(60, 19);
            this.LblJarvis.TabIndex = 2;
            this.LblJarvis.Text = "Jarvis: ";
            // 
            // frmJarvis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 308);
            this.Controls.Add(this.LblJarvis);
            this.Controls.Add(this.LblVoce);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.Name = "frmJarvis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jarvis v.1.0 - Lailson Conceição";
            this.Load += new System.EventHandler(this.frmJarvis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LblVoce;
        private System.Windows.Forms.Label LblJarvis;
    }
}

