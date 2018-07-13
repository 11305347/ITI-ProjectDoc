using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace ITI.ProjectDoc.Tests
{
    [TestFixture]
    public class T2ReadProjectFile
    {

        [Test]
        public void t1_project_documentation_can_be_read()
        {
            CSharpDocReader csharp = new CSharpDocReader();

            Assert.That( csharp.Data, Is.Not.EqualTo( null ) );
            Assert.That( csharp.ClassNames, Is.Not.EqualTo( null ) );
            Assert.That( csharp.ClassNames.Contains( "CSharpDocReader" ), Is.EqualTo( true ) );
            Assert.That( csharp.ClassNames.Contains( "CsvWriter" ), Is.EqualTo( true ) );
        }

        [Test]
        public void t2_can_get_elements_of_Class()
        {
            CSharpDocReader csharp = new CSharpDocReader();

            Assert.Throws<ArgumentException>( () => csharp.LoadClassElements( null ) );

            //On boucle sur les classes du fichier
            foreach( var c in csharp.ClassNames )
            {
                csharp.LoadClassElements( c );
            }
            Assert.That( csharp.ClassElements, Is.Not.EqualTo( null ) );

        }

        [Test]
        public void t3_can_count_method_and_property_of_existing_class()
        {
            CSharpDocReader csharp = new CSharpDocReader();

            Assert.Throws<ArgumentException>( () => csharp.CountPropertyofClass( null ) );
            Assert.That( csharp.CountPropertyofClass( "Unknow" ), Is.EqualTo( 0) );
            Assert.That( csharp.CountPropertyofClass( "CsvWriter" ), Is.Not.EqualTo( null ) );

            Assert.Throws<ArgumentException>( () => csharp.CountMethodofClass( null ) );
            Assert.That( csharp.CountMethodofClass( "CSharpDocReader" ), Is.Not.EqualTo( 200 ) );
        }

        [Test]
        public void t4_can_get_param_name_of_class_method()
        {
            CSharpDocReader csharp = new CSharpDocReader();
            Assert.Throws<ArgumentException>( () => csharp.getParamsMethod( null, "" ) );
            Assert.Throws<ArgumentException>( () => csharp.getParamsMethod( null, null ) );
            Assert.That( csharp.getParamsMethod( "CsvWriter", "AddCell" ).Count, Is.EqualTo( 1 ) );
            Assert.That( csharp.getParamsMethod( "CsvWriter", "UnknowMethod" ).Count, Is.EqualTo( 0 ) );
        }
    }
}
