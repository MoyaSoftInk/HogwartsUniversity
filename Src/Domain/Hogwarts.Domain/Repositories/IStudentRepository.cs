namespace Hogwarts.Domain.Repositories
{
    using Hogwarts.Core.Repositories;
    using Hogwarts.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public interface IStudentRepository : IRepository<Student, int>
    {
        /// <summary>
        /// Get all students with references
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetWithForeignKey();

        /// <summary>
        /// Get an student with reference
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetWithForeignKey(int id);
    }
}
