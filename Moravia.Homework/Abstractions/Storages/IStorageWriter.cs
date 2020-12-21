using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Storages
{
    /// <summary>
    /// Writing into storage interface
    /// </summary>
    public interface IStorageWriter
    {
        Task WriteStreamAsync(Stream stream, CancellationToken token = default);
    }
}