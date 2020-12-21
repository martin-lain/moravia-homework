using System;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Json;
using Moravia.Homework.Model;

namespace Moravia.Homework.OutputConverters.Impl
{
    public class JsonFormatOutputConverter
        : AbstractJsonFormatWriter<Document>, IOutputConverter, IDocumentProvider
    {
        public OutputTypes OutputType => OutputTypes.Json;
        public Type DocumentType => typeof(Document);
    }
}