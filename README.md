# CheesecakeFactory.Bot.Errors

A lightweight, reusable exception-handling library for .NET applications, developed for the CheesecakeFactory bot projects.

Provides a standardized exception hierarchy, centralized error classification, structured logging, and separation of diagnostic messages from user-facing messages.

## Features

- Reusable custom exception types
- Centralized exception handling through `ErrorHandler`
- Safe user-facing messages via `UserMessage`
- Integration with `Microsoft.Extensions.Logging`
- Framework-independent architecture with no Discord-specific dependencies
- Support for inner exceptions and additional diagnostic context

## Exception Types

| Exception | Purpose |
|---|---|
| `BotException` | Base class for custom exceptions |
| `BotValidationException` | General validation failures |
| `BotInvalidInputException` | Invalid input values |
| `BotConflictException` | Conflicts with existing state |
| `BotNotFoundException` | Missing resources |
| `BotPermissionException` | Authorization failures |
| `BotExternalServiceException` | External service failures |

## Usage

Create and throw a custom exception:

```csharp
throw new BotConflictException(
    message: $"Profile already exists for user {userId}.",
    userMessage: "You already have a profile.");
```

Handle exceptions consistently:

```csharp
catch (Exception ex)
{
    var result = errorHandler.Handle(ex);
    // Respond according to result.Category and result.Message.
}
```

## Installation

NuGet package: `CheesecakeFactory.Bot.Errors`

Target framework: .NET 10

Installation instructions will be added once the package is published.

## License

License information will be added before the first public release.