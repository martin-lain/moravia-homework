using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Json;
using Moravia.Homework.Model;

namespace Moravia.Homework.OutputConverters.Impl
{
    /// <summary>
    /// Implementation of serializing Document to JSON
    /// </summary>
    public class JsonFormatOutputConverter
        : AbstractJsonFormatWriter<Document>, IOutputConverter, IDocumentProvider<Document>
    {
        public OutputTypes OutputType => OutputTypes.Json;
    }
}