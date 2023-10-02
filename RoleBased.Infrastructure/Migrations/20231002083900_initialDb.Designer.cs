﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoleBased.Infrastructure.Persistence;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    [DbContext(typeof(RoleBasedDbContext))]
    [Migration("20231002083900_initialDb")]
    partial class initialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoleBased.Model.StudentInfo", b =>
                {
                    b.Property<string>("RegNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegNo");

                    b.ToTable("StudentInfo");

                    b.HasData(
                        new
                        {
                            RegNo = "2016-2-60-147",
                            DOB = "30/08/1996",
                            Email = "tariqulshuvon@gmail.com",
                            Phone = "01679784089",
                            StudentName = "Tariqul"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}