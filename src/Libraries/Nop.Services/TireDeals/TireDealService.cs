﻿using Nop.Core.Domain.TireDeals;
using Nop.Data;
using Nop.Services.Media;

namespace Nop.Services.TireDeals;

public class TireDealService : ITireDealService
{
    private readonly IRepository<TireDeal> _dealRepository;
    private readonly IPictureService _pictureService;

    public TireDealService(IRepository<TireDeal> dealRepository, IPictureService pictureService)
    {
        _dealRepository = dealRepository;
        _pictureService = pictureService;
    }

    public async Task<IList<TireDeal>> GetAllAsync()
    {
        var models = await _dealRepository.GetAllAsync(deals => deals);

        return models;
    }

    public async Task<IList<TireDeal>> GetAllActiveAsync()
    {
        var models = await _dealRepository.GetAllAsync(deals => deals.Where(deal => deal.IsActive == true));

        return models;
    }

    public async Task<IList<TireDeal>> GetAllAsync(string title, string isActive, string id)
    {
        IList<TireDeal> deals;

        deals = await _dealRepository.GetAllAsync(query =>
        {
            if (title != null)
                query = query.Where(deal => deal.Title.Contains(title));

            if (isActive != "null")
            {
                bool active = isActive == "true";

                query = query.Where(deal => deal.IsActive == active);
            }

            if (id != null)
            {
                int intId;
                var isNumeric = int.TryParse(id, out intId);
                
                if(isNumeric)
                    query = query.Where(deal => deal.Id == intId);
            }

            return query.OrderBy(deal => deal.Id);
        });
        
        return deals;
    }

    public async Task<TireDeal> GetByIdAsync(int id)
    {
        return await _dealRepository.GetByIdAsync(id);
    }

    public async Task InsertAsync(TireDeal model)
    {
        await _dealRepository.InsertAsync(model, false);
    }

    public async Task UpdateAsync(TireDeal model)
    {
        var entity = await _dealRepository.GetByIdAsync(model.Id);

        entity.Title = model.Title;
        entity.IsActive = model.IsActive;
        entity.LongDescription = model.LongDescription;
        entity.ShortDescription = model.ShortDescription;
        entity.BackgroundPictureId = model.BackgroundPictureId;
        entity.BrandPictureId = model.BrandPictureId;
        entity.DiscountId = model.DiscountId;
        
        await _dealRepository.UpdateAsync(entity);
    }
}