namespace CheesecakeFactory.Bot.Errors.Exceptions;

public sealed class BotInvalidInputException(
    object? input,
    string message,
    Exception? innerException = null,
    string? userMessage = null)
    : BotValidationException(
        $"{message} Invalid input: '{input ?? "—"}'",
        innerException,
        userMessage ?? "The provided input is invalid.")
{
    public object? Input { get; } = input;
}