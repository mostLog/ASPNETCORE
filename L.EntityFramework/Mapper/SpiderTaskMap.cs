﻿using L.Domain.Entities;
using L.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L.EntityFramework.Mapper
{
    public class SpiderTaskMap : EntityMappingConfiguration<SpiderTask>
    {
        public override void Map(EntityTypeBuilder<SpiderTask> b)
        {
            b.ToTable("T_SpiderTask");
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Rules);
        }
    }
}