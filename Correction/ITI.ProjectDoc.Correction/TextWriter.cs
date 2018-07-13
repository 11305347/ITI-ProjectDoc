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
            if( String.IsNullOrEmpty( fileName ) || String.IsNullOrEmpty( extension ) )
                throw new ArgumentException( "Un paramètre manque." );
            else
            {
                _fileName = fileName;
                _extension = extension;
                _DESKTOP_PATH = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );
                _filePath = BuildDestinationPath();
            }
        }

        /// <summary>
        /// Retourne chemin du fichier
        /// </summary>
        public string FilePath
        {
            get => _filePath;
        }

        /// <summary>
        /// Retourne nom du fichier
        /// </summary>
        public string FileName
        {
            get => _fileName;
        }

        /// <summary>
        /// Retourne chemin du bureau
        /// </summary>
        public string DesktopPath
        {
            get => _DESKTOP_PATH;
        }

        /// <summary>
        /// Retourne extension du fichier
        /// </summary>
        public string Extension
        {
            get => _extension;
            set => _extension = value;
        }

        /// <summary>
        /// Retourne chemin de sauvegarde du fichier créé
        /// </summary>
        /// <returns> string chemin </returns>
        private string BuildDestinationPath()
        {
            _filePath = DesktopPath + "\\" + _fileName + "." + _extension;
            return _filePath;
        }


        /// <summary>
        /// Ecriture des données dans le fichier
        /// </summary>
        /// <param name="newContent"> Contenu à ajouter au fichier </param>
        /// <returns>booléen si écriture correcte</returns>
        public bool WriteData( string newContent )
        {
            if( _filePath.Equals( "" ) )
                throw new ArgumentException( "Impossible d'écrire dans le fichier." );
            else
            {
                File.AppendAllText( _filePath, newContent );
                return true;
            }
        }

    }
}
