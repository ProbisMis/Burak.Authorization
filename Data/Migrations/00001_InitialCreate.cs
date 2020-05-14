using FluentMigrator;
using Burak.Authorization.Data.EntityModels;

namespace Burak.Authorization.Data.Migrations
{
    [Migration(1)]
    public partial class _00001_InitialCreate : Migration
    {
        public override void Up()
        {
            Create.Table(nameof(User))
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserGuid").AsGuid().Nullable()
                .WithColumn("UserCode").AsString().Nullable()
                .WithColumn("ParentCode").AsString().Nullable()
                .WithColumn("FacebookGameId").AsInt32().Nullable()
                .WithColumn("AndroidGameId").AsInt32().Nullable()
                //.WithColumn("TypeId").AsInt32().Nullable().ForeignKey(nameof(Type), "Id")
                .WithColumn("FirstName").AsString().Nullable()
                .WithColumn("LastName").AsString().Nullable()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Password").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("PhoneNumberCountryCode").AsString().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("CustomValues").AsString().Nullable()
                //.WithColumn("SlotId").AsInt32().Nullable().ForeignKey(nameof(Slot), "Id")
                //.WithColumn("StatusId").AsInt32().Nullable().ForeignKey(nameof(Status), "Id")
                .WithColumn("IsActive").AsBoolean().Nullable()
                .WithColumn("IsDeleted").AsBoolean().Nullable()
                .WithColumn("CreatedOnUtc").AsDateTime().Nullable()
                .WithColumn("UpdatedOnUtc").AsDateTime().Nullable();
          

            Create.Table(nameof(Setting))
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString().Nullable()
               .WithColumn("Value").AsString().Nullable()
               .WithColumn("StoreId").AsInt32().Nullable();

            //Seed 
            //Insert.IntoTable(nameof(Type)).Row(new { Name = "Home" });
            //Insert.IntoTable(nameof(Type)).Row(new { Name = "Store" });
            
            //Insert.IntoTable(nameof(Status)).Row(new { Name = "Pending" });
            //Insert.IntoTable(nameof(Status)).Row(new { Name = "Approved" });
            //Insert.IntoTable(nameof(Status)).Row(new { Name = "Deleted" });
            //Insert.IntoTable(nameof(Status)).Row(new { Name = "Canceled" });
        }

        public override void Down()
        {
            Delete.Table(nameof(User));
            Delete.Table(nameof(Setting));
        }
    }
}
