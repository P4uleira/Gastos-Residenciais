using HomeExpenseControl.Domain.Entities;
using HomeExpenseControl.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeExpenseControl.Infra.Data.Mapping
{
    internal class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("TB_TRANSACTION");

            entity.HasKey(e => e.IdTransaction);

            entity.Property(e => e.IdTransaction).HasColumnName("ID_TRANSACTION");
            entity.Property(e => e.TransactionDescription).HasColumnName("TRANSACTION_DESCRIPTION");
            entity.Property(e => e.TransactionAmount).HasColumnName("TRANSACTION_AMOUNT").HasPrecision(18, 2);
            entity.Property(e => e.TransactionType)
                .HasColumnName("TRANSACTION_TYPE")
                .HasConversion(new EnumToStringConverter<TransactionTypeEnum>());
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(e => e.User)
              .WithMany(u => u.Transactions)
              .HasForeignKey(e => e.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Category)
              .WithMany(u => u.Transactions)
              .HasForeignKey(e => e.CategoryId);
        }
    }
}
