using Core.CrossCuttingConserns.Exceptions.Types;

namespace Core.CrossCuttingConserns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException=> HandleException(validationException),
            _ => HandleException(exception)
        };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(Exception businessException);
    protected abstract Task HandleException(ValidationException validationException);
}
