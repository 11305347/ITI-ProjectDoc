using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ProjectDoc
{
    /// <summary>
    /// Classe permettant d'écrire dans un fichier csv
    /// </summary>
    public class CsvWriter
    {
        /// <summary>
        /// Propriété _textWriter
        /// </summary>
        TextWriter _textWriter;
        /// <summary>
        /// Propriété _SEPARATOR
        /// </summary>
        String _SEPARATOR;

        /// <summary>
        /// Constructeur de la classe CsvWriter
        /// </summary>
        /// <param name="output"> TextWriter </param>
        public CsvWriter( TextWriter output )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne textWriter
        /// </summary>
        public TextWriter TextWriter
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne le séparateur
        /// </summary>
        public String Separator
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Méthode permettant d'ajouter des cellules dans le fichier csv
        /// </summary>
        /// <param name="content"> Contenu à ajouter </param>
        /// <returns>
        /// Void
        /// </returns>
        public void AddCell( String content )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant d'ajouter une nouvelle ligne dans le fichier csv
        /// </summary>
        /// <returns>
        /// Void
        /// </returns>
        public void NewLine()
        {
            throw new NotImplementedException();
        }
    }
}
