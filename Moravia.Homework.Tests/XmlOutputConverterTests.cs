using Moravia.Homework.InputConverters.Impl;
using Moravia.Homework.Model;
using Moravia.Homework.OutputConverters.Impl;
using NUnit.Framework;

namespace Moravia.Homework.Tests
{
    public class XmlOutputConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWrite()
        {
            var converter = new XmlFormatOutputConverter();

            var document = new Document
            {
                Text = "Text",
                Title = "Title"
            };

            var stream = converter.WriteAsync(document).Result;
            
            var reverseConverter = new XmlFormatInputConverter();
            var testDoc = reverseConverter.ReadAsync(stream).Result;
            
            Assert.AreEqual(document.Title, testDoc.Title);
            Assert.AreEqual(document.Text, testDoc.Text);
        }
    }
}