namespace Backend.Application.Shared;

public record Error(string Id, ErrorType Type, string Message, IEnumerable<string>? Details = default)
{
    public static Error NotFound(string message) => new(Guid.NewGuid().ToString(), ErrorType.NotFound, message);
    public static Error Validation(IEnumerable<string>? details) => new("ValidationFailed", ErrorType.Validation, "Errores de validación.", details);
    public static Error Conflict(string message) => new(Guid.NewGuid().ToString(), ErrorType.Conflict, message);
    public static Error Unauthorized(string message) => new(Guid.NewGuid().ToString(), ErrorType.Unauthorized, message);
    public static Error Forbidden(string message) => new(Guid.NewGuid().ToString(), ErrorType.Forbidden, message);
    public static Error Unexpected(string message) => new(Guid.NewGuid().ToString(), ErrorType.Unexpected, message);
}
