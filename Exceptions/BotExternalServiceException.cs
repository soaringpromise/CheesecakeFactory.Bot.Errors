namespace CheesecakeFactory.Bot.Errors.Exceptions;

public sealed class BotExternalServiceException(
    string serviceName,
    string message,
    Exception? innerException = null,
    string? userMessage = null)
    : BotException(
        message,
        innerException,
        userMessage ?? "An external service request failed.")
{
    public string ServiceName { get; } = serviceName;
}