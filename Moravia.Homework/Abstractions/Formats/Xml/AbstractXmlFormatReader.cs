using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Moravia.Homework.Abstractions.Formats.Xml
{
    /// <summary>
    /// Abstract XML deserializer
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public abstract class AbstractXmlFormatReader<TDocument>
        : IFormatReader<TDocument>
    {
        public async Task<TDocument> ReadAsync(Stream inputStream, CancellationToken token = default)
        {
            try
            {
                var document = await XDocument.LoadAsync(stream: inputStream, LoadOptions.None, token);
                await inputStream.DisposeAsync();

                return ParseDocument(document);
            }
            catch (Exception e)
            {
                throw new Exception("Source conversion error", e);
            }
        }
        
        protected abstract TDocument ParseDocument(XDocument document);
    }
}