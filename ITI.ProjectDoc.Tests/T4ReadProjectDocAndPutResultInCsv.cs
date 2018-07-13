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
    class T4ReadProjectDocAndPutResultInCsv
    {
        [Test]
        public void t1_can_create_file_for_detail_of_class()
        {
            TextWriter txt = new TextWriter( "count_method_and_property", "csv" );
            CsvWriter csv = new CsvWriter( txt );
            csv.AddCell( "Nom de classe" );
            csv.AddCell( "Nombre de méthodes" );
            csv.AddCell( "Nombre de propriété" );
            csv.NewLine();
            CSharpDocReader csharp = new CSharpDocReader();

            //On charge les élements de la classe
            csharp.LoadClassElements( "CsvWriter" );
            csv.AddCell( "CsvWriter" );
            Assert.That( csharp.CountMethodofClass( "CsvWriter" ), Is.EqualTo( 3 ) );
            csv.AddCell( csharp.CountMethodofClass( "CsvWriter" ).ToString() );
            Assert.That( csharp.CountPropertyofClass( "CsvWriter" ), Is.EqualTo( 2 ) );
            csv.AddCell( csharp.CountPropertyofClass( "CsvWriter" ).ToString() );
            csv.NewLine();

        }
    }
}
