# Moravia.Homework

Test assignment

## Format converters

Currently only XML and JSON read/write converters are implemented. 
New converters may be created by following of these 3 steps.

### 1. Adding format abstraction

In `Moravia.Homework.Abstractions.Formats` namespace is document-independent
part of format implementation that specifies, how the format is 
deserialized from input stream or serialized to output stream.

For example:
``` c# 
namespace Moravia.Homework.Abstractions.Formats.Xml
{
    public abstract class AbstractXmlFormatReader<TDocument>
        : IFormatReader<TDocument>
    {
        public async Task<TDocument> ReadAsync(Stream inputStream, CancellationToken token = default)
        {
            var document = await XDocument.LoadAsync(stream: inputStream, LoadOptions.None, token);
            await inputStream.DisposeAsync();

            return ParseDocument(document);
        }
        
        protected abstract TDocument ParseDocument(XDocument document);
    }
}
```

### 2. Adding known format type

Adding new format type to known format types enumeration is required so far.
But later could be possibly replaced by adding class attributes. 

Format types are defined here:
``` c#
namespace Moravia.Homework.InputConverters
{
    public enum InputTypes
    {
        Xml = 1,
        Json = 2
    }
}

namespace Moravia.Homework.OutputConverters
{
    public enum OutputTypes
    {
        Xml = 1,
        Json = 2
    }
}
```

### 3.Adding document-dependent implementation classes

Specific document related format implementation is required to be added to 
`Moravia.Homework.InputConverters.Impl` or `Moravia.Homework.OutputConverters.Impl` namespace
and extending classes from step #1.

Example implementation of Xml Document serialization:

``` c#
namespace Moravia.Homework.OutputConverters.Impl
{
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
```

`OutputType` and `DocumentType` property are currently unused but are designed
for later purpose of automatic format conversion class selection in application.   

## Storage

Storage providers are implemented in `Moravia.Homework.Storages`. New providers needs to 
implement `IStorageReader` or `IStorageWriter` interface according to their capabilities.

Storage implementaion example:
``` c#
namespace Moravia.Homework.Storages
{
    public class FileStorage
        : IStorageReader, IStorageWriter
    {
        private string FileName { get; }

        public FileStorage(string fileName)
        {
            FileName = fileName;
        }
        
        public Task<Stream> ReadStreamAsync(CancellationToken token = default)
        {
            var stream = File.Open(FileName, FileMode.Open, FileAccess.Read);
            return Task.FromResult((Stream) stream);
        }

        public async Task WriteStreamAsync(Stream stream, CancellationToken token = default)
        {
            await using var fileStream = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            await stream.CopyToAsync(fileStream, token);
        }
    }
}
```

## Tests

Basic tests are provided in Moravia.Homework.Tests. Hundred percent test coverage was not intended.