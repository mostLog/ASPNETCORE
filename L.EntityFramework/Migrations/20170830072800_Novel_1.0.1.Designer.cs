﻿// <auto-generated />
using L.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace L.EntityFramework.Migrations
{
    [DbContext(typeof(LDbContext))]
    [Migration("20170830072800_Novel_1.0.1")]
    partial class Novel_101
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("L.Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<int?>("NovelId");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("NovelId");

                    b.ToTable("T_Article");
                });

            modelBuilder.Entity("L.Domain.Entities.CrawlerRule", b =>
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

            modelBuilder.Entity("L.Domain.Entities.CrawlerRuleDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<string>("ColumnRule");

                    b.Property<int?>("CrawlerRuleId");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.Property<string>("TableName");

                    b.HasKey("Id");

                    b.HasIndex("CrawlerRuleId");

                    b.ToTable("T_CrawlerRuleDetail");
                });

            modelBuilder.Entity("L.Domain.Entities.Notice", b =>
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

            modelBuilder.Entity("L.Domain.Entities.Novel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("CreatePerson");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("OperaterDateTime");

                    b.Property<string>("OperaterPerson");

                    b.HasKey("Id");

                    b.ToTable("T_Novel");
                });

            modelBuilder.Entity("L.Domain.Entities.SpiderTask", b =>
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

                    b.Property<string>("SpiderId");

                    b.Property<int>("Status");

                    b.Property<string>("Urls");

                    b.HasKey("Id");

                    b.HasIndex("CrawlerRuleId");

                    b.ToTable("T_SpiderTask");
                });

            modelBuilder.Entity("L.Domain.Entities.Article", b =>
                {
                    b.HasOne("L.Domain.Entities.Novel", "Novel")
                        .WithMany("Articles")
                        .HasForeignKey("NovelId");
                });

            modelBuilder.Entity("L.Domain.Entities.CrawlerRule", b =>
                {
                    b.HasOne("L.Domain.Entities.SpiderTask")
                        .WithMany("Rules")
                        .HasForeignKey("SpiderTaskId");
                });

            modelBuilder.Entity("L.Domain.Entities.CrawlerRuleDetail", b =>
                {
                    b.HasOne("L.Domain.Entities.CrawlerRule", "CrawlerRule")
                        .WithMany()
                        .HasForeignKey("CrawlerRuleId");
                });

            modelBuilder.Entity("L.Domain.Entities.SpiderTask", b =>
                {
                    b.HasOne("L.Domain.Entities.CrawlerRule")
                        .WithMany("Tasks")
                        .HasForeignKey("CrawlerRuleId");
                });
#pragma warning restore 612, 618
        }
    }
}
