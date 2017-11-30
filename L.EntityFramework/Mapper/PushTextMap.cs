using L.Domain.Entities;
using L.EntityFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace L.EntityFramework.Mapper
{
    public class PushTextMap : EntityMappingConfiguration<PushText>
    {
        public override void Map(EntityTypeBuilder<PushText> b)
        {
            b.ToTable("T_PushText");
            b.HasKey(c=>c.Id);
            b.Property(c=>c.TextType).HasMaxLength(100);
        }
    }
}
