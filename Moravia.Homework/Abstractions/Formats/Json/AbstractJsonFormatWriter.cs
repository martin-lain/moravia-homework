using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moravia.Homework.Abstractions.Formats.Json
{
    public abstract class AbstractJsonFormatWriter<TDocument>
        : IFormatWriter<TDocument>
    {
        public async Task<Stream> WriteAsync(TDocument document, CancellationToken token = default)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            
            await streamWriter.WriteAsync(JsonConvert.SerializeObject(document));
            await streamWriter.FlushAsync();

            stream.Position = 0;
            return stream;
        }
    }
}