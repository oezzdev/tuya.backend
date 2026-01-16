using System.Reflection;

namespace Backend.Application.Shared;

public record MediatorOptions
{
    public Assembly[]? Locations { get; set; }

    public static MediatorOptions Default => new();
}