using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class LogMap : EntityMappingConfiguration<Log>
    {
        public override void Map(EntityTypeBuilder<Log> b)
        {
            b.ToTable("T_Log");
            b.HasKey(c => c.Id);
        }
    }
}