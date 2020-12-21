using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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