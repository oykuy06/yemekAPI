using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yemekAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvAdresi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsAdresi = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriTuru = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorilers", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Ürünlers",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürünlers", x => x.UrunId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcıs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcıs", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Kullanıcıs_Adresses_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresses",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_restaurants_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menülers",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menülers", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menülers_Ürünlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Ürünlers",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepets",
                columns: table => new
                {
                    SepetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UrunAdet = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepets", x => x.SepetId);
                    table.ForeignKey(
                        name: "FK_Sepets_Kullanıcıs_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanıcıs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparislers",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SiparisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiparisAdet = table.Column<int>(type: "int", nullable: false),
                    SiparisTutar = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparislers", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK_Siparislers_Kullanıcıs_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanıcıs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparislers_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restMenüsüs",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restMenüsüs", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_restMenüsüs_Menülers_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menülers",
                        principalColumn: "MenuId");
                    table.ForeignKey(
                        name: "FK_restMenüsüs_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sepetUruns",
                columns: table => new
                {
                    SepetId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sepetUruns", x => x.SepetId);
                    table.ForeignKey(
                        name: "FK_sepetUruns_Sepets_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Sepets",
                        principalColumn: "SepetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sepetUruns_Ürünlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Ürünlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcıs_AdresId",
                table: "Kullanıcıs",
                column: "AdresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menülers_UrunId",
                table: "Menülers",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_KategoriId",
                table: "restaurants",
                column: "KategoriId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_restMenüsüs_MenuId",
                table: "restMenüsüs",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_UserId",
                table: "Sepets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_sepetUruns_UrunId",
                table: "sepetUruns",
                column: "UrunId",
                unique: true,
                filter: "[UrunId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Siparislers_RestaurantId",
                table: "Siparislers",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siparislers_UserId",
                table: "Siparislers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restMenüsüs");

            migrationBuilder.DropTable(
                name: "sepetUruns");

            migrationBuilder.DropTable(
                name: "Siparislers");

            migrationBuilder.DropTable(
                name: "Menülers");

            migrationBuilder.DropTable(
                name: "Sepets");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "Ürünlers");

            migrationBuilder.DropTable(
                name: "Kullanıcıs");

            migrationBuilder.DropTable(
                name: "Kategorilers");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
