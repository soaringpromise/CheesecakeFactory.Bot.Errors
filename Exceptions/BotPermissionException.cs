namespace CheesecakeFactory.Bot.Errors.Exceptions;

public sealed class BotPermissionException(
    string message,
    Exception? innerException = null,
    string? userMessage = null)
    : BotException(
        message,
        innerException,
        userMessage ?? "You do not have permission to perform this action.");