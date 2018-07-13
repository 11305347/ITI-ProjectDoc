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
            _data = null;
            _root = "";
            _classNames = new List<string>();
            _classElements = new Dictionary<string, List<XElement>>();
            _docPath = getDocumentationFilePath();
            ReadFile();
            getRootDoc();
            LoadClassNames();
        }

        /// <summary>
        /// Retourne les données lus
        /// </summary>
        public XElement Data
        {
            get => _data;
        }

        /// <summary>
        /// Retourne la racine du document
        /// </summary>
        public String Root
        {
            get => _root;
        }

        /// <summary>
        /// Retourne les nom des classes
        /// </summary>
        public List<String> ClassNames
        {
            get => _classNames;
        }

        /// <summary>
        /// Retourne les éléments des classes
        /// </summary>
        public Dictionary<string, List<XElement>> ClassElements
        {
            get =>  _classElements;
        }

        /// <summary>
        /// Verifie si le fichier existe
        /// </summary>
        /// <returns> String chemin du fichier de documentation </returns>
        public String getDocumentationFilePath()
        {
            var assembly = System.Reflection.Assembly.GetAssembly( this.GetType() );//Get the assembly object
            var nameSpace = assembly.ToString().Split( ',' )[0];
            var docPath = Environment.CurrentDirectory + "\\" + Assembly.GetCallingAssembly().GetName().Name + ".Tests.xml";
            var parent = Directory.GetParent( Directory.GetCurrentDirectory() ).Parent.Parent.FullName;
            return  Directory.GetParent( parent ).FullName + "\\" + nameSpace + "\\bin\\debug\\net461\\" + nameSpace + ".xml";

            
        }

        /// <summary>
        /// Verifie si le fichier existe
        /// </summary>
        /// <param name="filepath"> Chemin du fichier </param>
        private bool VerifyFile( String filepath )
        {
            return File.Exists( filepath );

        }

        /// <summary>
        /// Méthode permettant de lire le fichier de documenation
        /// </summary>
        private void ReadFile()
        {
            var good = VerifyFile( _docPath );
            if( !good )
                throw new ArgumentException( "Fichier non existant." );
            else
                _data = XElement.Load( _docPath );
        }

        /// <summary>
        /// Méthode permettant de récupérer la racine du fichier
        /// </summary>
        private void getRootDoc()
        {
            _root = (from e in _data.Descendants()
                     select e).ToString();
        }

        /// <summary>
        /// Méthode permettant de charger les noms de classe du fichier
        /// </summary>
        private void LoadClassNames()
        {

            /*var className = (from el in _data.Elements("members").Descendants()
                              where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains("#ctor")
                              select el.FirstAttribute.ToString().Split('#')[0].Split('.')[1]);*/

            var a = (from el in _data.Elements( "members" ).Descendants()
                    where el.FirstAttribute != null && el.FirstAttribute.Value.StartsWith( "T" )
                    select el);


            _classNames = (from el in _data.Elements( "members" ).Descendants()
                           where el.FirstAttribute != null && el.FirstAttribute.Value.StartsWith( "T" )
                           select el.FirstAttribute.Value.Split( '.' )[2]).ToList();
        }

        /// <summary>
        /// Méthode permettant de charger les éléments d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        public void LoadClassElements( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else
            {
                List<XElement> l = new List<XElement>();
                //On récupère les éléments de la classe concerné
                IEnumerable<XElement> elements = getClassElement( className );
                foreach( var e in elements )
                {
                    l.Add( e );
                }
                _classElements.Add( className, l );
            }
        }

        /// <summary>
        /// Méthode permettant de compter le nombre de méthode d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> int le nombre de méthode de la classe </returns>
        public int CountMethodofClass( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else if( _data != null )
            {
                return (from el in _data.Elements( "members" ).Descendants()
                        where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains( className )
                         && el.FirstAttribute.Value.StartsWith( "M" )
                        select el).Count();
            }
            else return 0;

        }

        /// <summary>
        /// Méthode permettant de récupérer le nombre de méthode d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> List contenant les méthodes de la classe </returns>
        public List<String> getClassMethodName( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else if( _data != null )
            {
                return (from el in _data.Elements( "members" ).Descendants()
                        where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains( className )
                        && el.FirstAttribute.Value.StartsWith( "M" )
                        select el.FirstAttribute.Value.Split( '.' )[2]).ToList();
            }
            else return new List<string>();
        }

        /// <summary>
        /// Méthode permettant de récupérer le nombre de méthode d'une classe donnée
        ///</summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="methodName"> Méthode de la classe </param>
        /// <returns> String contenant la valeur de retour d'une méthode de classe </returns>
        public String getReturnMethod( String className, String methodName )
        {
            if( String.IsNullOrEmpty( className ) || String.IsNullOrEmpty( methodName ) )
                throw new ArgumentException( "Un paramètre manque." );
            else
            {
                var result = (from el in _data.Elements( "members" ).Descendants( "returns" )
                              where el.Parent.FirstAttribute.Value.Contains( className )
                              && el.Parent.FirstAttribute.Value.Contains( methodName )
                              select el.Value);

                String r = "";
                foreach( var val in result )
                {
                    r = val.ToString();
                }
                return r;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer les paramètres d'une méthode de classe donnée
        ///</summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="methodName"> Méthode de la classe </param>
        /// <returns> List contenant les paramètres de méthode </returns>
        public List<String> getParamsMethod( String className, String methodName )
        {
            if( String.IsNullOrEmpty( className ) || String.IsNullOrEmpty( methodName ) )
                throw new ArgumentException( "Un paramètre manque." );
            else if( _data != null )
            {
                return (from el in _data.Elements( "members" ).Descendants( "param" )
                        where el.Parent.FirstAttribute.Value.Contains( className )
                        && el.Parent.FirstAttribute.Value.Contains( methodName )
                        select el.LastAttribute.Value).ToList();
            }
            else
                return new List<String>();

        }

        /// <summary>
        /// Méthode permettant de retourner tous les éléments d'une classe
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> IEnumerable éléments de la classe </returns>
        public IEnumerable<XElement> getClassElement( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else
            {
                IEnumerable<XElement> elList =
                from el in _data.Elements( "members" ).Descendants()
                where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains( className )
                select el;

                return elList;
            }
        }

        /// <summary>
        /// Méthode permettant de compter le nombre de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> int le nombre de propriété de la classe </returns>
        public int CountPropertyofClass( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else if( _data != null )
            {
                return (from el in _data.Elements( "members" ).Descendants()
                        where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains( className )
                        && el.FirstAttribute.Value.StartsWith( "F" )
                        select el).Count();
            }
            else return 0;

        }

        /// <summary>
        /// Méthode permettant de récupérer les noms de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <returns> List le nom des propriétés de la classe </returns>
        public List<String> getClassPropertyNameLinq( String className )
        {
            if( String.IsNullOrEmpty( className ) )
                throw new ArgumentException( "Un paramètre manque." );
            else if( _data != null )
            {
                return (from el in _data.Elements( "members" ).Descendants()
                        where el.FirstAttribute != null && el.FirstAttribute.Value.ToString().Contains( className )
                        && el.FirstAttribute.Value.StartsWith( "F" )
                        select el.FirstAttribute.Value.Split( '.' )[2]).ToList();
            }
            else
                return new List<String>();
        }

        /// <summary>
        /// Méthode permettant de récupérer les noms de propriété d'une classe donnée
        /// </summary>
        /// <param name="className"> Nom de la classe </param>
        /// <param name="classElement"> Elément de la classe </param>
        /// <returns> List le nom des propriétés de la classe </returns>
        public List<String> getClassPropertyName( String className, IEnumerable<XElement> classElement )
        {
            if( String.IsNullOrEmpty( className ) || classElement.Count() == 0 )
                throw new ArgumentException( "Un paramètre manque." );
            else
            {
                List<String> p = new List<string>();

                foreach( XElement el in classElement )
                    p.Add( el.FirstAttribute.Value.Split( '.' )[2] );

                return p;
            }
        }

    }
}
