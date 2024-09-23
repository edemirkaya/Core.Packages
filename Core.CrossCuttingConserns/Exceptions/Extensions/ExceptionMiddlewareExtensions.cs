using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConserns.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();
}
