using Microsoft.EntityFrameworkCore;
using Burak.Authorization.Data.EntityModels;

namespace Burak.Authorization.Data.Config
{
    public class SqlServerSettingConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable(nameof(Setting));
            builder.HasKey(model => model.Id);
        }
    }
}
