using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class NoticeMap : EntityMappingConfiguration<Notice>
    {
        public override void Map(EntityTypeBuilder<Notice> b)
        {
            b.ToTable("T_Notice");
            b.HasKey(c => c.Id);
        }
    }
}