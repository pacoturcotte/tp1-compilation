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
        // Variables globales pour lire les fichiers C#
        string fileContent = string.Empty;
        string filePath = string.Empty;

        // Variable globale pour calculer l'adresse
        int adresse = 0;
        bool first = true;

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
            List<Token> tokenList = new List<Token>();

            Dictionary<string, int> dictTableSymbole = new Dictionary<string, int>();
            dictTableSymbole.Add("int", 4);
            dictTableSymbole.Add("float", 4);
            dictTableSymbole.Add("string", 2);  // sera multipliée par la longueur de la string 
            dictTableSymbole.Add("char", 2);
            dictTableSymbole.Add("bool", 1);

            // Ajout des définitions dans le Lexer
            FrmCompilateur frmCompilateur = this;
            var lexer = new Lexer(frmCompilateur);
            lexer.AddDefinition(new TokenDefinition(@"(^int$|^float$|^char$|^string$|^bool$)", "Declaration"));
            lexer.AddDefinition(new TokenDefinition(@"if", "Condition"));
            lexer.AddDefinition(new TokenDefinition(@"for", "Boucle"));
            lexer.AddDefinition(new TokenDefinition(@"(true|false|TRUE|FALSE)", "Booleen"));
            lexer.AddDefinition(new TokenDefinition(@"==|!=|<|>|=", "Operateur"));
            lexer.AddDefinition(new TokenDefinition(@"^[0-9]+", "Entier"));
            lexer.AddDefinition(new TokenDefinition(@"^[-+]?([0-9]+|[0-9]*\.[0-9]+)", "Reel"));
            lexer.AddDefinition(new TokenDefinition(@"^\"".*\""$", "Chaine de caracteres"));
            lexer.AddDefinition(new TokenDefinition(@"'\.?'", "Caractere"));        
            lexer.AddDefinition(new TokenDefinition(@"(;|\(|\)|\{|\})", "Terminaux"));
            lexer.AddDefinition(new TokenDefinition(@"^[a-zA-Z]\w*[a-zA-Z]$|^[a-zA-Z]$", "Identificateur"));

            // Affichage de l'analyse lexicale
            foreach (var token in lexer.Tokenize(fileContent, true))
            {          
                lbErreurs.Items.Add(token.ToString() + "\n");           
                tokenList.Add(token);
            }
            RemplirTableSymbole(tokenList, dictTableSymbole);
        }

        public void RemplirTableSymbole(List<Token> listToken, Dictionary<string, int> dict)
        {
            for (int i = 1; i<=listToken.Count(); i++)
            {
                if (listToken[i-1].Type == "Declaration" && listToken[i].Type == "Identificateur" && listToken[i-1].Value == "string")
                {
                    adresse = CalculAdresse(listToken, dict, i - 1);
                    dgvSymbolTable.Rows.Add(listToken[i].Value.ToString(), listToken[i - 1].Value.ToString(), TrouverTailleTypeString(listToken, dict, i-1), adresse.ToString());
                }
                else if (listToken[i - 1].Type == "Declaration" && listToken[i].Type == "Identificateur")
                {
                    adresse = CalculAdresse(listToken, dict, i - 1);
                    dgvSymbolTable.Rows.Add(listToken[i].Value.ToString(), listToken[i - 1].Value.ToString(), TrouverTailleType(listToken[i-1], dict), adresse.ToString());
                }
            }
        }

        public int CalculAdresse(List<Token> listToken, Dictionary<string, int> dict, int i)
        {
            if (first)
            {
                first = false;
                return adresse;
            }
            else
            {
                if (listToken[i].Value.ToString() == "string")
                    adresse += TrouverTailleTypeString(listToken, dict, i);
                else
                    adresse += TrouverTailleType(listToken[i], dict);
                return adresse;
            }
        }

        public int TrouverTailleType(Token token, Dictionary<string, int> dict)
        {
            string tokenType = token.Value.ToString();
            int tailleType = 0;
            foreach (KeyValuePair<string, int> item in dict)
            {
                if (item.Key == tokenType)
                {
                    tailleType = item.Value;
                }
            }
            return tailleType;
        }

        public int TrouverTailleTypeString(List<Token> listToken, Dictionary<string, int> dict, int i)
        {
            string tokenType = listToken[i].Value.ToString();
            int tailleTypeString = 0;
            foreach (KeyValuePair<string, int> item in dict)
            {
                if (item.Key == tokenType)
                {
                    tailleTypeString = item.Value * (listToken[i+3].Value.ToString().Length - 2);
                }
            }
            return tailleTypeString;
        }


        public void ShowError(string pErreur)
        {
            lbErreurs.Items.Add(pErreur);
        }
    }
}
