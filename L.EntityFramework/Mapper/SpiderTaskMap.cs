using L.EntityFramework.Configuration;
using L.LCore.Domain.Spider;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework.Mapper
{
    public class SpiderTaskMap : EntityMappingConfiguration<SpiderTask>
    {
        public override void Map(EntityTypeBuilder<SpiderTask> b)
        {
            b.ToTable("T_SpiderTask");
            b.HasKey(c=>c);
        }
    }
}
