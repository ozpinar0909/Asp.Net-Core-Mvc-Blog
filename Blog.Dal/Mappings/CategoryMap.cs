using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("4B116317-854B-469B-9E02-3492A0C34583"),
                Name = "Asp.Net Core",
                CreatedBy = "Admin Test",
                CreatedTime = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("5F2053AA-D024-4F6F-8AE4-F31F8F4C53FE"),
                Name = "Visual Studio",
                CreatedBy = "Admin Test",
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
