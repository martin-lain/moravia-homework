namespace Moravia.Homework.OutputConverters
{
    /// <summary>
    /// Writing converter marker interface
    /// </summary>
    public interface IOutputConverter
    {
        OutputTypes OutputType { get; }
    }
}