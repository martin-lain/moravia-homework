using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Storages
{
    public interface IStorageReader
    {
        Task<Stream> ReadStreamAsync(CancellationToken token = default);
    }
}