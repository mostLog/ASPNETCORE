using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class CrawlerRuleMap : EntityMappingConfiguration<CrawlerRule>
    {
        public override void Map(EntityTypeBuilder<CrawlerRule> b)
        {
            b.ToTable("T_CrawlerRule");
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Tasks);
        }
    }
}