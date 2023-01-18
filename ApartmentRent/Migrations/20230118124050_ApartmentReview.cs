using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRent.Migrations
{
    public partial class ApartmentReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentReviews",
                columns: table => new
                {
                    ApartmentReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentReviews", x => x.ApartmentReviewId);
                    table.ForeignKey(
                        name: "FK_ApartmentReviews_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ApartmentOwner",
                keyColumn: "ApartmentOwnerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 611, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 13, 40, 49, 617, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentReviews_ApartmentId",
                table: "ApartmentReviews",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentReviews_UserId",
                table: "ApartmentReviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentReviews");

            migrationBuilder.UpdateData(
                table: "ApartmentOwner",
                keyColumn: "ApartmentOwnerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 428, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 12, 18, 9, 14, 436, DateTimeKind.Local).AddTicks(9618));
        }
    }
}
