using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class ArticleMap : EntityMappingConfiguration<Article>
    {
        public override void Map(EntityTypeBuilder<Article> b)
        {
            b.ToTable("T_Article");
            b.HasKey(c => c.Id);
            b.Property(c => c.Url).HasMaxLength(300);
            b.Property(c => c.Title).HasMaxLength(100);
            b.Property(c => c.OperaterPerson).HasMaxLength(10);
        }
    }
}