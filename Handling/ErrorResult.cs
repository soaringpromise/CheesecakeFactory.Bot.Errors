using Microsoft.Extensions.Logging;

namespace CheesecakeFactory.Bot.Errors.Handling;

public sealed record ErrorResult(ErrorCategory Category, string Message, LogLevel LogLevel);