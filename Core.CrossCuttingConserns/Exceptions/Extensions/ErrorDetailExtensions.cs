using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Core.CrossCuttingConserns.Exceptions.Extensions;

public static class ErrorDetailExtensions
{
    public static string AsJson<TErrorDetail>(this TErrorDetail details)
        where TErrorDetail : ProblemDetails => JsonSerializer.Serialize(details);
}
