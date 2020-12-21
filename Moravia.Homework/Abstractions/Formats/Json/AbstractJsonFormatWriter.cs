using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moravia.Homework.Abstractions.Formats.Json
{
    /// <summary>
    /// Abstract JSON serializer
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public abstract class AbstractJsonFormatWriter<TDocument>
        : IFormatWriter<TDocument>
    {
        public async Task<Stream> WriteAsync(TDocument document, CancellationToken token = default)
        {
            try
            {
                var stream = new MemoryStream();
                var streamWriter = new StreamWriter(stream);

                await streamWriter.WriteAsync(JsonConvert.SerializeObject(document));
                await streamWriter.FlushAsync();

                stream.Position = 0;
                return stream;
            }
            catch (Exception e)
            {
                throw new Exception("Target conversion error", e);
            }
        }
    }
}