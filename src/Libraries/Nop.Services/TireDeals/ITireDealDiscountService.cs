using System.Collections;
using Nop.Core.Domain.TireDeals;

namespace Nop.Services.TireDeals;

public interface ITireDealDiscountService
{
    Task<IList<TireDealDiscount>> GetAllAsync();
    Task<TireDealDiscount> GetByIdAsync(int id);
    Task InsertAsync(TireDealDiscount model);
}