namespace Hogwarts.Infrastructure.Data
{
    using Hogwarts.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public static class DatabaseInitializer
    {
        public static void Initialize(HogwartsContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Houses.Any())
            {

                dbContext.Houses.AddRange( new List<House>()
                {
                    new House
                    {
                        Name = "Gryffindor"
                    },
                    new House
                    {
                        Name = "Hufflepuff"
                    },
                    new House
                    {
                        Name = "Ravenclaw"
                    },
                    new House
                    {
                        Name = "Slytherin"
                    }
                });

                dbContext.SaveChanges();
                
            }

        }
    }
}
