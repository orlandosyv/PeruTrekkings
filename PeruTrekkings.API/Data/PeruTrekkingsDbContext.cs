using Microsoft.EntityFrameworkCore;
using PeruTrekkings.API.Models.Domain;


namespace PeruTrekkings.API.Data
{
    public class PeruTrekkingsDbContext : DbContext
    {
        public PeruTrekkingsDbContext(DbContextOptions<PeruTrekkingsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Cuzco Sur",
                    Code = "CZS",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Cuzco Norte",
                    Code = "CZN",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Nazca",
                    Code = "NZC",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Arequipa",
                    Code = "AQP",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Trujillo",
                    Code = "TRU",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("853696d0-49c4-4479-91c3-19e1fcaebfcc"),
                    Name = "Lambayeque",
                    Code = "LBY",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Piura",
                    Code = "PIU",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("ec1b04a0-8785-4683-9a41-e700ed4c5fb6"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },

            };

            modelBuilder.Entity<Region>().HasData(regions);


            // Seed data for Walks
            var walks = new List<Walk>
            {
                new Walk
                {
                    Id = Guid.Parse("327aa9f7-26f7-4ddb-8047-97464374bb63"),
                    Name = "Mount Victoria Loop",
                    Description = "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.",
                    LengthInKm = 100,
                    WalkImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionId  = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE"),
                },
                
                new Walk
                {
                    Id = Guid.Parse("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"),
                    Name = "Makara Beach Walkway",
                    Description = "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.",
                    LengthInKm = 8.2,
                    WalkImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionId  = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE"),
                },                
                new Walk
                {
                    Id = Guid.Parse("09601132-f92d-457c-b47e-da90e117b33c"),
                    Name = "Botanic Garden Walk",
                    Description = "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.",
                    LengthInKm = 2,
                    WalkImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionId  = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE"),
                },                
                new Walk
                {
                    Id = Guid.Parse("30d654c7-89ac-4704-8333-5065b740150b"),
                    Name = "Mount Eden Summit Walk",
                    Description = "This walk takes you to the summit of Mount Eden, the highest natural point in Auckland, with panoramic views of the city.",
                    LengthInKm = 3,
                    WalkImageUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionId  = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6"),
                },
                new Walk                
                {
                    Id = Guid.Parse("f7578324-f025-4c86-83a9-37a7f3d8fe81"),
                    Name = "Cornwall Park Walk",
                    Description = "Explore the beautiful Cornwall Park on this leisurely walk, with a wide variety of trees, gardens, and animals to admire.",
                    LengthInKm = 4,
                    WalkImageUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionId  = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6"),
                },                
                new Walk
                {
                    Id = Guid.Parse("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"),
                    Name = "Takapuna to Milford Coastal Walk",
                    Description = "This coastal walk takes you along the beautiful beaches of Takapuna and Milford, with stunning views of Rangitoto Island.",
                    LengthInKm = 5,
                    WalkImageUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionId  = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6"),
                },                
                new Walk
                {
                    Id = Guid.Parse("43132402-3d5e-467a-8cde-351c5c7c5dde"),
                    Name = "Centre of New Zealand Walkway",
                    Description = "This walk takes you to the geographical centre of New Zealand, with stunning views of Nelson and its surroundings.",
                    LengthInKm = 7.2,
                    WalkImageUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionId  = Guid.Parse("906CB139-415A-4BBB-A174-1A1FAF9FB1F6"),
                },                
                new Walk
                {
                    Id = Guid.Parse("1ea0b064-2d44-4324-91ee-6dd86c91b713"),
                    Name = "Maitai Valley Walk",
                    Description = "Explore the picturesque Maitai Valley on this easy walk, with a tranquil river and native bush to enjoy.",
                    LengthInKm = 4.8,
                    WalkImageUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId= Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionId  = Guid.Parse("906CB139-415A-4BBB-A174-1A1FAF9FB1F6"),
                },
            };
            modelBuilder.Entity<Walk>().HasData(walks);

        }
    }
}
