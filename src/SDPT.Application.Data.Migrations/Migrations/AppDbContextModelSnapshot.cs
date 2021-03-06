// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDPT.Application.Data;

#nullable disable

namespace SDPT.Application.Data.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SDPT.Application.Models.Demand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("AllowPets")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HousingType")
                        .HasColumnType("int");

                    b.Property<bool>("IndependentWashroom")
                        .HasColumnType("bit");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomsMax")
                        .HasColumnType("int");

                    b.Property<int>("RoomsMin")
                        .HasColumnType("int");

                    b.Property<long>("TimeEarliest")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeLatest")
                        .HasColumnType("bigint");

                    b.Property<bool>("WithParking")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Demands");
                });

            modelBuilder.Entity("SDPT.Application.Models.Housing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("AllowPets")
                        .HasColumnType("bit");

                    b.Property<long>("AvailableTimeEarliest")
                        .HasColumnType("bigint");

                    b.Property<long>("AvailableTimeLatest")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HousingType")
                        .HasColumnType("int");

                    b.Property<bool>("IndependentWashroom")
                        .HasColumnType("bit");

                    b.Property<string>("Intro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomsMax")
                        .HasColumnType("int");

                    b.Property<int>("RoomsMin")
                        .HasColumnType("int");

                    b.Property<bool>("WithParking")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Housings");
                });
#pragma warning restore 612, 618
        }
    }
}
