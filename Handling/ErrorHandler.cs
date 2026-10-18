using System.Runtime.CompilerServices;
using CheesecakeFactory.Bot.Errors.Exceptions;
using Microsoft.Extensions.Logging;

namespace CheesecakeFactory.Bot.Errors.Handling;

public sealed class ErrorHandler(ILogger<ErrorHandler> logger)
{
    public ErrorResult Handle(Exception exception, string? unexpectedMessage = null, 
        CancellationToken cancellationToken = default, [CallerMemberName] string operation = "")
    {
        ArgumentNullException.ThrowIfNull(exception);

        var result = exception switch
        {
            BotInvalidInputException ex => new ErrorResult(
                ErrorCategory.Validation,
                ex.UserMessage,
                LogLevel.Information),

            BotValidationException ex => new ErrorResult(
                ErrorCategory.Validation,
                ex.UserMessage,
                LogLevel.Information),

            BotConflictException ex => new ErrorResult(
                ErrorCategory.Conflict,
                ex.UserMessage,
                LogLevel.Information),

            BotNotFoundException ex => new ErrorResult(
                ErrorCategory.NotFound,
                ex.UserMessage,
                LogLevel.Information),

            BotPermissionException ex => new ErrorResult(
                ErrorCategory.Permission,
                ex.UserMessage,
                LogLevel.Warning),

            BotExternalServiceException ex => new ErrorResult(
                ErrorCategory.ExternalService,
                ex.UserMessage,
                LogLevel.Error),

            HttpRequestException => new ErrorResult(
                ErrorCategory.ExternalService,
                "An external HTTP request failed.",
                LogLevel.Error),

            OperationCanceledException
                when cancellationToken.IsCancellationRequested => new ErrorResult(
                    ErrorCategory.Canceled,
                    "The operation was canceled.",
                    LogLevel.Information),

            _ => new ErrorResult(
                ErrorCategory.Unexpected,
                string.IsNullOrWhiteSpace(unexpectedMessage)
                    ? "An unexpected error occurred."
                    : unexpectedMessage,
                LogLevel.Error)
        };

        LogException(exception, result, operation);
        return result;
    }

    private void LogException(Exception exception, ErrorResult result, string operation)
    {
        switch (result.Category)
        {
            case ErrorCategory.Canceled:
                logger.LogInformation(
                    "Operation {Operation} was canceled.",
                    operation);
                break;

            case ErrorCategory.Validation or
                 ErrorCategory.Conflict or
                 ErrorCategory.NotFound or
                 ErrorCategory.Permission:

                logger.Log(
                    result.LogLevel,
                    "Operation {Operation} rejected: {ExceptionType} ({Category}).",
                    operation,
                    exception.GetType().FullName,
                    result.Category);
                break;

            default:
                logger.Log(
                    result.LogLevel,
                    exception,
                    "Operation {Operation} failed: {ExceptionType} ({Category}).",
                    operation,
                    exception.GetType().FullName,
                    result.Category);
                break;
        }
    }
}