﻿// <auto-generated />
using EletronicPartsCatalog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EletronicPartsCatalog.Api.Migrations
{
    [DbContext(typeof(EletronicPartsCatalogContext))]
    partial class EletronicPartsCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorPersonId");

                    b.Property<string>("Body");

                    b.Property<string>("ComponentId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("ProjectId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CommentId");

                    b.HasIndex("AuthorPersonId");

                    b.HasIndex("ComponentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Component", b =>
                {
                    b.Property<string>("ComponentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorPersonId");

                    b.Property<string>("ComponentImage");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Slug");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ComponentId");

                    b.HasIndex("AuthorPersonId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ComponentWhereToFindIt", b =>
                {
                    b.Property<string>("ComponentId");

                    b.Property<string>("WhereToFindItId");

                    b.HasKey("ComponentId", "WhereToFindItId");

                    b.HasIndex("WhereToFindItId");

                    b.ToTable("ComponentWhereToFindIt");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.FollowedPeople", b =>
                {
                    b.Property<int>("ObserverId");

                    b.Property<int>("TargetId");

                    b.HasKey("ObserverId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("FollowedPeople");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<string>("Email");

                    b.Property<byte[]>("Hash");

                    b.Property<string>("Image");

                    b.Property<byte[]>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorPersonId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ProjectImage");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ProjectId");

                    b.HasIndex("AuthorPersonId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectComponent", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<string>("ComponentId");

                    b.HasKey("ProjectId", "ComponentId");

                    b.HasIndex("ComponentId");

                    b.ToTable("ProjectComponents");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectFavorite", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("PersonId");

                    b.HasKey("ProjectId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("ProjectFavorites");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectTag", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<string>("TagId");

                    b.HasKey("ProjectId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.WhereToFindIt", b =>
                {
                    b.Property<string>("WhereToFindItId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("WhereToFindItId");

                    b.ToTable("WhereToFind");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Comment", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorPersonId");

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Component")
                        .WithMany("Comments")
                        .HasForeignKey("ComponentId");

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Component", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorPersonId");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ComponentWhereToFindIt", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Component", "Component")
                        .WithMany("ComponentWhereToFindIt")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EletronicPartsCatalog.Api.Domain.WhereToFindIt", "WhereToFindIt")
                        .WithMany("ComponentWhereToFindIt")
                        .HasForeignKey("WhereToFindItId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.FollowedPeople", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Observer")
                        .WithMany("Followers")
                        .HasForeignKey("ObserverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Target")
                        .WithMany("Following")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.Project", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorPersonId");
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectComponent", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Component", "Component")
                        .WithMany("ProjectComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Project", "Project")
                        .WithMany("ProjectComponents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectFavorite", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Person", "Person")
                        .WithMany("ProjectFavorites")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Project", "Project")
                        .WithMany("ProjectFavorites")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EletronicPartsCatalog.Api.Domain.ProjectTag", b =>
                {
                    b.HasOne("EletronicPartsCatalog.Api.Domain.Project", "Project")
                        .WithMany("ProjectTags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EletronicPartsCatalog.Api.Domain.Tag", "Tag")
                        .WithMany("ProjectTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
