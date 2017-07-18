using L.EntityFramework.Configuration;
using L.LCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
