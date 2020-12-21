using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Homework.Abstractions.Storages
{
    public interface IStorageWriter
    {
        Task WriteStreamAsync(Stream stream, CancellationToken token = default);
    }
}