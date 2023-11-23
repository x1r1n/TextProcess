﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextProcess.Database;

#nullable disable

namespace TextProcess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231120053038_UpdateSourceTextModel")]
    partial class UpdateSourceTextModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TextProcess.Database.DbModels.GeneratedSentences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Sentence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TextTitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TextTitleId");

                    b.ToTable("GeneratedSentences");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.SourceTexts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenerationWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SourceTexts");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.GeneratedSentences", b =>
                {
                    b.HasOne("TextProcess.Database.DbModels.SourceTexts", "TextTitle")
                        .WithMany("GeneratedSentences")
                        .HasForeignKey("TextTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TextTitle");
                });

            modelBuilder.Entity("TextProcess.Database.DbModels.SourceTexts", b =>
                {
                    b.Navigation("GeneratedSentences");
                });
#pragma warning restore 612, 618
        }
    }
}
