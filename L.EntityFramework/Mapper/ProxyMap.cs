using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class ProxyMap : EntityMappingConfiguration<Proxy>
    {
        public override void Map(EntityTypeBuilder<Proxy> b)
        {
            b.ToTable("T_Proxy");
            b.HasKey(c=>c.Id);
            b.Property(c => c.IP).HasMaxLength(20);
            b.Property(c => c.Location).HasMaxLength(50);
            b.Property(c => c.Type).HasMaxLength(8);
            //设置代理默认可用
            b.Property(c => c.IsAvailable).HasDefaultValue(true);
        }
    }
}
