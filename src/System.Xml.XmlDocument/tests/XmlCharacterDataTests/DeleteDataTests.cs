using Xunit;
using System;
using System.Xml;

namespace XmlDocumentTests.XmlCharacterDataTests
{
    public class DeleteDataTests
    {
        [Fact]
        public static void DeleteAllCharsInCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(0, cdataNode.Length);

            Assert.Equal(0, cdataNode.Length);
            Assert.Equal(String.Empty, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteCharsInMiddleOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefghijklmn]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(5, 4);

            var expected = "abcdejklmn";

            Assert.Equal(expected.Length, cdataNode.Length);
            Assert.Equal(expected, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteLastCharacterOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdef]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(cdataNode.Data.Length - 1, 1);

            var expected = "abcde";

            Assert.Equal(expected.Length, cdataNode.Length);
            Assert.Equal(expected, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteCharactersBeyondEndOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(0, cdataNode.Data.Length + 1);

            Assert.Equal(0, cdataNode.Length);
            Assert.Equal(String.Empty, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteCharactersBeyondEndOfCDataNodeWithLargeNumber()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(0, Int32.MaxValue);

            Assert.Equal(0, cdataNode.Length);
            Assert.Equal(String.Empty, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteOneCharacterFromBeginningOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            cdataNode.DeleteData(0, 1);

            var expected = "bcdefg";

            Assert.Equal(expected.Length, cdataNode.Length);
            Assert.Equal(expected, cdataNode.Data);
            Assert.Equal(XmlNodeType.CDATA, cdataNode.NodeType);
        }

        [Fact]
        public static void DeleteCharactersStartBeyondEndOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            Assert.Throws<ArgumentOutOfRangeException>(() => cdataNode.DeleteData(cdataNode.Data.Length + 1, 1));
        }

        [Fact]
        public static void DeleteCharactersStartNegativeOfCDataNode()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><![CDATA[abcdefg]]></root>");

            var cdataNode = (XmlCharacterData)xmlDocument.DocumentElement.FirstChild;

            Assert.Throws<ArgumentOutOfRangeException>(() => cdataNode.DeleteData(-1, 1));
        }

    }
}
