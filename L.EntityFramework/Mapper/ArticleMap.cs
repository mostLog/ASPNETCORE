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
        }
    }
}