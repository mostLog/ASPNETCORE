using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class DataTypeMap : EntityMappingConfiguration<DataType>
    {
        public override void Map(EntityTypeBuilder<DataType> b)
        {
            b.ToTable("T_DataType");
            b.HasKey(c => c.Id);
        }
    }
}
