using L.EntityFramework.Configuration;
using L.LCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework.Mapper
{
    public class NoticeMap : EntityMappingConfiguration<Notice>
    {
        public override void Map(EntityTypeBuilder<Notice> b)
        {
            b.ToTable("T_Notice");
            b.HasKey(c=>c.Id);
        }
    }
}
