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
        string fileContent = string.Empty;
        string filePath = string.Empty;

        public FrmCompilateur()
        {
            InitializeComponent();
        }

        private void btnChoisirFichier_Click(object sender, EventArgs e)
        {
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
            
          // lexer.AddDefinition(new TokenDefinition());
          // lexer.AddDefinition(new TokenDefinition());
          // lexer.AddDefinition(new TokenDefinition());
          // lexer.AddDefinition(new TokenDefinition());
        }

        private void btnCompiler_Click(object sender, EventArgs e)
        {
            // Ajout des définitions dans le Lexer
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition(@"(int|float|char|string|bool)", "Declaration"));
            lexer.AddDefinition(new TokenDefinition(@"[a-zA-Z]{1}\w*[a-zA-Z]{1}|[a-zA-Z]{1}", "Identificateur"));
            lexer.AddDefinition(new TokenDefinition(@"if", "Condition"));
            lexer.AddDefinition(new TokenDefinition(@"\=\=|\!\=|\<|\>|\=", "Operateur"));
            lexer.AddDefinition(new TokenDefinition(@"for", "Boucle"));
            lexer.AddDefinition(new TokenDefinition(@"\;", "Point-Virgule"));
            lexer.AddDefinition(new TokenDefinition(@"^[0-9]+$", "Entier"));

            foreach (var token in lexer.Tokenize(fileContent, true))
            {
                lstErreurs.Items.Add(token.ToString());
            }
        }
    }
}
