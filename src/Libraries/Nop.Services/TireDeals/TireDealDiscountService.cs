using Nop.Core.Domain.TireDeals;
using Nop.Data;

namespace Nop.Services.TireDeals;

public class TireDealDiscountService : ITireDealDiscountService
{
    private readonly IRepository<TireDealDiscount> _tireDealDiscountRepository;

    public TireDealDiscountService(IRepository<TireDealDiscount> tireDealDiscountRepository)
    {
        _tireDealDiscountRepository = tireDealDiscountRepository;
    }

    public async Task<IList<TireDealDiscount>> GetAllAsync()
    {
        return await _tireDealDiscountRepository.GetAllAsync(query => query);
    }

    public async Task<TireDealDiscount> GetByIdAsync(int id)
    {
        return await _tireDealDiscountRepository.GetByIdAsync(id);
    }

    public async Task InsertAsync(TireDealDiscount entity)
    {
        await _tireDealDiscountRepository.InsertAsync(entity);
    }
}