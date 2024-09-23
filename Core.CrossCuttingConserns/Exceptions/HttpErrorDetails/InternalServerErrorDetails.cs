using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConserns.Exceptions.HttpErrorDetails;

public class InternalServerErrorDetails : ProblemDetails
{
    public InternalServerErrorDetails(string detail)
    {
        Title = "Internal server error.";
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://example.com/errors/business";
    }
}
