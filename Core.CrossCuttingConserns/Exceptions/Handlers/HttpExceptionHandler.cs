using Core.CrossCuttingConserns.Exceptions.Extensions;
using Core.CrossCuttingConserns.Exceptions.HttpErrorDetails;
using Core.CrossCuttingConserns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConserns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }
    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessErrorDetails(businessException.Message).AsJson();

        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Exception businessException)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new BusinessErrorDetails(businessException.Message).AsJson();

        return Response.WriteAsync(details);
    }
}
