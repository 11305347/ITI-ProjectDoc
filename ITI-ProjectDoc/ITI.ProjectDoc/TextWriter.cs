using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ProjectDoc
{
    /// <summary>
    /// Classe permettant d'écrire dans un fichier 
    /// </summary>
    public class TextWriter
    {
        /// <summary>
        /// Propriété nom du fichier
        /// </summary>
        private String _fileName;
        /// <summary>
        /// Propriété extension de fichier
        /// </summary>
        private String _extension;
        /// <summary>
        /// Propriété chemin du fichier
        /// </summary>
        private String _filePath;
        /// <summary>
        /// Propriété chemin du bureau
        /// </summary>
        private String _DESKTOP_PATH;

        /// <summary>
        /// Constructeur de classe
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        public TextWriter( string fileName, string extension )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne chemin du fichier
        /// </summary>
        public string FilePath
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne nom du fichier
        /// </summary>
        public string FileName
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne chemin du bureau
        /// </summary>
        public string DesktopPath
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne extension du fichier
        /// </summary>
        public string Extension
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne chemin de sauvegarde du fichier créé
        /// </summary>
        /// <returns> string chemin </returns>
        private string BuildDestinationPath()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Ecriture des données dans le fichier
        /// </summary>
        /// <param name="newContent"> Contenu à ajouter au fichier </param>
        /// <returns>booléen si écriture correcte</returns>
        public bool WriteData( string newContent )
        {
            throw new NotImplementedException();
        }

    }
}
