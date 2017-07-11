using L.EntityFramework.Configuration;
using L.LCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class SpiderTaskMap : EntityMappingConfiguration<SpiderTask>
    {
        public override void Map(EntityTypeBuilder<SpiderTask> b)
        {
            b.ToTable("T_SpiderTask");
            b.HasKey(c=>c.Id);
        }
    }
}
