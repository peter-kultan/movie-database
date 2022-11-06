﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDatabaseDAL;

#nullable disable

namespace MovieDatabaseDAL.Migrations
{
    [DbContext(typeof(MovieDatabaseDbContext))]
    partial class MovieDatabaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("GenreTVSeries", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TVSeriesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "TVSeriesId");

                    b.HasIndex("TVSeriesId");

                    b.ToTable("GenreTVSeries");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieMetadataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieMetadataId")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.MovieMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackdropPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Popularity")
                        .HasColumnType("REAL");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TmdbId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VoteAverage")
                        .HasColumnType("REAL");

                    b.Property<int>("VoteCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MovieMetadata");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RepositoryType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Repository");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MetadataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MetadataId")
                        .IsUnique();

                    b.ToTable("TVSeries");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeriesEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Runtime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StillPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TmdbId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TvSeriesId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VoteAverage")
                        .HasColumnType("REAL");

                    b.Property<int>("VoteCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TvSeriesId");

                    b.ToTable("TVSeriesEpisode");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeriesMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackdropPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstAirDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Popularity")
                        .HasColumnType("REAL");

                    b.Property<string>("PosterPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tmdb")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VoteAverage")
                        .HasColumnType("REAL");

                    b.Property<int>("VoteCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TVSeriesMetadata");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MovieDatabaseDAL.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDatabaseDAL.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreTVSeries", b =>
                {
                    b.HasOne("MovieDatabaseDAL.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDatabaseDAL.Models.TVSeries", null)
                        .WithMany()
                        .HasForeignKey("TVSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.Movie", b =>
                {
                    b.HasOne("MovieDatabaseDAL.Models.MovieMetadata", "Metadata")
                        .WithOne("Movie")
                        .HasForeignKey("MovieDatabaseDAL.Models.Movie", "MovieMetadataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeries", b =>
                {
                    b.HasOne("MovieDatabaseDAL.Models.TVSeriesMetadata", "Metadata")
                        .WithOne("TvSeries")
                        .HasForeignKey("MovieDatabaseDAL.Models.TVSeries", "MetadataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeriesEpisode", b =>
                {
                    b.HasOne("MovieDatabaseDAL.Models.TVSeries", "TvSeries")
                        .WithMany("Episodes")
                        .HasForeignKey("TvSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TvSeries");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.MovieMetadata", b =>
                {
                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeries", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("MovieDatabaseDAL.Models.TVSeriesMetadata", b =>
                {
                    b.Navigation("TvSeries")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}