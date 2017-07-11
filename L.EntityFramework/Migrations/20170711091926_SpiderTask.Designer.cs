using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using L.EntityFramework;

namespace L.EntityFramework.Migrations
{
    [DbContext(typeof(LDbContext))]
    [Migration("20170711091926_SpiderTask")]
    partial class SpiderTask
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

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool?>("IsTop");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<DateTime?>("StartDate");

                    b.Property<bool?>("Type");

                    b.HasKey("Id");

                    b.ToTable("T_Notice");
                });

            modelBuilder.Entity("L.LCore.Domain.Entities.SpiderTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("T_SpiderTask");
                });
        }
    }
}
