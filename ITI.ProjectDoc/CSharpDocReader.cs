using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;


namespace ITI.ProjectDoc
{
    /// <summary>
    /// Classe permettant de lire dans un fichier 
    /// </summary>
    public class CSharpDocReader
    {
        /// <summary>
        /// Chemin du fichier de documentation
        /// </summary>
        private String _docPath;
        /// <summary>
        /// Données du fichier
        /// </summary>
        private XElement _data;
        /// <summary>
        /// Racine du fichier
        /// </summary>
        private String _root;
        /// <summary>
        /// Classes du fichier de documentation
        /// </summary>
        private List<string> _classNames;
        /// <summary>
        /// Eléments de la classe
        /// </summary>
        private Dictionary<string, List<XElement>> _classElements;


        /// <summary>
        /// Constructeur de la classe CSharpDocReader
        /// </summary>
        public CSharpDocReader()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne les données lus
        /// </summary>
        public XElement Data
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne la racine du document
        /// </summary>
        public String Root
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne les nom des classes
        /// </summary>
        public List<String> ClassNames
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Retourne les élements
        /// </summary>
        public Dictionary<string, List<XElement>> ClassElements
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Verifie si le fichier existe
        /// </summary>
        /// <returns> String chemin du fichier de documentation </returns>
        public String getDocumentationFilePath()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifie si le fichier existe
        /// </summary>
        /// <param name="filepath"> Chemin du fichier </param>
        private bool VerifyFile( String filepath )
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Méthode permettant de récupérer la racine du fichier
        /// </summary>
        private void getRootDoc()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de charger les noms de classe du fichier
        /// </summary>
        private void LoadClassNames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de charger les éléments d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        public void LoadClassElements( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de compter le nombre de méthode d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> int le nombre de méthode de la classe </returns>
        public int CountMethodofClass( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de récupérer le nombre de méthode d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> List contenant les méthodes de la classe </returns>
        public List<String> getClassMethodName( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de récupérer le nombre de méthode d'une classe donnée
        ///</summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="methodName"> Méthode de la classe </param>
        /// <returns> String contenant la valeur de retour d'une méthode de classe </returns>
        public String getReturnMethod( String className, String methodName )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de récupérer les paramètres d'une méthode de classe donnée
        ///</summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="methodName"> Méthode de la classe </param>
        /// <returns> List contenant les paramètres de méthode </returns>
        public List<String> getParamsMethod( String className, String methodName )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de retourner tous les éléments d'une classe
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> IEnumerable éléments de la classe </returns>
        public IEnumerable<XElement> getClassElement( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de compter le nombre de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> int le nombre de propriété de la classe </returns>
        public int CountPropertyofClass( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de récupérer les noms de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> List le nom des propriétés de la classe </returns>
        public List<String> getClassPropertyNameLinq( String className )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de récupérer les noms de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="classElement"> Elément de la classe </param>
        /// <returns> List le nom des propriétés de la classe </returns>
        public List<String> getClassPropertyName( String className, IEnumerable<XElement> classElement )
        {
            throw new NotImplementedException();
        }


    }
}
