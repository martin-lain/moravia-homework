using System;

namespace Moravia.Homework.Abstractions.Document
{
    public interface IDocumentProvider
    {
        public Type DocumentType { get; }
    }
}