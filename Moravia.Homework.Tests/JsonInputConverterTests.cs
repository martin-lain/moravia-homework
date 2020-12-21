using System.IO;
using System.Text;
using Moravia.Homework.InputConverters.Impl;
using NUnit.Framework;

namespace Moravia.Homework.Tests
{
    public class JsonInputConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRead()
        {
            var converter = new JsonFormatInputConverter();
            const string input = @"{ Title: ""Title"", Text: ""Text"" }";
            using var ms = new MemoryStream(Encoding.Default.GetBytes(input));
            var document = converter.ReadAsync(ms).Result;
            
            Assert.AreEqual("Title", document.Title);
            Assert.AreEqual("Text", document.Text);
        }
    }
}