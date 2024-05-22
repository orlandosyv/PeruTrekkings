using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeruTrekkings.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedsofWalks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("09601132-f92d-457c-b47e-da90e117b33c"), "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.0, "Botanic Garden Walk", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"), "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 8.1999999999999993, "Makara Beach Walkway", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("1ea0b064-2d44-4324-91ee-6dd86c91b713"), "Explore the picturesque Maitai Valley on this easy walk, with a tranquil river and native bush to enjoy.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 4.7999999999999998, "Maitai Valley Walk", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("30d654c7-89ac-4704-8333-5065b740150b"), "This walk takes you to the summit of Mount Eden, the highest natural point in Auckland, with panoramic views of the city.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.0, "Mount Eden Summit Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("327aa9f7-26f7-4ddb-8047-97464374bb63"), "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 100.0, "Mount Victoria Loop", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("43132402-3d5e-467a-8cde-351c5c7c5dde"), "This walk takes you to the geographical centre of New Zealand, with stunning views of Nelson and its surroundings.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 7.2000000000000002, "Centre of New Zealand Walkway", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"), "This coastal walk takes you along the beautiful beaches of Takapuna and Milford, with stunning views of Rangitoto Island.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "Takapuna to Milford Coastal Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f7578324-f025-4c86-83a9-37a7f3d8fe81"), "Explore the beautiful Cornwall Park on this leisurely walk, with a wide variety of trees, gardens, and animals to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 4.0, "Cornwall Park Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("09601132-f92d-457c-b47e-da90e117b33c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1ea0b064-2d44-4324-91ee-6dd86c91b713"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("30d654c7-89ac-4704-8333-5065b740150b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("327aa9f7-26f7-4ddb-8047-97464374bb63"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("43132402-3d5e-467a-8cde-351c5c7c5dde"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f7578324-f025-4c86-83a9-37a7f3d8fe81"));
        }
    }
}
