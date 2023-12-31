﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextProcess.Database;

#nullable disable

namespace TextProcess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TextProcess.Database.DbModels.SourceText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SourceText");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.SyntheticPhrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Phrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceTextId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceTextId");

                    b.ToTable("SyntheticPhrase");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.SyntheticPhrase", b =>
                {
                    b.HasOne("TextProcess.Database.DbModels.SourceText", "SourceText")
                        .WithMany("SyntheticPhrases")
                        .HasForeignKey("SourceTextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceText");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.SourceText", b =>
                {
                    b.Navigation("SyntheticPhrases");
                });
#pragma warning restore 612, 618
        }
    }
}
