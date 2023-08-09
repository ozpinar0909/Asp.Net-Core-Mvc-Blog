using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Dal.Mappings
{
    public class ArtictleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //Data Seed işlemleri burada yapıyoruz
            builder.HasData(new Article
            {
                Id=Guid.NewGuid(),
                Title ="Asp.Net Core Örnek Proje",
                Content= "What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount=15,   
                CategoryId= Guid.Parse("4B116317-854B-469B-9E02-3492A0C34583"),
                CreatedBy ="Admin Test",
                CreatedTime=DateTime.Now,
                ImageId = Guid.Parse("184BAF77-DE82-4DA0-8D25-7CC577FB58C1"),
                IsDeleted =false,                
            });
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Örnek Proje",
                Content = "Visual Studio What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("5F2053AA-D024-4F6F-8AE4-F31F8F4C53FE"),
                ImageId = Guid.Parse("30ACD681-F1DF-42D0-8238-9F2F7DF4CC79"),
                CreatedBy = "Admin Test",
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            };
        }
    }
}
