using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class ImageInfoMap : EntityMappingConfiguration<ImageInfo>
    {
        public override void Map(EntityTypeBuilder<ImageInfo> b)
        {
            b.ToTable("T_ImageInfo");
            b.HasKey(c => c.Id);
        }
    }
}