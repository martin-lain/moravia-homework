using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Formats
{
    public interface IFormatReader<TDocument>
    {
        Task<TDocument> ReadAsync(Stream inputStream, CancellationToken token = default);
    }
    
    public interface IFormatWriter<in TDocument>
    {
        Task<Stream> WriteAsync(TDocument document, CancellationToken token = default);
    }
}