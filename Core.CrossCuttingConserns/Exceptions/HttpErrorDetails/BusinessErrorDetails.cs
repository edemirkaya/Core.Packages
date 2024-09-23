using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConserns.Exceptions.HttpErrorDetails;

public class BusinessErrorDetails:ProblemDetails
{
    public BusinessErrorDetails(string detail)
    {
        Title = "Rule violation.";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/errors/business";
    }
}
