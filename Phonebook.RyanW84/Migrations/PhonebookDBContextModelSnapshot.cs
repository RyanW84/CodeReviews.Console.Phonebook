﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Phonebook.RyanW84.DataConnection;

#nullable disable

namespace Phonebook.RyanW84.Migrations
    {
    [DbContext(typeof(PhonebookDBContext))]
    partial class PhonebookDBContextModelSnapshot : ModelSnapshot
        {
        protected override void BuildModel(ModelBuilder modelBuilder)
            {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Phonebook.RyanW84.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                            {
                            CategoryId = 1,
                            Name = "Family"
                            },
                        new
                            {
                            CategoryId = 2,
                            Name = "Friends"
                            },
                        new
                            {
                            CategoryId = 3,
                            Name = "Colleagues"
                            },
                        new
                            {
                            CategoryId = 4,
                            Name = "Customers"
                            });
                });

            modelBuilder.Entity("Phonebook.RyanW84.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Phonebook.RyanW84.Models.Person", b =>
                {
                    b.HasOne("Phonebook.RyanW84.Models.Category", "Category")
                        .WithMany("Persons")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Phonebook.RyanW84.Models.Category", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
            }
        }
    }
