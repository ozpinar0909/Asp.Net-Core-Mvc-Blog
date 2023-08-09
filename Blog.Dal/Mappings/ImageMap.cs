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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("184BAF77-DE82-4DA0-8D25-7CC577FB58C1"),
                FileName = "/images/testimage",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            },
         new Image
         {
             Id = Guid.Parse("30ACD681-F1DF-42D0-8238-9F2F7DF4CC79"),
             FileName = "/images/vstest",
             FileType = "png",
             CreatedBy = "Admin Test",
             CreatedTime = DateTime.Now,
             IsDeleted = false,
         });
        }
    }
}
