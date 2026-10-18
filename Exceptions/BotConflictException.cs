namespace CheesecakeFactory.Bot.Errors.Exceptions;

public sealed class BotConflictException(string message, Exception? innerException = null, string? userMessage = null)
    : BotException(message, innerException, userMessage ?? "The operation conflicts with the current state.");