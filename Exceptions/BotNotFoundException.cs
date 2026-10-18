namespace CheesecakeFactory.Bot.Errors.Exceptions;

public sealed class BotNotFoundException(string message,
    string? resource = null,
    Exception? innerException = null,
    string? userMessage = null)
    : BotException(
        message,
        innerException,
        userMessage ?? "The requested resource could not be found.")
{
    public string? Resource { get; } = resource;
}