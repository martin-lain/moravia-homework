using System;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Json;
using Moravia.Homework.Model;

namespace Moravia.Homework.InputConverters.Impl
{
    public class JsonFormatInputConverter
        : AbstractJsonFormatReader<Document>, IInputConverter, IDocumentProvider
    {
        public InputTypes InputType => InputTypes.Json;
        public Type DocumentType => typeof(Document);
    }
}