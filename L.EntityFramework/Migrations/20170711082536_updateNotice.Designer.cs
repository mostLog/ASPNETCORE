using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using L.EntityFramework;

namespace L.EntityFramework.Migrations
{
    [DbContext(typeof(LDbContext))]
    [Migration("20170711082536_updateNotice")]
    partial class updateNotice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("L.LCore.Domain.Entities.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Content");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool?>("IsTop");

                    b.Property<string>("Registrant");

                    b.Property<DateTime?>("StartDate");

                    b.Property<bool?>("Type");

                    b.HasKey("Id");

                    b.ToTable("T_Notice");
                });
        }
    }
}
