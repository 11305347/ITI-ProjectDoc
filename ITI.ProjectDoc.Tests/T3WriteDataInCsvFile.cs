using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace ITI.ProjectDoc.Tests
{
    [TestFixture]
    public class T3WriteDataInCsvFile
    {
        [Test]
         public void t1_can_create_file_and_write_content()
         {
             TextWriter t = new TextWriter( "test", "txt" );
             t.WriteData( "Insertion de données dans un fichier" );
             Assert.That( File.Exists( t.FilePath ), Is.EqualTo( true ) );
         }

        [Test]
        public void t2_create_csvfile_and_write_content()
        {
            TextWriter t = new TextWriter( "dest_file", "csv" );
            CsvWriter c = new CsvWriter( t );

            Assert.DoesNotThrow( () => c.AddCell( "" ) );
            c.AddCell( "A1" );
            c.AddCell( "A2" );
            c.NewLine();
            c.AddCell( "B1" );
            c.AddCell( "B2" );

            FileInfo f = new FileInfo( t.FilePath );
            Assert.That( File.Exists( t.FilePath ), Is.EqualTo( true ) );
            Assert.That( f.Length, Is.Not.Null );
    }
    }
}
