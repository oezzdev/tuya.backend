namespace Backend.Application.Shared;

public record MediatorOptions
{
    public System.Reflection.Assembly[]? Locations { get; set; }

    public static MediatorOptions Default => new();
}