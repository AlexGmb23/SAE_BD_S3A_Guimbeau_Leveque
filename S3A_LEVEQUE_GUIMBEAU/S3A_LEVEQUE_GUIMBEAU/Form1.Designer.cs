namespace S3A_LEVEQUE_GUIMBEAU
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSrcIdRcp = new System.Windows.Forms.Button();
            this.buttonMoy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSrcIdRcp
            // 
            this.buttonSrcIdRcp.Location = new System.Drawing.Point(606, 78);
            this.buttonSrcIdRcp.Name = "buttonSrcIdRcp";
            this.buttonSrcIdRcp.Size = new System.Drawing.Size(129, 48);
            this.buttonSrcIdRcp.TabIndex = 0;
            this.buttonSrcIdRcp.Text = "Requete identifiant/année recompense";
            this.buttonSrcIdRcp.UseVisualStyleBackColor = true;
            // 
            // buttonMoy
            // 
            this.buttonMoy.Location = new System.Drawing.Point(606, 291);
            this.buttonMoy.Name = "buttonMoy";
            this.buttonMoy.Size = new System.Drawing.Size(129, 48);
            this.buttonMoy.TabIndex = 1;
            this.buttonMoy.Text = "Requete moyennes et nombre d\'épreuves ";
            this.buttonMoy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMoy);
            this.Controls.Add(this.buttonSrcIdRcp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSrcIdRcp;
        private System.Windows.Forms.Button buttonMoy;
    }
}

