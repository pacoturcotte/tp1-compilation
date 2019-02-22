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
            this.lbErreurs = new System.Windows.Forms.ListBox();
            this.btnCompiler = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSymbolTable = new System.Windows.Forms.DataGridView();
            this.identificateur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomFichier
            // 
            this.lblNomFichier.AutoSize = true;
            this.lblNomFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomFichier.Location = new System.Drawing.Point(122, 31);
            this.lblNomFichier.Name = "lblNomFichier";
            this.lblNomFichier.Size = new System.Drawing.Size(155, 16);
            this.lblNomFichier.TabIndex = 0;
            this.lblNomFichier.Text = "Aucun fichier sélectionné";
            // 
            // btnChoisirFichier
            // 
            this.btnChoisirFichier.Location = new System.Drawing.Point(13, 28);
            this.btnChoisirFichier.Name = "btnChoisirFichier";
            this.btnChoisirFichier.Size = new System.Drawing.Size(105, 23);
            this.btnChoisirFichier.TabIndex = 1;
            this.btnChoisirFichier.Text = "Choisir un fichier";
            this.btnChoisirFichier.UseVisualStyleBackColor = true;
            this.btnChoisirFichier.Click += new System.EventHandler(this.btnChoisirFichier_Click);
            // 
            // lbErreurs
            // 
            this.lbErreurs.FormattingEnabled = true;
            this.lbErreurs.HorizontalScrollbar = true;
            this.lbErreurs.ItemHeight = 16;
            this.lbErreurs.Location = new System.Drawing.Point(6, 19);
            this.lbErreurs.Name = "lbErreurs";
            this.lbErreurs.Size = new System.Drawing.Size(634, 324);
            this.lbErreurs.TabIndex = 2;
            // 
            // btnCompiler
            // 
            this.btnCompiler.Location = new System.Drawing.Point(535, 18);
            this.btnCompiler.Name = "btnCompiler";
            this.btnCompiler.Size = new System.Drawing.Size(117, 42);
            this.btnCompiler.TabIndex = 4;
            this.btnCompiler.Text = "Compiler";
            this.btnCompiler.UseVisualStyleBackColor = true;
            this.btnCompiler.Click += new System.EventHandler(this.btnCompiler_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbErreurs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 355);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations sur la compilation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSymbolTable);
            this.groupBox2.Location = new System.Drawing.Point(706, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 333);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table des symboles";
            // 
            // dgvSymbolTable
            // 
            this.dgvSymbolTable.AllowUserToAddRows = false;
            this.dgvSymbolTable.AllowUserToDeleteRows = false;
            this.dgvSymbolTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbolTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.identificateur,
            this.type,
            this.size,
            this.adress});
            this.dgvSymbolTable.Location = new System.Drawing.Point(27, 20);
            this.dgvSymbolTable.Name = "dgvSymbolTable";
            this.dgvSymbolTable.Size = new System.Drawing.Size(445, 282);
            this.dgvSymbolTable.TabIndex = 0;
            // 
            // identificateur
            // 
            this.identificateur.HeaderText = "Identificateur";
            this.identificateur.Name = "identificateur";
            this.identificateur.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // size
            // 
            this.size.HeaderText = "Taille";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // adress
            // 
            this.adress.HeaderText = "Adresse";
            this.adress.Name = "adress";
            this.adress.ReadOnly = true;
            // 
            // FrmCompilateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCompiler);
            this.Controls.Add(this.btnChoisirFichier);
            this.Controls.Add(this.lblNomFichier);
            this.Name = "FrmCompilateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super compilateur par Pascal Turcotte et Vincent Côté";
            this.Load += new System.EventHandler(this.FrmCompilateur_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNomFichier;
        private System.Windows.Forms.Button btnChoisirFichier;
        private System.Windows.Forms.ListBox lbErreurs;
        private System.Windows.Forms.Button btnCompiler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSymbolTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn identificateur;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn adress;
    }
}

