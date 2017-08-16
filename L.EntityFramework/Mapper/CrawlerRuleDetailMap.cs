using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class CrawlerRuleDetailMap : EntityMappingConfiguration<CrawlerRuleDetail>
    {
        public override void Map(EntityTypeBuilder<CrawlerRuleDetail> b)
        {
            b.ToTable("T_CrawlerRuleDetail");
            b.HasKey(c=>c.Id);
        }
    }
}
