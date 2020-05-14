using FluentMigrator;
using Burak.Authorization.Data.EntityModels;

namespace Burak.Authorization.Data.Migrations
{
    [Migration(2)]
    public partial class _00002_AlterTableUser : Migration
    {
        public override void Up()
        {
            Alter.Table(nameof(User))
                .AddColumn("Token").AsString().Nullable();
        }

        public override void Down()
        {
               
        }
    }
}
