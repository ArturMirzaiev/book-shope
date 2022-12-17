using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Data.Migrations
{
    public partial class Some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName", "YearsOfLife" },
                values: new object[,]
                {
                    { new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"), "Charles", "Bukowski", "1920-1994" },
                    { new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"), "Jack", "Lodon", "1876-1916" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("5d841405-a9bb-4d33-8ec8-3823a991eb12"), "Edited by John Martin, the legendary publisher of Black Sparrow Press and a close friend of Bukowski's, The Pleasures of the Damned is a selection of the best works from Bukowski's long poetic career, including the last of his never-before-collected poems. Celebrating the full range of the poet's extra-ordinary and surprising sensibility, and his uncompromising linguistic brilliance, these poems cover a rich lifetime of experiences and speak to Bukowski's \"immense intelligence, the caring heart that saw through the sham of our pretenses and had pity on our human condition\" (The New York Quarterly). The Pleasures of the Damned is an astonishing poetic treasure trove, essential reading for both longtime fans and those just discovering this unique and legendary American voice.", 4m, 1, "The Pleasures of the Damned" },
                    { new Guid("9a561a1a-763b-431d-b8b1-8158c4c473c6"), "Ham on Rye is a 1982 semi-autobiographical novel by American author and poet Charles Bukowski. Written in the first person, the novel follows Henry Chinaski, Bukowski's thinly veiled alter ego, during his early years. Written in Bukowski's characteristically straightforward prose, the novel tells of his coming-of-age in Los Angeles during the Great Depression.", 10.99m, 1, "Ham on Rye" },
                    { new Guid("c073dcc4-2755-4a26-6449-08dad700b701"), "One of Bukowski's best, this beer-soaked, deliciously degenerate novel follows the wanderings of aspiring writer Henry Chinaski across World War II-era America. Deferred from military service, Chinaski travels from city to city, moving listlessly from one odd job to another, always needing money but never badly enough to keep a job. His day-to-day existence spirals into an endless litany of pathetic whores, sordid rooms, dreary embraces, and drunken brawls, as he makes his bitter, brilliant way from one drink to the next.", 12.49m, 2, "Factotum" },
                    { new Guid("f263bf34-92ff-4422-bfcd-08dad63ed3e4"), "Buck is a dog born to luxury, but he is betrayed and sold as a sled dog in the harsh and frozen Yukon. But Buck is stronger than any man knew, and he escapes captivity and rises above his enemies to become the leader of a wolf pack.", 6.85m, 3, "The Call of the Wild" },
                    { new Guid("f371dd81-e486-410c-9b66-b5a261c979bc"), "Martin Eden is an impoverished sailor who pursues, obsessively and aggressively, dreams of education and literary fame. He educates himself feverishly and becomes a writer, hoping to acquire the respectability sought by his society-girl sweetheart.", 4.99m, 1, "Martin Eden" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a41c1b1b-e67e-4d7b-a6d5-14e3eae1366d"), "Autobiography" },
                    { new Guid("b7fed066-9ded-4be5-9801-95eed87fc048"), "Adventure" },
                    { new Guid("defaf2ca-511a-4a23-8b01-480fbd8a68ee"), "Poetry" },
                    { new Guid("f7b4126d-9149-40cb-867f-f464163ffe26"), "Romance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d841405-a9bb-4d33-8ec8-3823a991eb12"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9a561a1a-763b-431d-b8b1-8158c4c473c6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c073dcc4-2755-4a26-6449-08dad700b701"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f263bf34-92ff-4422-bfcd-08dad63ed3e4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f371dd81-e486-410c-9b66-b5a261c979bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a41c1b1b-e67e-4d7b-a6d5-14e3eae1366d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b7fed066-9ded-4be5-9801-95eed87fc048"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("defaf2ca-511a-4a23-8b01-480fbd8a68ee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f7b4126d-9149-40cb-867f-f464163ffe26"));
        }
    }
}
