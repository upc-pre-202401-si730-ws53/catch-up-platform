using CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CatchUpPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/**
 * <summary>
 * This class represents a kebab case route naming convention.
 * </summary>
 * <remarks>
 * This class implements the IControllerModelConvention interface.
 * </remarks>
 */
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /**
     * <summary>
     * This method replaces the controller template.
     * </summary>
     * <param name="selector">The selector model.</param>
     * <param name="name">The name of the controller.</param>
     * <returns>The attribute route model.</returns>
     */
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null ? new AttributeRouteModel
        {
            Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
        } : null;
    }
    
    /**
     * <summary>
     * This method applies the kebab case route naming convention.
     * </summary>
     * <param name="controller">The controller model.</param>
     */
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }
}