using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDelivery.Migrations
{
    public partial class contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ContactInfo_ContactInfoId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_ContactInfo_ContactInfoId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "ContactInfoId",
                table: "Stores",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_ContactInfoId",
                table: "Stores",
                newName: "IX_Stores_ContactId");

            migrationBuilder.RenameColumn(
                name: "ContactInfoId",
                table: "Customer",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContactInfoId",
                table: "Customer",
                newName: "IX_Customer_ContactId");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AddressId",
                table: "Contact",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Contact_ContactId",
                table: "Customer",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Contact_ContactId",
                table: "Stores",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Contact_ContactId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Contact_ContactId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Stores",
                newName: "ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_ContactId",
                table: "Stores",
                newName: "IX_Stores_ContactInfoId");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Customer",
                newName: "ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContactId",
                table: "Customer",
                newName: "IX_Customer_ContactInfoId");

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_AddressId",
                table: "ContactInfo",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ContactInfo_ContactInfoId",
                table: "Customer",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_ContactInfo_ContactInfoId",
                table: "Stores",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
