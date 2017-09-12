using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class NovelMap : EntityMappingConfiguration<Novel>
    {
        public override void Map(EntityTypeBuilder<Novel> b)
        {
            b.ToTable("T_Novel");
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Articles);
        }
    }
}