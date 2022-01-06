namespace Hogwarts.Infrastructure.Repositories
{
    using Hogwarts.Core.EF;
    using Hogwarts.Domain.Entities;
    using Hogwarts.Domain.Repositories;
    using Hogwarts.Infrastructure.Data;
    using Microsoft.Extensions.Logging;
    using System.Linq;


    public class HouseRepository : EFRepository<House, int>, IHouseRepository
    {
        private readonly HogwartsContext _dbContext;

        public HouseRepository(HogwartsContext dbContext, ILogger<HouseRepository> logger)
            : base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public House Get(string name)
        {
            var result = from houses in _dbContext.Houses
                         where houses.Name.ToLower().Equals(name.ToLower()) select houses ;
            return result.ToList().FirstOrDefault();
        }
    }
}
