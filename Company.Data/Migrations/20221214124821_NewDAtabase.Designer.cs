﻿// <auto-generated />
using Company.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Data.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20221214124821_NewDAtabase")]
    partial class NewDAtabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company.Data.Entities.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrgNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Business");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CompanyEuropa",
                            OrgNumber = 1001
                        },
                        new
                        {
                            Id = 2,
                            Name = "CompanyNorden",
                            OrgNumber = 1002
                        },
                        new
                        {
                            Id = 3,
                            Name = "CompanyAmerica",
                            OrgNumber = 1003
                        },
                        new
                        {
                            Id = 4,
                            Name = "CompanyAsia",
                            OrgNumber = 1004
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Departmens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessId = 1,
                            Name = "ITTeam"
                        },
                        new
                        {
                            Id = 2,
                            BusinessId = 2,
                            Name = "DevelopTeam"
                        },
                        new
                        {
                            Id = 3,
                            BusinessId = 3,
                            Name = "AITeam"
                        },
                        new
                        {
                            Id = 4,
                            BusinessId = 4,
                            Name = "EconomyTeam"
                        },
                        new
                        {
                            Id = 5,
                            BusinessId = 2,
                            Name = "SpecialistIT"
                        },
                        new
                        {
                            Id = 6,
                            BusinessId = 1,
                            Name = "DevelopSpecialist"
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<bool>("UnionMember")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            FirstName = "Mikael",
                            LastName = "Issa",
                            Salary = 50.0,
                            UnionMember = true
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            FirstName = "Jack",
                            LastName = "Larsson",
                            Salary = 500.0,
                            UnionMember = false
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            FirstName = "Sven",
                            LastName = "Isaksson",
                            Salary = 20.0,
                            UnionMember = true
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 4,
                            FirstName = "Ben",
                            LastName = "King",
                            Salary = 555.0,
                            UnionMember = true
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeeTitle", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("EmployeeTitles");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            TitleId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            TitleId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            TitleId = 2
                        },
                        new
                        {
                            EmployeeId = 4,
                            TitleId = 3
                        },
                        new
                        {
                            EmployeeId = 1,
                            TitleId = 4
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "CEO"
                        },
                        new
                        {
                            Id = 2,
                            Role = "CTO"
                        },
                        new
                        {
                            Id = 3,
                            Role = "CFO"
                        },
                        new
                        {
                            Id = 4,
                            Role = "Developer"
                        },
                        new
                        {
                            Id = 5,
                            Role = "Tester"
                        });
                });

            modelBuilder.Entity("EmployeeTitle", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("EmployeeTitle");
                });

            modelBuilder.Entity("Company.Data.Entities.Department", b =>
                {
                    b.HasOne("Company.Data.Entities.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Company.Data.Entities.Employee", b =>
                {
                    b.HasOne("Company.Data.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeeTitle", b =>
                {
                    b.HasOne("Company.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("EmployeeTitle", b =>
                {
                    b.HasOne("Company.Data.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.Title", null)
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
