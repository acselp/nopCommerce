using Nop.Core.Domain.TireDeals;
using Nop.Web.Areas.Admin.Models.TireDeals;

namespace Nop.Web.Areas.Admin.Mappers;

public interface ITireDealMapper
{
    TireDealModel ToModel(TireDeal entity);
    IList<TireDealModel> ToModel(IList<TireDeal> entity);
    TireDeal ToEntity(TireDealModel entity);
}