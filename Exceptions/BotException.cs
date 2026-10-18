namespace CheesecakeFactory.Bot.Errors.Exceptions;

public abstract class BotException(string message, Exception? innerException = null, string? userMessage = null)
    : Exception(message, innerException)
{
    public string UserMessage { get; } = userMessage ?? "An error occurred.";
}