using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRent.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentOwner",
                columns: table => new
                {
                    ApartmentOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentOwner", x => x.ApartmentOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentPicture",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentPicture", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentProfilePicture",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 250, nullable: false),
                    ApartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 250, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentProfilePicture", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    NameEng = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "TagType",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    NameEng = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    NameEng = table.Column<string>(maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    MaxAdults = table.Column<int>(nullable: false),
                    MaxChildren = table.Column<int>(nullable: false),
                    TotalRooms = table.Column<int>(nullable: false),
                    BeachDistance = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescritpion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartment_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_ApartmentProfilePicture",
                        column: x => x.ImageId,
                        principalTable: "ApartmentProfilePicture",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_ApartmentOwner",
                        column: x => x.OwnerId,
                        principalTable: "ApartmentOwner",
                        principalColumn: "ApartmentOwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_ApartmentStatus",
                        column: x => x.StatusId,
                        principalTable: "ApartmentStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    NameEng = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_TagType",
                        column: x => x.TypeId,
                        principalTable: "TagType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentAlbum",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAlbum", x => new { x.ApartmentId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ApartmentAlbum_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentAlbum_ApartmentPicture_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ApartmentPicture",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaggedApartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedApartments", x => new { x.ApartmentId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TaggedApartments_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedApartments_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApartmentOwner",
                columns: new[] { "ApartmentOwnerId", "CreatedAt", "Email", "Name" },
                values: new object[] { 1, new DateTime(2022, 7, 17, 13, 43, 43, 618, DateTimeKind.Local).AddTicks(6758), "domagoj.sliepcevic@racunarstvo.hr", "Domagoj Sliepcevic" });

            migrationBuilder.InsertData(
                table: "ApartmentStatus",
                columns: new[] { "StatusId", "Name", "NameEng" },
                values: new object[,]
                {
                    { 1, "Slobodno", "Free" },
                    { 2, "Zauzeto", "Booked" },
                    { 3, "Rezervirano", "Reserved" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Vinkovci" },
                    { 2, "Zagreb" },
                    { 3, "Split" }
                });

            migrationBuilder.InsertData(
                table: "TagType",
                columns: new[] { "TypeId", "Name", "NameEng" },
                values: new object[,]
                {
                    { 1, "Aparati", "Devices" },
                    { 2, "Podrucja", "Areas" },
                    { 3, "Ostalo", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "CreatedAt", "Name", "NameEng", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(3628), "Kafe aparat", "Coffee maker", 1 },
                    { 2, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(4715), "Perilica sudja", "Dishwasher", 1 },
                    { 3, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(4766), "Balkon", "Balcony", 2 },
                    { 4, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(4769), "Kupaonica", "Bathroom", 2 },
                    { 5, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(4772), "Kada", "Bathtub", 2 },
                    { 6, new DateTime(2022, 7, 17, 13, 43, 43, 624, DateTimeKind.Local).AddTicks(4775), "Bide", "Bidet", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_CityId",
                table: "Apartment",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ImageId",
                table: "Apartment",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_OwnerId",
                table: "Apartment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_StatusId",
                table: "Apartment",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAlbum_ImageId",
                table: "ApartmentAlbum",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TypeId",
                table: "Tag",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaggedApartments_TagId",
                table: "TaggedApartments",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentAlbum");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TaggedApartments");

            migrationBuilder.DropTable(
                name: "ApartmentPicture");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ApartmentProfilePicture");

            migrationBuilder.DropTable(
                name: "ApartmentOwner");

            migrationBuilder.DropTable(
                name: "ApartmentStatus");

            migrationBuilder.DropTable(
                name: "TagType");
        }
    }
}
