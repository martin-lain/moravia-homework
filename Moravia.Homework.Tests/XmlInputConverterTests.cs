using System.IO;
using System.Text;
using Moravia.Homework.InputConverters.Impl;
using NUnit.Framework;

namespace Moravia.Homework.Tests
{
    public class XmlInputConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRead()
        {
            var converter = new XmlFormatInputConverter();
            const string input = @"<?xml version=""1.0"" ?><document><title>Title</title><text>Text</text></document>";
            using var ms = new MemoryStream(Encoding.Default.GetBytes(input));
            var document = converter.ReadAsync(ms).Result;
            
            Assert.AreEqual("Title", document.Title);
            Assert.AreEqual("Text", document.Text);
        }
    }
}