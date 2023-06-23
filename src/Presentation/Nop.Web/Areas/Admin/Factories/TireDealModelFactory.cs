using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Data.Extensions;
using Nop.Services.Discounts;
using Nop.Services.Media;
using Nop.Services.TireDeals;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Mappers;
using Nop.Web.Areas.Admin.Models.TireDeals;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public class TireDealModelFactory : ITireDealModelFactory
{
    private readonly ITireDealService _tireDealService;
    private readonly IPictureService _pictureService;
    private readonly ITireDealMapper _tireDealMapper;
    private readonly IDiscountService _discountService;
    
    public TireDealModelFactory(ITireDealService tireDealService, IPictureService pictureService, ITireDealMapper tireDealMapper, IDiscountService discountService)
    {
        _tireDealService = tireDealService;
        _pictureService = pictureService;
        _tireDealMapper = tireDealMapper;
        _discountService = discountService;
    }

    public virtual async Task<TireDealListModel> PrepareTireDealListModelAsync(TireDealSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        //get deals
        var deals = await _tireDealService.GetAllAsync(
            title: searchModel.SearchTireDealTitle, 
            isActive: searchModel.SearchTireDealIsActive,
            id: searchModel.SearchTireDealId);

        var pagedDeals = deals.ToPagedList(searchModel);

        //prepare grid model
        var model = await new TireDealListModel().PrepareToGridAsync(searchModel, pagedDeals, () =>
        {
            return pagedDeals.SelectAwait(async deal =>
            {
                //fill in model values from the entity
                var dealModel = deal.ToModel<TireDealModel>();
                
                dealModel.BackgroundPictureUrl = await _pictureService.GetPictureUrlAsync(dealModel.BackgroundPictureId);
                dealModel.DiscountName = (await _discountService.GetDiscountByIdAsync(dealModel.DiscountId)).Name;
                
                return dealModel;
            });
        });

        return model;
    }

    public async Task<IList<TireDealModel>> PrepareTireDealListModelAsync()
    {
        var deals = await _tireDealService.GetAllAsync();

        var dealModels = _tireDealMapper.ToModel(deals);
        
        return dealModels;
    }

    public async Task<IList<PublicInfoModel>> PrepareTireDealPublicModelAsync()
    {
        var entities = await _tireDealService.GetAllActiveAsync();
        List<PublicInfoModel> models = new();

        foreach (var item in entities)
        {
            models.Add(new PublicInfoModel()
            {
                Id = item.Id,
                Title = item.Title,
                ShortDescription = item.ShortDescription,
                LongDescription = item.LongDescription,
                BackgroundPictureUrl = await _pictureService.GetPictureUrlAsync(item.BackgroundPictureId),
                BrandPictureUrl = await _pictureService.GetPictureUrlAsync(item.BrandPictureId),
                IsActive = item.IsActive
            });
        }

        return models;
    }

    public TireDealSearchModel PrepareTireDealSearchModelAsync()
    {
        var searchModel = new TireDealSearchModel() { AvailablePageSizes = "5, 10, 50, 100"};
        
        searchModel.AvailableActiveOptions.Add(new SelectListItem { Value = "null", Text = "All" });
        searchModel.AvailableActiveOptions.Add(new SelectListItem { Value = "true", Text = "Active" });
        searchModel.AvailableActiveOptions.Add(new SelectListItem { Value = "false", Text = "Inactive" });

        return searchModel;
    }

    public async Task<TireDealModel> PrepareTireDealCreateModel()
    {
        var model = new TireDealModel();

        var discounts = await _discountService.GetAllDiscountsAsync();

        foreach (var item in discounts)
            model.AvailableDiscounts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name});

        return model;
    }

    public async Task<TireDealModel> PrepareTireDealEditModel(TireDealModel model)
    {
        var discounts = await _discountService.GetAllDiscountsAsync();

        foreach (var item in discounts)
            model.AvailableDiscounts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });

        return model;
    }
}