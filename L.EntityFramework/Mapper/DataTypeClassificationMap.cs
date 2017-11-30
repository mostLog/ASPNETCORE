using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class DataTypeClassificationMap : EntityMappingConfiguration<DataTypeClassification>
    {
        public override void Map(EntityTypeBuilder<DataTypeClassification> b)
        {
            b.ToTable("T_DataTypeClassification");
            b.HasKey(c => c.Id);
            b.HasOne(c=>c.ParentDataTypeClass)
                .WithMany(c=>c.DataTypeClasses)
                .HasForeignKey(c=>c.ParentId);
            b.HasMany(c => c.DataTypes)
                .WithOne(c=>c.DataTypeClassification);
        }
    }
}
