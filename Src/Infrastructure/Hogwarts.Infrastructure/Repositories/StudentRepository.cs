namespace Hogwarts.Infrastructure.Repositories
{
    using Hogwarts.Core.EF;
    using Hogwarts.Domain.Entities;
    using Hogwarts.Domain.Repositories;
    using Hogwarts.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentRepository : EFRepository<Student, int>, IStudentRepository
    {

        private readonly HogwartsContext _dbContext;

        public StudentRepository(HogwartsContext dbContext, ILogger<StudentRepository> logger)
            : base(dbContext, logger)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> GetWithForeignKey()
        {
            var result = _dbContext.Students.Include(c => c.House);
            return result.ToList();
        }

        public Student GetWithForeignKey(int id)
        {
            var result = _dbContext.Students.Where(x=>x.Id.Equals(id)).Include(c => c.House);
            return result.ToList().FirstOrDefault();
        }
    }
}
