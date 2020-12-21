using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moravia.Homework.Abstractions.Formats.Json
{
    public abstract class AbstractJsonFormatReader<TDocument>
        : IFormatReader<TDocument>
    {
        public async Task<TDocument> ReadAsync(Stream inputStream, CancellationToken token = default)
        {
            using var streamReader = new StreamReader(inputStream);

            return JsonConvert.DeserializeObject<TDocument>(await streamReader.ReadToEndAsync());
        }
    }
}