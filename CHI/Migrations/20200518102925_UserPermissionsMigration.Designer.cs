﻿// <auto-generated />
using System;
using CHI.Models.ServiceAccounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CHI.Migrations
{
    [DbContext(typeof(ServiceAccountingDBContext))]
    [Migration("20200518102925_UserPermissionsMigration")]
    partial class UserPermissionsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("REAL");

                    b.Property<double>("AmountUnpaid")
                        .HasColumnType("REAL");

                    b.Property<int>("BedDays")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdCase")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaidStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Place")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RegisterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TreatmentPurpose")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VisitPurpose")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RegisterId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.CaseFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Code")
                        .HasColumnType("REAL");

                    b.Property<int?>("ComponentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("CaseFilters");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HexColor")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCanPlanning")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HexColor")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MedicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SpecialtyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MedicId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Indicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComponentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacadeKind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValueKind")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Medic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FomsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Medics");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IndicatorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParameterId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorId");

                    b.HasIndex("ParameterId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.PlanningPermision", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("PlanningPermision");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Ratio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Divider")
                        .HasColumnType("REAL");

                    b.Property<int?>("IndicatorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Multiplier")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorId");

                    b.ToTable("Ratio");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BuildDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CasesCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Month")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentStateCasesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassifierItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Count")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("ClassifierItemId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.ServiceClassifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceClassifiers");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.ServiceClassifierItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCaseClosing")
                        .HasColumnType("INTEGER");

                    b.Property<double>("LaborCost")
                        .HasColumnType("REAL");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("ServiceClassifierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServiceClassifierId");

                    b.ToTable("ServiceClassifierItems");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FomsId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AttachedPatientsPermision")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MedicalExaminationsPermision")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ReferencesPerimision")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RegistersPermision")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SettingsPermision")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("UsersPerimision")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Case", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("CHI.Models.ServiceAccounting.Register", null)
                        .WithMany("Cases")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.CaseFilter", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Component", null)
                        .WithMany("CaseFilters")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Component", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Component", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Department", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Department", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Employee", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("CHI.Models.ServiceAccounting.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId");

                    b.HasOne("CHI.Models.ServiceAccounting.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Indicator", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Component", "Component")
                        .WithMany("Indicators")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Parameter", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Department", "Department")
                        .WithMany("Parameters")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("CHI.Models.ServiceAccounting.Employee", "Employee")
                        .WithMany("Parameters")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Plan", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Indicator", "Indicator")
                        .WithMany()
                        .HasForeignKey("IndicatorId");

                    b.HasOne("CHI.Models.ServiceAccounting.Parameter", "Parameter")
                        .WithMany()
                        .HasForeignKey("ParameterId");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.PlanningPermision", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Department", "Department")
                        .WithMany("PlanningPermisions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CHI.Models.ServiceAccounting.User", "User")
                        .WithMany("PlanningPermisions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Ratio", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Indicator", null)
                        .WithMany("Ratios")
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.Service", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.Case", null)
                        .WithMany("Services")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CHI.Models.ServiceAccounting.ServiceClassifierItem", "ClassifierItem")
                        .WithMany()
                        .HasForeignKey("ClassifierItemId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CHI.Models.ServiceAccounting.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("CHI.Models.ServiceAccounting.ServiceClassifierItem", b =>
                {
                    b.HasOne("CHI.Models.ServiceAccounting.ServiceClassifier", null)
                        .WithMany("ServiceClassifierItems")
                        .HasForeignKey("ServiceClassifierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
