namespace Hogwarts.Domain.Repositories
{

    using Hogwarts.Core.Repositories;
    using Hogwarts.Domain.Entities;


    public interface IHouseRepository : IRepository<House, int>
    {
        /// <summary>
        /// Get house by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        House Get(string name);
    }
}
