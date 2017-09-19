using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class ImgMap : EntityMappingConfiguration<Img>
    {
        public override void Map(EntityTypeBuilder<Img> b)
        {
            b.ToTable("T_Img");
            b.HasKey(c => c.Id);
            b.Property(c => c.Url).HasMaxLength(300);
            b.Property(c => c.Introduce).HasMaxLength(500);
            b.Property(c => c.CreatePerson).HasMaxLength(10);
            b.Property(c => c.OperaterPerson).HasMaxLength(10);
        }
    }
}