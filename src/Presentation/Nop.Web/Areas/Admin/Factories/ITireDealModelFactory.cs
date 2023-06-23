using Nop.Web.Areas.Admin.Models.TireDeals;

namespace Nop.Web.Areas.Admin.Factories;

public interface ITireDealModelFactory
{
    Task<TireDealListModel> PrepareTireDealListModelAsync(TireDealSearchModel searchModel);
    Task<IList<TireDealModel>> PrepareTireDealListModelAsync();
    Task<IList<PublicInfoModel>> PrepareTireDealPublicModelAsync();
    TireDealSearchModel PrepareTireDealSearchModelAsync();
    Task<TireDealModel> PrepareTireDealCreateModel();
    Task<TireDealModel> PrepareTireDealEditModel(TireDealModel model);
}