// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PptNemocnice.Api.Data;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    [DbContext(typeof(NemocniceDbContext))]
    partial class NemocniceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("PptNemocnice.Api.Data.Pracovnik", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pracovnik");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Revize");

                    b.HasData(
                        new
                        {
                            Id = new Guid("839da36b-86a6-475a-a157-5945ec20fe69"),
                            DateTime = new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rentgen",
                            VybaveniId = new Guid("ccc693cf-3fc5-42b3-962e-fd1ba1a3091d")
                        },
                        new
                        {
                            Id = new Guid("f8bd0762-5f23-4f80-bcd8-5aef1d674c49"),
                            DateTime = new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CT Scanner",
                            VybaveniId = new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5")
                        },
                        new
                        {
                            Id = new Guid("8334e45a-157f-4044-a675-53e6d977290d"),
                            DateTime = new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mikroskop",
                            VybaveniId = new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5")
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Ukon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PracovnikId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PracovnikId");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Ukon");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceCzk")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Vybaveni");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ccc693cf-3fc5-42b3-962e-fd1ba1a3091d"),
                            BoughtDate = new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rentgen",
                            PriceCzk = 783278.0
                        },
                        new
                        {
                            Id = new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5"),
                            BoughtDate = new DateTime(2015, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CT Scanner",
                            PriceCzk = 1324653.0
                        },
                        new
                        {
                            Id = new Guid("516cd84c-74be-460d-bd3b-5499afabef23"),
                            BoughtDate = new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mikroskop",
                            PriceCzk = 24246.0
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.HasOne("PptNemocnice.Api.Data.Vybaveni", "Vybaveni")
                        .WithMany("Revizes")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Ukon", b =>
                {
                    b.HasOne("PptNemocnice.Api.Data.Pracovnik", "Pracovnik")
                        .WithMany("Ukons")
                        .HasForeignKey("PracovnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PptNemocnice.Api.Data.Vybaveni", "Vybaveni")
                        .WithMany()
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracovnik");

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Pracovnik", b =>
                {
                    b.Navigation("Ukons");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Navigation("Revizes");
                });
#pragma warning restore 612, 618
        }
    }
}
