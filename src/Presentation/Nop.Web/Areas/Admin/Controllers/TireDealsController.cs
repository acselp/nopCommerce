using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.TireDeals;
using Nop.Services.TireDeals;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.TireDeals;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Web.Areas.Admin.Controllers;

[Area(AreaNames.Admin)] //specifies the area containing a controller or action
public class TireDealsController : BaseController
{
    private readonly ITireDealService _tireDealService;
    private readonly ITireDealModelFactory _tireDealModelFactory;

    public TireDealsController(ITireDealService tireDealService, ITireDealModelFactory tireDealModelFactory)
    {
        _tireDealService = tireDealService;
        _tireDealModelFactory = tireDealModelFactory;
    }

    public async Task<IActionResult> List()
    {
        var model = _tireDealModelFactory.PrepareTireDealSearchModelAsync();

        return View(model);
    }
    
    [HttpPost]
    public virtual async Task<IActionResult> GetTireDeals(TireDealSearchModel searchModel)
    {
        //prepare model
        var model = await _tireDealModelFactory.PrepareTireDealListModelAsync(searchModel);

        return Json(model);
    }
    
    public virtual async Task<IActionResult> GetTireDeals()
    {
        //prepare model
        var model = await _tireDealModelFactory.PrepareTireDealPublicModelAsync();

        return Json(model);
    }

    public async Task<IActionResult> GetTireDealById(int id)
    {
        var entity = await _tireDealService.GetByIdAsync(id);

        var model = new TireDealModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            BackgroundPictureId = entity.BackgroundPictureId,
            IsActive = entity.IsActive
        };
        
        return Json(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _tireDealService.GetByIdAsync(id);

        var model = new TireDealModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            BackgroundPictureId = entity.BackgroundPictureId,
            IsActive = entity.IsActive,
            DiscountId = entity.DiscountId
        };
        
        model = await _tireDealModelFactory.PrepareTireDealEditModel(model);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TireDealUpdateModel model)
    {
        var entity = new TireDeal()
        {
            Id = model.Id,
            Title = model.Title,
            ShortDescription = model.ShortDescription,
            LongDescription = model.LongDescription,
            BackgroundPictureId = model.BackgroundPictureId,
            BrandPictureId = model.BrandPictureId,
            IsActive = model.IsActive,
            DiscountId = model.DiscountId
        };
        
        await _tireDealService.UpdateAsync(entity);

        return RedirectToAction("List");
    }

    public async Task<IActionResult> Create()
    {
        var model = await _tireDealModelFactory.PrepareTireDealCreateModel();
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(TireDealCreateModel model)
    {
        var entity = new TireDeal()
        {
            Id = model.Id,
            Title = model.Title,
            ShortDescription = model.ShortDescription,
            LongDescription = model.LongDescription,
            BackgroundPictureId = model.BackgroundPictureId,
            BrandPictureId = model.BrandPictureId,
            IsActive = model.IsActive,
            DiscountId = model.DiscountId
        };
        
        await _tireDealService.InsertAsync(entity);

        return RedirectToAction("List");
    }
}