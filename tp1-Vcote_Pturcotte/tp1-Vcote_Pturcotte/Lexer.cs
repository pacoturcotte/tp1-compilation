using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tp1_Vcote_Pturcotte
{
    public class Lexer
    {
        public const string EoF = "__0End__";
        public const string Whitespace = "Whitespace";
        private List<TokenDefinition> _definitions = new List<TokenDefinition>();
        private static Regex _whiteSpace = new Regex($@"((\r|\t|\v|\f| )*(?<NewLine>({Environment.NewLine}|\n)+)?)+", RegexOptions.Compiled);
        public Form FrmCompilateur;

        public Lexer()
        {

        }

        public Lexer(FrmCompilateur pFrmCompilateur)
        {
            FrmCompilateur = pFrmCompilateur;
        }
        //Constructeur de lexer, on lui envoie une liste d'enumerables de type TokenDefinition
        public Lexer(IEnumerable<TokenDefinition> definitions)
        {
            foreach (var def in definitions)
            {
                AddDefinition(def);
            }
        }

        //Permet d'ajouter les définitions à notre liste de type TokenDefinitions.
        //Celle-ci va être utile lorsque l'on parcoueras un fichier
        public void AddDefinition(TokenDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException("definition");
            }
            _definitions.Add(definition);
        }

        public IEnumerable<Token> Tokenize(string source, bool ignoreWhitespace = false)
        {
            int index = 0;
            int line = 1;
            int column = 0;
            var oldMatch = "";
            while (index < source.Length)
            {
                TokenDefinition matchedDefinition = null;
                int matchLength = 0;

                foreach (var rule in _definitions)
                {
                    var match = rule.Regex.Match(source, index);

                    if (rule.Type == "Identificateur" &&_definitions[5].Regex.Match(source, index+1).Value != "")
                    {
                        break;
                    }

                    //CODE DLA MOR KITU
                 //   if (rule.Type == "Identificateur")
                 //   {
                 //       bool result = true;
                 //       string strToTest = "";
                 //       int indexTempo = 1;
                 //       var previousVal = source.Substring(index, indexTempo);
                 //       while (result)
                 //       {
                 //           //var value = source.Substring(index, matchLength);
                 //           strToTest = source.Substring(index, indexTempo);
                 //           if ((previousVal != "")/* && (_definitions[1].Regex.Match(strToTest)).Value != previousVal*/)
                 //           {
                 //               matchedDefinition = rule;
                 //               matchLength = match.Length;
                 //               previousVal = _definitions[1].Regex.Match(strToTest).Value;
                 //               //result = false;
                 //           }
                 //           else
                 //           {
                 //               result = false;
                 //           }
                 //           indexTempo++;
                 //       }
                 //   }
                    






                    if (match.Success && match.Index - index == 0 && match.Length > matchLength)
                    {
                        matchedDefinition = rule;
                        matchLength = match.Length;
                        oldMatch = match.Value;
                        break;
                    }
                    
                }

                if (matchedDefinition == null)
                {
                    FrmCompilateur frmTemp = (FrmCompilateur)FrmCompilateur;
                    frmTemp.ShowError("Erreur à l'index " + index + ", ligne " + line + ", colonne " + column + ", châine en conflit : " + source[index]);
                    index++;
                }

                //if (matchedDefinition == null)
                //    throw new UnrecognizedTokenException(source[index], new TokenPosition(index, line, column),
                //        $"Unrecognized symbol '{source[index]}' at index {index} (line {line}, column {column})");

                var value = source.Substring(index, matchLength);
             
             if (matchedDefinition != null && !matchedDefinition.IsIgnored)
                 yield return new Token(matchedDefinition.Type, value, new TokenPosition(index, line, column));
             
              var whitespace = _whiteSpace.Match(source, index + matchLength);
             
              if (whitespace.Success && whitespace.Length > 0)
              {
                  if (!ignoreWhitespace)
                      yield return new Token("Whitespace", whitespace.Value, new TokenPosition(whitespace.Index, line, column + matchLength));
             
                  matchLength += whitespace.Length;
                  var newLines = whitespace.Groups["NewLine"];
                  if (newLines.Success)
                  {
                      line += newLines.Captures.Count;
                      column = whitespace.Length - (whitespace.Value.LastIndexOf(newLines.Value) + 1);
                  }
                  else
                      column += matchLength;
              }
              else
                  column += matchLength;
             
              index += matchLength;
            }

            yield return new Token(EoF, null, new TokenPosition(index, line, column));
        }
    }
}
