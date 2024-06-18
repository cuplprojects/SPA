﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPA.Data;

#nullable disable

namespace SPA.Migrations
{
    [DbContext(typeof(FirstDbContext))]
    partial class FirstDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SPA.Absentee", b =>
                {
                    b.Property<int>("AbsenteeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AbsenteeId"));

                    b.Property<string>("Absenteedata")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("AbsenteeId");

                    b.ToTable("Absentees");
                });

            modelBuilder.Entity("SPA.CorrectedOMRData", b =>
                {
                    b.Property<int>("CorrectedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CorrectedId"));

                    b.Property<string>("CorrectedOmrData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OmrData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("CorrectedId");

                    b.ToTable("CorrectedOMRData");
                });

            modelBuilder.Entity("SPA.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FieldId"));

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FieldId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("SPA.FieldConfiguration", b =>
                {
                    b.Property<int>("FieldConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FieldConfigurationId"));

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("attribute")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FieldConfigurationId");

                    b.ToTable("FieldsConfig");
                });

            modelBuilder.Entity("SPA.Flags", b =>
                {
                    b.Property<int>("FlagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FlagId"));

                    b.Property<string>("FieldNameValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FlagId");

                    b.ToTable("Flag");
                });

            modelBuilder.Entity("SPA.ImageConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FieldAnnotation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ImageConfigs");
                });

            modelBuilder.Entity("SPA.Keys", b =>
                {
                    b.Property<int>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("KeyId"));

                    b.Property<string>("KeyData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KeyFile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("KeyId");

                    b.ToTable("Key");
                });

            modelBuilder.Entity("SPA.Models.AmbiguousQues", b =>
                {
                    b.Property<int>("AmbiguousId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AmbiguousId"));

                    b.Property<int>("MarkingId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("SetQuesAns")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AmbiguousId");

                    b.ToTable("AmbiguousQue");
                });

            modelBuilder.Entity("SPA.Models.ChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ChangeLog_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsSynced")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LogEntry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LoggedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Table")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ChangeLogs");
                });

            modelBuilder.Entity("SPA.Models.MarkingRule", b =>
                {
                    b.Property<int>("MarkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MarkingId"));

                    b.Property<string>("MarkingName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MarkingId");

                    b.ToTable("MarkingRules");
                });

            modelBuilder.Entity("SPA.Models.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ScoreId"));

                    b.Property<int>("CorrectedId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ScoreData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ScoreId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("SPA.Models.UserAuth", b =>
                {
                    b.Property<int>("UserAuthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserAuthId"));

                    b.Property<bool>("AutogenPass")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserAuthId");

                    b.ToTable("UserAuths");
                });

            modelBuilder.Entity("SPA.Modules", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ModuleId"));

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ModuleId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("SPA.OMRdata", b =>
                {
                    b.Property<int>("OmrDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OmrDataId"));

                    b.Property<int>("Barcode")
                        .HasColumnType("int");

                    b.Property<string>("OmrData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("csvfile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OmrDataId");

                    b.ToTable("OMRdata");
                });

            modelBuilder.Entity("SPA.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<bool>("CanAdd")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanView")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("SPA.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SPA.RegistrationData", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RegistrationId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationsData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RegistrationId");

                    b.ToTable("RegistrationData");
                });

            modelBuilder.Entity("SPA.Reports", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ReportData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ReportId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("SPA.ResponseConfig", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ResponseId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ResponseId");

                    b.ToTable("ResponseConfigs");
                });

            modelBuilder.Entity("SPA.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SPA.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
