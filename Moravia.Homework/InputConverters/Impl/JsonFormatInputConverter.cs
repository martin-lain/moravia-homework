using System;
using Moravia.Homework.Abstractions.Document;
using Moravia.Homework.Abstractions.Formats.Json;
using Moravia.Homework.Model;

namespace Moravia.Homework.InputConverters.Impl
{
    /// <summary>
    /// Implementation of deserializing Document from JSON
    /// </summary>
    public class JsonFormatInputConverter
        : AbstractJsonFormatReader<Document>, IInputConverter, IDocumentProvider<Document>
    {
        public InputTypes InputType => InputTypes.Json;
    }
}