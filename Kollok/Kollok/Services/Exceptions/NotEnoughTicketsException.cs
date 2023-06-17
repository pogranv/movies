namespace Kollok.Services.Exceptions;

[Serializable]
public class NotEnoughTicketsException : Exception
{
    public NotEnoughTicketsException() { }
    public NotEnoughTicketsException(string message) : base(message) { }
    public NotEnoughTicketsException(string message, Exception inner) : base(message, inner) { }
    protected NotEnoughTicketsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}