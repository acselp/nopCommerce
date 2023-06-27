using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.ScheduleTasks;
using Nop.Core.Domain.TireDeals;
using Nop.Services.ScheduleTasks;
using Nop.Services.TireDeals;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Mappers;
using Nop.Web.Areas.Admin.Models.TireDeals;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Web.Areas.Admin.Controllers;

[Area(AreaNames.Admin)] //specifies the area containing a controller or action
public class TireDealsController : BaseController
{
    private readonly ITireDealService _tireDealService;
    private readonly ITireDealModelFactory _tireDealModelFactory;
    private readonly ITireDealMapper _tireDealMapper;
    private readonly IScheduleTaskService _scheduleTaskService;

    public TireDealsController(ITireDealService tireDealService, ITireDealModelFactory tireDealModelFactory, ITireDealMapper tireDealMapper, IScheduleTaskService scheduleTaskService)
    {
        _tireDealService = tireDealService;
        _tireDealModelFactory = tireDealModelFactory;
        _tireDealMapper = tireDealMapper;
        _scheduleTaskService = scheduleTaskService;
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
    
        return Json(_tireDealMapper.ToModel(entity));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _tireDealService.GetByIdAsync(id);

        var model = _tireDealMapper.ToModel(entity);
            
        model = await _tireDealModelFactory.PrepareTireDealEditModel(model);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TireDealUpdateModel model)
    {
        var entity = _tireDealMapper.ToEntity(model);
        
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
        var entity = _tireDealMapper.ToEntity(model);
        
        await _tireDealService.InsertAsync(entity);

        return RedirectToAction("List");
    }
}