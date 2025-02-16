﻿// <auto-generated />
using System;
using DataAccess.EF.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppTicketV2.Migrations
{
    [DbContext(typeof(AppTicketDBContext))]
    partial class AppTicketDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.EF.Models.Operator", b =>
                {
                    b.Property<int>("OperatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperatorID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperatorID");

                    b.ToTable("Operator");
                });

            modelBuilder.Entity("DataAccess.EF.Models.OperatorRole", b =>
                {
                    b.Property<int>("OperatorRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperatorRoleID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedDateFa")
                        .HasColumnType("int");

                    b.Property<int>("OperatorID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("OperatorRoleID");

                    b.HasIndex("OperatorID");

                    b.HasIndex("RoleID");

                    b.ToTable("OperatorRole");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("CreatedDateFa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("dbo.M2S(GETDATE())");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Portal", b =>
                {
                    b.Property<int>("PortalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortalID"));

                    b.Property<int>("OrgID")
                        .HasColumnType("int");

                    b.Property<int>("ParentPortalID")
                        .HasColumnType("int");

                    b.Property<string>("PortalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortalUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WidgetID")
                        .HasColumnType("int");

                    b.Property<int>("WidgetPropertyID")
                        .HasColumnType("int");

                    b.HasKey("PortalID");

                    b.HasIndex("OrgID");

                    b.HasIndex("WidgetID");

                    b.HasIndex("WidgetPropertyID");

                    b.ToTable("Portal");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Widget", b =>
                {
                    b.Property<int>("WidgetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WidgetID"));

                    b.Property<string>("WidgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WidgetID");

                    b.ToTable("Widget");
                });

            modelBuilder.Entity("DataAccess.EF.Models.WidgetProperty", b =>
                {
                    b.Property<int>("WidgetPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WidgetPropertyID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedDateFa")
                        .HasColumnType("int");

                    b.Property<string>("WidgetColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WidgetID")
                        .HasColumnType("int");

                    b.Property<string>("WidgetIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WidgetPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WidgetPropertyID");

                    b.ToTable("WidgetProperty");
                });

            modelBuilder.Entity("DataAccess.EF.Models.OperatorRole", b =>
                {
                    b.HasOne("DataAccess.EF.Models.Operator", "Operator")
                        .WithMany("OperatorRoles")
                        .HasForeignKey("OperatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.EF.Models.Role", "Role")
                        .WithMany("OperatorRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operator");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Portal", b =>
                {
                    b.HasOne("DataAccess.EF.Models.Organization", "Organization")
                        .WithMany("Portals")
                        .HasForeignKey("OrgID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.EF.Models.Widget", "Widget")
                        .WithMany("Portals")
                        .HasForeignKey("WidgetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.EF.Models.WidgetProperty", "WidgetProperty")
                        .WithMany()
                        .HasForeignKey("WidgetPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Widget");

                    b.Navigation("WidgetProperty");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Operator", b =>
                {
                    b.Navigation("OperatorRoles");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Organization", b =>
                {
                    b.Navigation("Portals");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Role", b =>
                {
                    b.Navigation("OperatorRoles");
                });

            modelBuilder.Entity("DataAccess.EF.Models.Widget", b =>
                {
                    b.Navigation("Portals");
                });
#pragma warning restore 612, 618
        }
    }
}
