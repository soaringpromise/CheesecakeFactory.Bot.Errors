namespace CheesecakeFactory.Bot.Errors.Exceptions;

public class BotValidationException(string message, Exception? innerException = null, string? userMessage = null)
    : BotException(message, innerException, userMessage ?? "The provided data is invalid.");