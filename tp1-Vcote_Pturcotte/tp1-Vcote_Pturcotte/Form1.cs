using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tp1_Vcote_Pturcotte
{
    public partial class FrmCompilateur : Form
    {
        public FrmCompilateur()
        {
            InitializeComponent();
        }

        private void btnChoisirFichier_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Visual C# Source File (*.cs)|*.cs";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    lblNomFichier.Text = openFileDialog.SafeFileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void FrmCompilateur_Load(object sender, EventArgs e)
        {
            var defs = new TokenDefinition[]
                {
                    new TokenDefinition(@"(int|float|char|string|bool)", "Declaration"),
                    new TokenDefinition(@"^[a-zA-Z]([a-zA-Z0-9])*[a-zA-Z]", "Identificateur"),
                    new TokenDefinition(@"if", "Condition"),
                    new TokenDefinition(@"\=\=|\!\=|\<|\>", "Operateur"),
                    new TokenDefinition(@"for", "Boucle")
                };
        }
    }
}
