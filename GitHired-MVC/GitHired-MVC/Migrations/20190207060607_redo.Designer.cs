﻿// <auto-generated />
using GitHired_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GitHired_MVC.Migrations
{
    [DbContext(typeof(GitHiredDBContext))]
    [Migration("20190207060607_redo")]
    partial class redo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitHired_MVC.Models.Board", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FocusID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("FocusID")
                        .IsUnique();

                    b.ToTable("Board");
                });

            modelBuilder.Entity("GitHired_MVC.Models.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColumnID");

                    b.Property<string>("CompanyName");

                    b.Property<bool>("CoverLetterCheck");

                    b.Property<string>("Description");

                    b.Property<string>("JobTitle");

                    b.Property<bool>("ResumeCheck");

                    b.Property<string>("Wage");

                    b.HasKey("ID");

                    b.HasIndex("ColumnID");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("GitHired_MVC.Models.Column", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardID");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("ID");

                    b.HasIndex("BoardID");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("GitHired_MVC.Models.Focus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverLetter");

                    b.Property<string>("DesiredPosition");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("ResumeLink");

                    b.Property<string>("Skill");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Focus");
                });

            modelBuilder.Entity("GitHired_MVC.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("GitHubLink");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GitHired_MVC.Models.Board", b =>
                {
                    b.HasOne("GitHired_MVC.Models.Focus", "Focus")
                        .WithOne("Board")
                        .HasForeignKey("GitHired_MVC.Models.Board", "FocusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitHired_MVC.Models.Card", b =>
                {
                    b.HasOne("GitHired_MVC.Models.Column", "Column")
                        .WithMany("Card")
                        .HasForeignKey("ColumnID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitHired_MVC.Models.Column", b =>
                {
                    b.HasOne("GitHired_MVC.Models.Board", "Board")
                        .WithMany("Column")
                        .HasForeignKey("BoardID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitHired_MVC.Models.Focus", b =>
                {
                    b.HasOne("GitHired_MVC.Models.User", "User")
                        .WithMany("Focus")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
