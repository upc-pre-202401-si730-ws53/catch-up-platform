using System.Text.RegularExpressions;

namespace CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
/**
 * <summary>
 * This class contains extension methods for the string class.
 * </summary>
 */
public static partial class StringExtensions
{
    
    // This regex pattern is used to convert a string to kebab case.
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
    
    /**
     * <summary>
     * This method converts a string to kebab case.
     * </summary>
     * <param name="text">The text to convert to kebab case.</param>
     * <returns>The text converted to kebab case.</returns>
     */
    public static string ToKebabCase(this string text)
    {
        // If the text is null or empty, return the text. Otherwise, convert the text to kebab case.
        return string.IsNullOrEmpty(text) ? text : KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }
}