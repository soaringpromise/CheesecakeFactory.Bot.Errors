namespace CheesecakeFactory.Bot.Errors.Handling;

public enum ErrorCategory
{
    Validation,
    Conflict,
    NotFound,
    Permission,
    ExternalService,
    Canceled,
    Unexpected
}