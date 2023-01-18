using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRent.Migrations
{
    public partial class ApartmentReview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewTime",
                table: "ApartmentReviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ApartmentOwner",
                keyColumn: "ApartmentOwnerId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 121, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 18, 14, 32, 33, 127, DateTimeKind.Local).AddTicks(2878));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewTime",
                table: "ApartmentReviews");

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
        }
    }
}
