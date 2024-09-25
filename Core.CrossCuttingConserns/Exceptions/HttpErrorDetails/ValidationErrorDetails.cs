using Core.CrossCuttingConserns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConserns.Exceptions.HttpErrorDetails;

public class ValidationErrorDetails : ProblemDetails
{


    public IEnumerable<ValidationExceptionModel> Errors { get; init; }
    public ValidationErrorDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or modre validation errors occurred.";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/errors/business";
    }

}
