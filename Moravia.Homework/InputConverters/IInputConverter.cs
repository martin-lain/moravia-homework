namespace Moravia.Homework.InputConverters
{
    /// <summary>
    /// Reading converter marker interface
    /// </summary>
    public interface IInputConverter
    {
        InputTypes InputType { get; }
    }
}