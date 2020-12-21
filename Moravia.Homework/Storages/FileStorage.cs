using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Moravia.Homework.Abstractions.Storages;

namespace Moravia.Homework.Storages
{
    public class FileStorage
        : IStorageReader, IStorageWriter
    {
        private string FileName { get; }

        public FileStorage(string fileName)
        {
            FileName = fileName;
        }
        
        public Task<Stream> ReadStreamAsync(CancellationToken token = default)
        {
            var stream = File.Open(FileName, FileMode.Open, FileAccess.Read);
            return Task.FromResult((Stream) stream);
        }

        public async Task WriteStreamAsync(Stream stream, CancellationToken token = default)
        {
            await using var fileStream = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            await stream.CopyToAsync(fileStream, token);
        }

    }
}