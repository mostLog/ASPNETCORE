using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using L.EntityFramework;

namespace L.EntityFramework.Migrations
{
    [DbContext(typeof(LDbContext))]
    [Migration("20170714065249_spidertask_1.0.0")]
    partial class spidertask_100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("L.LCore.Domain.Entities.CrawlerRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<string>("RuleContent");

                    b.Property<int>("RuleType");

                    b.Property<int?>("SpiderTaskId");

                    b.HasKey("Id");

                    b.HasIndex("SpiderTaskId");

                    b.ToTable("T_CrawlerRule");
                });

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

                    b.Property<int?>("CrawlerRuleId");

                    b.Property<int>("CrawlerType");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsOpenTime");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("OpenTime");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<int>("Status");

                    b.Property<string>("Urls");

                    b.HasKey("Id");

                    b.HasIndex("CrawlerRuleId");

                    b.ToTable("T_SpiderTask");
                });

            modelBuilder.Entity("L.LCore.Domain.Entities.CrawlerRule", b =>
                {
                    b.HasOne("L.LCore.Domain.Entities.SpiderTask")
                        .WithMany("Rules")
                        .HasForeignKey("SpiderTaskId");
                });

            modelBuilder.Entity("L.LCore.Domain.Entities.SpiderTask", b =>
                {
                    b.HasOne("L.LCore.Domain.Entities.CrawlerRule")
                        .WithMany("Tasks")
                        .HasForeignKey("CrawlerRuleId");
                });
        }
    }
}
