namespace tp1_Vcote_Pturcotte
{
    partial class FrmCompilateur
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
            this.lblNomFichier = new System.Windows.Forms.Label();
            this.btnChoisirFichier = new System.Windows.Forms.Button();
            this.lstErreurs = new System.Windows.Forms.ListBox();
            this.lblTitreInfos = new System.Windows.Forms.Label();
            this.btnCompiler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomFichier
            // 
            this.lblNomFichier.AutoSize = true;
            this.lblNomFichier.Location = new System.Drawing.Point(123, 17);
            this.lblNomFichier.Name = "lblNomFichier";
            this.lblNomFichier.Size = new System.Drawing.Size(126, 13);
            this.lblNomFichier.TabIndex = 0;
            this.lblNomFichier.Text = "Aucun fichier sélectionné";
            // 
            // btnChoisirFichier
            // 
            this.btnChoisirFichier.Location = new System.Drawing.Point(12, 12);
            this.btnChoisirFichier.Name = "btnChoisirFichier";
            this.btnChoisirFichier.Size = new System.Drawing.Size(105, 23);
            this.btnChoisirFichier.TabIndex = 1;
            this.btnChoisirFichier.Text = "Choisir un fichier";
            this.btnChoisirFichier.UseVisualStyleBackColor = true;
            this.btnChoisirFichier.Click += new System.EventHandler(this.btnChoisirFichier_Click);
            // 
            // lstErreurs
            // 
            this.lstErreurs.FormattingEnabled = true;
            this.lstErreurs.Location = new System.Drawing.Point(12, 122);
            this.lstErreurs.Name = "lstErreurs";
            this.lstErreurs.Size = new System.Drawing.Size(524, 160);
            this.lstErreurs.TabIndex = 2;
            // 
            // lblTitreInfos
            // 
            this.lblTitreInfos.AutoSize = true;
            this.lblTitreInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreInfos.Location = new System.Drawing.Point(12, 100);
            this.lblTitreInfos.Name = "lblTitreInfos";
            this.lblTitreInfos.Size = new System.Drawing.Size(187, 16);
            this.lblTitreInfos.TabIndex = 3;
            this.lblTitreInfos.Text = "Informations sur la compilation";
            // 
            // btnCompiler
            // 
            this.btnCompiler.Location = new System.Drawing.Point(12, 50);
            this.btnCompiler.Name = "btnCompiler";
            this.btnCompiler.Size = new System.Drawing.Size(75, 23);
            this.btnCompiler.TabIndex = 4;
            this.btnCompiler.Text = "Compiler";
            this.btnCompiler.UseVisualStyleBackColor = true;
            // 
            // FrmCompilateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 294);
            this.Controls.Add(this.btnCompiler);
            this.Controls.Add(this.lblTitreInfos);
            this.Controls.Add(this.lstErreurs);
            this.Controls.Add(this.btnChoisirFichier);
            this.Controls.Add(this.lblNomFichier);
            this.Name = "FrmCompilateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super compilateur par Pascal Turcotte et Vincent Côté";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNomFichier;
        private System.Windows.Forms.Button btnChoisirFichier;
        private System.Windows.Forms.ListBox lstErreurs;
        private System.Windows.Forms.Label lblTitreInfos;
        private System.Windows.Forms.Button btnCompiler;
    }
}

