using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Configuration
{
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> b);

        public void Configuration(ModelBuilder b)
        {
            Map(b.Entity<T>());
        }
    }
    public interface IEntityMappingConfiguration
    {
        void Configuration(ModelBuilder b);
    }

    public interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
