using HomeExpenseControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeExpenseControl.Infra.Data.Mapping
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("TB_USER");

            entity.HasKey(e => e.idUser);

            entity.Property(e => e.idUser).HasColumnName("ID_USER");
            entity.Property(e => e.UserName).HasColumnName("USER_NAME");
            entity.Property(e => e.UserAge).HasColumnName("USER_AGE");
        }
    }
}
