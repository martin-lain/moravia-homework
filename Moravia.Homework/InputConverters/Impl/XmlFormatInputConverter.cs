using System;
using System.Xml.Linq;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Xml;
using Moravia.Homework.Model;

namespace Moravia.Homework.InputConverters.Impl
{
    /// <summary>
    /// Implementation of deserializing Document from XML
    /// </summary>
    public class XmlFormatInputConverter
        : AbstractXmlFormatReader<Document>, IInputConverter, IDocumentProvider<Document>
    {
        public InputTypes InputType => InputTypes.Xml;

        protected override Document ParseDocument(XDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return new Document
            {
                Title = document.Root?.Element("title")?.Value,
                Text = document.Root?.Element("text")?.Value,
            };
        }
    }
}