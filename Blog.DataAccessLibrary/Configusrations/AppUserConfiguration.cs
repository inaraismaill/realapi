using Blog.Core.Entities;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
=======
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Configusrations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
<<<<<<< HEAD
            builder.Property(b=>b.Fullname).IsRequired().HasMaxLength(32);
            builder.Property(b => b.Birthday).IsRequired().HasColumnType("date");
=======
            builder.Property(u => u.Name).IsRequired().HasMaxLength(16);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(32);
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
        }
    }
}
