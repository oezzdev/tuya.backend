namespace Backend.Application.Shared;

public interface IRequest { }

public interface IRequest<out TResponse> { }