﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestServer.Data;

namespace RestServer.Migrations
{
    [DbContext(typeof(WallonsContext))]
    partial class WallonsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestServer.Models.LiaisonTacheLocataire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocataireId")
                        .HasColumnType("int");

                    b.Property<int>("TacheId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocataireId");

                    b.HasIndex("TacheId");

                    b.ToTable("LiaisonTachesLocataires");
                });

            modelBuilder.Entity("RestServer.Models.Locataire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Actif")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Locataires");
                });

            modelBuilder.Entity("RestServer.Models.Tache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Cycle")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatteFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocataireId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("LocataireId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("RestServer.Models.LiaisonTacheLocataire", b =>
                {
                    b.HasOne("RestServer.Models.Locataire", "Locataire")
                        .WithMany()
                        .HasForeignKey("LocataireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestServer.Models.Tache", "Tache")
                        .WithMany()
                        .HasForeignKey("TacheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestServer.Models.Tache", b =>
                {
                    b.HasOne("RestServer.Models.Locataire", "LocataireCourant")
                        .WithMany()
                        .HasForeignKey("LocataireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}