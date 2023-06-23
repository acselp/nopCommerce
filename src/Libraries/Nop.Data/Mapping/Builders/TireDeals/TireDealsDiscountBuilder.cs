using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.TireDeals;

namespace Nop.Data.Mapping.Builders.TireDeals;

public class TireDealsDiscountBuilder : NopEntityBuilder<TireDealDiscount>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(TireDealDiscount.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(TireDealDiscount.TireDealId)).AsInt32()
            .WithColumn(nameof(TireDealDiscount.DiscountId)).AsInt32();
    }
}
