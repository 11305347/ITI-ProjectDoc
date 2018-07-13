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
    public class T1ProjectObjectsLifeCycle
    {
        [Test]
        public void t1_creating_good_csharpdocreader()
        {
            CSharpDocReader cs = new CSharpDocReader();
            cs.Data.Should().NotBeNull();
            cs.Root.Should().NotBeNullOrEmpty();
            cs.ClassNames.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void t2_creating_good_textwriter()
        {
            Assert.Throws<ArgumentException>( () => new TextWriter( null, null ) );
            Assert.Throws<ArgumentException>( () => new TextWriter( String.Empty, String.Empty ) );

            {
                TextWriter t = new TextWriter( "dest_file", "csv" );
                Assert.That( t.FileName, Is.EqualTo( "dest_file" ) );
                Assert.That( t.Extension, Is.EqualTo( "csv" ) );
                t.DesktopPath.Should().NotBeNullOrEmpty();
                t.FilePath.Should().NotBeNullOrEmpty();
            }
        }

        [Test]
        public void t3_creating_good_csvwriter()
        {
            Assert.Throws<ArgumentException>( () => new CsvWriter( null ) );

            {
                TextWriter t = new TextWriter( "dest_file", "csv" );
                CsvWriter c = new CsvWriter( t );
                Assert.That( c.TextWriter, Is.EqualTo( t ) );
                c.Separator.Should().NotBeNullOrEmpty();
            }
        }
    }
}
