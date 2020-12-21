using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Moravia.Homework.Abstractions.Storages;

namespace Moravia.Homework.Storages
{
    /// <summary>
    /// Implementation of file system r/w storage
    /// </summary>
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
            try
            {
                var stream = File.Open(FileName, FileMode.Open, FileAccess.Read);
                return Task.FromResult((Stream) stream);
            }
            catch (Exception e)
            {
                throw new Exception("File read error", e);
            }
        }

        public async Task WriteStreamAsync(Stream stream, CancellationToken token = default)
        {
            try
            {
                await using var fileStream = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                await stream.CopyToAsync(fileStream, token);
                await stream.DisposeAsync();
            }
            catch (Exception e)
            {
                throw new Exception("File write error", e);
            }
        }
    }
}