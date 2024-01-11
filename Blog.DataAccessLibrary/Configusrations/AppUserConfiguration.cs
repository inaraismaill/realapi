using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Configusrations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(b => b.Fullname)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(b => b.Birthday)
                .IsRequired()
                .HasColumnType("date");

        }
    }
}
