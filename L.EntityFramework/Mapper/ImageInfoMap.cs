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
            b.Property(c => c.Url).HasMaxLength(300);
            b.Property(c => c.SourceUrl).HasMaxLength(300);
            b.Property(c => c.OperaterPerson).HasMaxLength(10);
            b.Property(c => c.CreatePerson).HasMaxLength(10);
            b.Property(c => c.Name).HasMaxLength(300);
        }
    }
}