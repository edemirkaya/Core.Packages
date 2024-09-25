using Core.CrossCuttingConserns.Exceptions.Types;
using FluentValidation;
using MediatR;
using ValidationException = Core.CrossCuttingConserns.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);
        IEnumerable<ValidationExceptionModel> errors = _validators.Select(s => s.Validate(context))
            .SelectMany(sm => sm.Errors)
            .Where(q => q != null)
            .GroupBy(
            keySelector: g => g.PropertyName,
            resultSelector: (propertyName, errors) => new ValidationExceptionModel
            {
                Property = propertyName,
                Errors = errors.Select(s => s.ErrorMessage)
            }).ToList();

        if (errors.Any())
            throw new ValidationException(errors);

        TResponse response = await next();
        return response;

    }
}
