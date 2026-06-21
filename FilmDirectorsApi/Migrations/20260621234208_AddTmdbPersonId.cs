using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmDirectorsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTmdbPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "TmdbPersonId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "TmdbPersonId",
                value: 525);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "TmdbPersonId",
                value: 1032);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3,
                column: "TmdbPersonId",
                value: 138);

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name", "Nationality", "TmdbPersonId" },
                values: new object[,]
                {
                    { 4, "Stanley Kubrick", "American", 240 },
                    { 5, "Steven Spielberg", "American", 488 },
                    { 6, "David Fincher", "American", 7467 },
                    { 7, "Alfred Hitchcock", "British", 2636 },
                    { 8, "Ridley Scott", "British", 578 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "TmdbPersonId",
                table: "Directors");

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "DirectorId", "ReleaseYear", "Title", "TmdbId" },
                values: new object[,]
                {
                    { 1, 1, 2010, "Inception", 27205 },
                    { 2, 1, 2008, "The Dark Knight", 155 },
                    { 3, 2, 1990, "Goodfellas", 769 },
                    { 4, 2, 2006, "The Departed", 1422 },
                    { 5, 3, 1994, "Pulp Fiction", 680 },
                    { 6, 3, 2012, "Django Unchained", 68718 }
                });
        }
    }
}
