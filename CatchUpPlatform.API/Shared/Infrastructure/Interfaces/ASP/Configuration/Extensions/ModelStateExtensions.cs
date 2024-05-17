using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/**
 * <summary>
 * Extension method to get error messages from a model state dictionary.
 * </summary>
 */
public static class ModelStateExtensions
{
    /**
     * <summary>
     * Get error messages from a model state dictionary.
     * </summary>
     * <param name="dictionary">The model state dictionary.</param>
     * <returns>The error messages.</returns>
     */
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}