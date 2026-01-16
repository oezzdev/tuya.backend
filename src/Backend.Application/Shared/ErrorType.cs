using System.Text.Json.Serialization;

namespace Backend.Application.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ErrorType
{
    NotFound,
    Validation,
    Conflict,
    Unauthorized,
    Forbidden,
    Unexpected
}
