using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moelyrics.Services.Metadata.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Length = table.Column<TimeSpan>(nullable: true),
                    SHA1 = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_track", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "albumArtist",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albumArtist", x => new { x.AlbumId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_albumArtist_album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_albumArtist_artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lyric",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LrcFileName = table.Column<string>(nullable: true),
                    Reliability = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lyric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lyric_track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trackArtist",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trackArtist", x => new { x.TrackId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_trackArtist_artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trackArtist_track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_Title",
                table: "album",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_albumArtist_ArtistId",
                table: "albumArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_artist_Name",
                table: "artist",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_lyric_TrackId",
                table: "lyric",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_track_SHA1",
                table: "track",
                column: "SHA1");

            migrationBuilder.CreateIndex(
                name: "IX_track_Title",
                table: "track",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_trackArtist_ArtistId",
                table: "trackArtist",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albumArtist");

            migrationBuilder.DropTable(
                name: "lyric");

            migrationBuilder.DropTable(
                name: "trackArtist");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "track");
        }
    }
}
