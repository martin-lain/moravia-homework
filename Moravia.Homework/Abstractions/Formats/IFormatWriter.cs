using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Formats
{
    /// <summary>
    /// General document serialization interface
    /// </summary>
    /// <typeparam name="TDocument">General document type</typeparam>
    public interface IFormatWriter<in TDocument>
    {
        Task<Stream> WriteAsync(TDocument document, CancellationToken token = default);
    }
}