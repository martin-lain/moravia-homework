using System;
using System.Threading;
using System.Threading.Tasks;
using Moravia.Homework.InputConverters.Impl;
using Moravia.Homework.OutputConverters.Impl;
using Moravia.Homework.Storages;

namespace Moravia.Homework
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("homework input.xml output.json");
            }
            
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var sourceFileName = args[0];
            var targetFileName = args[1];
            
            var sourceStorage = new FileStorage(sourceFileName);
            var inputStream = await sourceStorage.ReadStreamAsync(token);
            
            var inputConverter = new XmlFormatInputConverter();
            var document = await inputConverter.ReadAsync(inputStream, token);

            var outputConverter = new JsonFormatOutputConverter();
            var outputStream  = await outputConverter.WriteAsync(document, token);

            var destinationStorage = new FileStorage(targetFileName);
            await destinationStorage.WriteStreamAsync(outputStream, token);
        }
    }
    
    #region --- Old implementation ---
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                string input = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc);
        }
    }
    */
    #endregion
}