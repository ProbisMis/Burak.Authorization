using FluentMigrator;
using Burak.Authorization.Data.EntityModels;

namespace Burak.Authorization.Data.Migrations
{
    [Migration(3)]
    public partial class _00003_AlterTableUser : Migration
    {
        public override void Up()
        {
            Alter.Table(nameof(User))
                .AlterColumn("FacebookGameId").AsString().Nullable()
                .AlterColumn("AndroidGameId").AsString().Nullable();
        }

        public override void Down()
        {
               
        }
    }
}
