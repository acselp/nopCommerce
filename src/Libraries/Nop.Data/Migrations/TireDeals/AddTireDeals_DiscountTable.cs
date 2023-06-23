using FluentMigrator;
using Nop.Core.Domain.TireDeals;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.TireDeals
{
    [NopSchemaMigration("2023/06/23 09:42:08:9037680", "Create tiredeal discount mapping table",
        MigrationProcessType.Installation)]
    public class AddTireDealsDiscountTable : MigrationBase
    {
        #region Methods

        public override void Up()
        {
            Create.TableFor<TireDealDiscount>();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}