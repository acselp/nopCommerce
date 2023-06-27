using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components;

public class TireDealViewComponent : NopViewComponent
{
    private readonly ITireDealModelFactory _tireDealModelFactory;

    public TireDealViewComponent(ITireDealModelFactory tireDealModelFactory)
    {
        _tireDealModelFactory = tireDealModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        var models = await _tireDealModelFactory.PrepareTireDealPublicModelAsync();
        
        return View(models);
    }
}