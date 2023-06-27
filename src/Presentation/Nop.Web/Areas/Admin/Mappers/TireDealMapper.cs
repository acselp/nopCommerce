using Nop.Core.Domain.TireDeals;
using Nop.Web.Areas.Admin.Models.TireDeals;

namespace Nop.Web.Areas.Admin.Mappers;

public class TireDealMapper : ITireDealMapper
{
    public TireDealModel ToModel(TireDeal entity)
    {
        var model = new TireDealModel();

        model.Title = entity.Title;
        model.IsActive = entity.IsActive;
        model.LongDescription = entity.LongDescription;
        model.ShortDescription = entity.ShortDescription;
        model.BackgroundPictureId = entity.BackgroundPictureId;

        return model;
    }

    public IList<TireDealModel> ToModel(IList<TireDeal> entities)
    {
        var dealModels = new List<TireDealModel>();

        foreach (var entity in entities)
        {
            dealModels.Add(new TireDealModel()
            {
                Title = entity.Title,
                IsActive = entity.IsActive,
                LongDescription = entity.LongDescription,
                ShortDescription = entity.ShortDescription,
                BackgroundPictureId = entity.BackgroundPictureId
            });
        }

        return dealModels;
    }

    public TireDeal ToEntity(TireDealModel model)
    {
        var entity = new TireDeal();
        
        entity.Title = model.Title;
        entity.IsActive = model.IsActive;
        entity.LongDescription = model.LongDescription;
        entity.ShortDescription = model.ShortDescription;
        entity.BackgroundPictureId = model.BackgroundPictureId;

        return entity;
    }

    public TireDeal ToEntity(TireDealUpdateModel model)
    {
        var entity = new TireDeal();

        entity.Title = model.Title;
        entity.IsActive = model.IsActive;
        entity.LongDescription = model.LongDescription;
        entity.ShortDescription = model.ShortDescription;
        entity.BackgroundPictureId = model.BackgroundPictureId;

        return entity;
    }

    public TireDeal ToEntity(TireDealCreateModel model)
    {
        var entity = new TireDeal();

        entity.Title = model.Title;
        entity.IsActive = model.IsActive;
        entity.LongDescription = model.LongDescription;
        entity.ShortDescription = model.ShortDescription;
        entity.BackgroundPictureId = model.BackgroundPictureId;
        entity.DiscountId = model.DiscountId;

        return entity;
    }
}