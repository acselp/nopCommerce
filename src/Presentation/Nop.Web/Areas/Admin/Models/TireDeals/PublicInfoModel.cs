using Nop.Core.Domain.Discounts;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.TireDeals;

public record PublicInfoModel : BaseNopModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string LongDescription { get; set; }
    public bool IsActive { get; set; }
    public string ShortDescription { get; set; }
    public string BackgroundPictureUrl { get; set; }
    public string BrandPictureUrl { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}