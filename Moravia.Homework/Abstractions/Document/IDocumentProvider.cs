using System;

namespace Moravia.Homework.Abstractions.Document
{
    /// <summary>
    /// Document marker interface
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IDocumentProvider<TDocument>
    {
        public Type DocumentType => typeof(TDocument);
    }
}