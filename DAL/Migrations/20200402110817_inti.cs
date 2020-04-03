using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class inti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: false),
                    Prix = table.Column<double>(nullable: false),
                    DateExpiration = table.Column<DateTime>(nullable: false),
                    QteStock = table.Column<int>(nullable: false),
                    CategorieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitId);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDemande = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandeId);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandeDetail",
                columns: table => new
                {
                    CommandeId = table.Column<int>(nullable: false),
                    ProduitId = table.Column<int>(nullable: false),
                    Somme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeDetail", x => new { x.ProduitId, x.CommandeId });
                    table.ForeignKey(
                        name: "FK_CommandeDetail_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "CommandeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeDetail_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "Description", "ImageUrl", "NomCategorie" },
                values: new object[] { 1, "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "Fruit pies" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "Description", "ImageUrl", "NomCategorie" },
                values: new object[] { 2, "", null, "Cheese cakes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "Description", "ImageUrl", "NomCategorie" },
                values: new object[] { 3, "", null, "Seasonal pies" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "ProduitId", "CategorieId", "DateExpiration", "Designation", "Prix", "QteStock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Pie", 12.949999999999999, 100 },
                    { 4, 1, new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Happy holidays with this pie", 70.0, 300 },
                    { 2, 2, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blueberry Cheese Cake", 20.0, 50 },
                    { 5, 3, new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Happy holidays with this pie", 170.0, 200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandeDetail_CommandeId",
                table: "CommandeDetail",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieId",
                table: "Produits",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeDetail");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
