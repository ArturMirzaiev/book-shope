using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Data.Migrations
{
    public partial class addedimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageBookModel");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d841405-a9bb-4d33-8ec8-3823a991eb12"),
                column: "ImageUrl",
                value: "https://www.booktopia.com.au/covers/600/9781786895226/8489/the-pleasures-of-the-damned.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9a561a1a-763b-431d-b8b1-8158c4c473c6"),
                column: "ImageUrl",
                value: "https://pictures.abebooks.com/isbn/9781841951638-us-300.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c073dcc4-2755-4a26-6449-08dad700b701"),
                column: "ImageUrl",
                value: "http://www.impawards.com/2005/posters/factotum_ver3_xlg.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f263bf34-92ff-4422-bfcd-08dad63ed3e4"),
                column: "ImageUrl",
                value: "https://static.yakaboo.ua/media/catalog/product/9/7/9781509841769.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f371dd81-e486-410c-9b66-b5a261c979bc"),
                column: "ImageUrl",
                value: "https://assets1.bmstatic.com/assets/books-covers/20/ac/Rjh6zuzI-ipad.jpeg?image_hash=f5e5a384f549c9d17707c91d8153e68e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ImageBookModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBookModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageBookModel_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageBookModel_BookId",
                table: "ImageBookModel",
                column: "BookId",
                unique: true);
        }
    }
}
