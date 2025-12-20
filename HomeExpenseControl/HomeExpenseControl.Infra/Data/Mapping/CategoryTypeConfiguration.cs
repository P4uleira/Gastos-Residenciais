using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeExpenseControl.Infra.Data.Mapping
{
    internal class CategoryTypeConfiguration : IEntityTypeConfiguration <Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("TB_CATEGORY");

            entity.HasKey(e => e.IdCategory);

            entity.Property(e => e.IdCategory).HasColumnName("ID_CATEGORY");
            entity.Property(e => e.CategoryDescription).HasColumnName("CATEGORY_DESCRIPTION");
            entity.Property(e => e.CategoryPurpose)
                .HasColumnName("CATEGORY_PURPOSE")
                .HasConversion(new EnumToStringConverter<CategoryPurposeEnum>());
        }
    }
}
