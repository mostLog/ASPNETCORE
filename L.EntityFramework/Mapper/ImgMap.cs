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
        }
    }
}