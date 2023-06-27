using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.TireDeals;

public record TireDealModel : BaseNopEntityModel
{
    public TireDealModel()
    {
        AvailableDiscounts = new List<SelectListItem>();
    }
    
    public int Id { get; set; }

    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.Title")]
    public string Title { get; set; }
    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.LongDescription")]
    public string LongDescription { get; set; }
    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.ShortDescription")]
    public string ShortDescription { get; set; }
    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.IsActive")]
    public bool IsActive { get; set; }
    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.Discount")]
    public int DiscountId { get; set; }
    public string DiscountName { get; set; }
    public IList<SelectListItem> AvailableDiscounts { get; set; }
    public int ActiveStoreScopeConfiguration { get; set; }
    [NopResourceDisplayName("Admin.Promotions.TireDeals.Common.Picture")]
    [UIHint("Picture")]
    public int BackgroundPictureId { get; set; }
    public string BackgroundPictureUrl { get; set; }
    public bool BackgroundPictureId_OverrideForStore { get; set; }
    
}