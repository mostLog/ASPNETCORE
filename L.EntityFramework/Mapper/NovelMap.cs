using L.EntityFramework.Configuration;
using L.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework.Mapper
{
    public class NovelMap : EntityMappingConfiguration<Novel>
    {
        public override void Map(EntityTypeBuilder<Novel> b)
        {
            b.ToTable("T_Novel");
            b.HasKey(c=>c.Id);
            b.HasMany(c => c.Articles);
                
        }
    }
}
