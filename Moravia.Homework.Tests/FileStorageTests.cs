using System.IO;
using System.Text;
using Moravia.Homework.Storages;
using NUnit.Framework;

namespace Moravia.Homework.Tests
{
    public class FileStorageTests
    {
        [Test]
        public void TestRead()
        {
            const string content = @"test-content";
            
            Directory.CreateDirectory("test-data");
            File.Delete("./test-data/test-file");
            File.WriteAllText("./test-data/test-file", content);
            
            var fileStorage = new FileStorage("./test-data/test-write-file");
            var stream = fileStorage.ReadStreamAsync().Result;
            
            using var sr = new StreamReader(stream);
            var readContent = sr.ReadToEnd();
            
            Assert.AreEqual(content, readContent);
        }

        [Test]
        public void TestWrite()
        {
            const string content = @"test-content";
            
            Directory.CreateDirectory("test-data");
            File.Delete("./test-data/test-write-file");

            using var ms = new MemoryStream(Encoding.Default.GetBytes(content));

            var fileStorage = new FileStorage("./test-data/test-write-file");
            fileStorage.WriteStreamAsync(ms).Wait();
            
            var writtenContent = File.ReadAllText("./test-data/test-file");
            Assert.AreEqual(content, writtenContent);
        }
    }
}