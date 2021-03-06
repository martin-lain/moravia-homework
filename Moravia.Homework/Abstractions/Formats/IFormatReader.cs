using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Formats
{
    /// <summary>
    /// General document deserialization interface
    /// </summary>
    /// <typeparam name="TDocument">General document type</typeparam>
    public interface IFormatReader<TDocument>
    {
        Task<TDocument> ReadAsync(Stream inputStream, CancellationToken token = default);
    }
}