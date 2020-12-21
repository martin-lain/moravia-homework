using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Storages
{
    /// <summary>
    /// Reading from storage interface
    /// </summary>
    public interface IStorageReader
    {
        Task<Stream> ReadStreamAsync(CancellationToken token = default);
    }
}