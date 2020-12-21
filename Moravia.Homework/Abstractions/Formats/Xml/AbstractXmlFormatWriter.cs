using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Moravia.Homework.Abstractions.Formats.Xml
{
    /// <summary>
    /// Abstract XML serializer
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public abstract class AbstractXmlFormatWriter<TDocument>
        : IFormatWriter<TDocument>
    {
        public async Task<Stream> WriteAsync(TDocument document, CancellationToken token = default)
        {
            var outputDocument = SerializeDocument(document);
            var stream = new MemoryStream();
            await outputDocument.SaveAsync(stream, SaveOptions.None, token);
            stream.Position = 0;
            return stream;
        }
        
        protected abstract XDocument SerializeDocument(TDocument document);
    }
}