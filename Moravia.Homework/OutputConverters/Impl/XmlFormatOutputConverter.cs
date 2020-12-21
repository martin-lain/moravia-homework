using System;
using System.Xml.Linq;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Xml;
using Moravia.Homework.Model;

namespace Moravia.Homework.OutputConverters.Impl
{
    public class XmlFormatOutputConverter
        : AbstractXmlFormatWriter<Document>, IOutputConverter, IDocumentProvider
    {
        public OutputTypes OutputType => OutputTypes.Xml;
        public Type DocumentType => typeof(Document);

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