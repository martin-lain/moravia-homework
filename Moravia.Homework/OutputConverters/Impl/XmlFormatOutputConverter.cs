using System;
using System.Xml.Linq;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Xml;
using Moravia.Homework.Model;

namespace Moravia.Homework.OutputConverters.Impl
{
    /// <summary>
    /// Implementation of serializing Document to XML
    /// </summary>
    public class XmlFormatOutputConverter
        : AbstractXmlFormatWriter<Document>, IOutputConverter, IDocumentProvider<Document>
    {
        public OutputTypes OutputType => OutputTypes.Xml;
        
        protected override XDocument SerializeDocument(Document document)
        {
            var outputDocument = new XDocument();
            outputDocument.Add(
                new XElement("document", 
                    new XElement("title", document.Title),
                    new XElement("text", document.Text)));
            return outputDocument;
        }
    }
}