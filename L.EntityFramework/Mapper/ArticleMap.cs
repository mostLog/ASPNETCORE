using L.EntityFramework.Configuration;
using L.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework.Mapper
{
    public class ArticleMap : EntityMappingConfiguration<Article>
    {
        public override void Map(EntityTypeBuilder<Article> b)
        {
            b.ToTable("T_Article");
            b.HasKey(c=>c.Id);
        }
    }
}
