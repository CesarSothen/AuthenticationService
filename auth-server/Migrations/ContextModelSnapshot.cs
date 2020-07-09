﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using auth_server.Repositories;

namespace auth_server.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("auth_server.Models.CountryModels.Country", b =>
                {
                    b.Property<string>("_name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("_name");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("auth_server.Models.OrganizationModels.Organization", b =>
                {
                    b.Property<Guid>("_oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("_templateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_oid");

                    b.HasIndex("_templateId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("auth_server.Models.UserTemplateModels.UserTemplate", b =>
                {
                    b.Property<Guid>("_tid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("_tid");

                    b.ToTable("UserTemplates");
                });

            modelBuilder.Entity("auth_server.Models.CountryModels.Country", b =>
                {
                    b.OwnsMany("auth_server.Models.CountryModels.State", "states", b1 =>
                        {
                            b1.Property<string>("Country_name")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Country_name", "Id");

                            b1.ToTable("State");

                            b1.WithOwner()
                                .HasForeignKey("Country_name");
                        });
                });

            modelBuilder.Entity("auth_server.Models.OrganizationModels.Organization", b =>
                {
                    b.HasOne("auth_server.Models.UserTemplateModels.UserTemplate", null)
                        .WithMany()
                        .HasForeignKey("_templateId");

                    b.OwnsOne("auth_server.Models.OrganizationModels.Address", "address", b1 =>
                        {
                            b1.Property<Guid>("Organization_oid")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Organization_oid");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("Organization_oid");
                        });
                });

            modelBuilder.Entity("auth_server.Models.UserTemplateModels.UserTemplate", b =>
                {
                    b.OwnsMany("auth_server.Models.UserTemplateModels.UserTemplateAttribute", "attributes", b1 =>
                        {
                            b1.Property<Guid>("UserTemplate_tid")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("type")
                                .HasColumnType("int");

                            b1.HasKey("UserTemplate_tid", "Id");

                            b1.ToTable("UserTemplateAttribute");

                            b1.WithOwner()
                                .HasForeignKey("UserTemplate_tid");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
