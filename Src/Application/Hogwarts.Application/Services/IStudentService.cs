namespace Hogwarts.Application.Services
{
    using Hogwarts.Application.DTOs;
    using System;
    using System.Collections.Generic;

    public interface IStudentService
    {
        /// <summary>
        /// Add new student to Hogwarts
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        StudentDTO Add(StudentDTO student);

        /// <summary>
        /// Update an existing student in Hogwarts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        StudentDTO Update(int id, StudentDTO student);

        /// <summary>
        /// Get all students of Hogwarts
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentDTO> Get();

        /// <summary>
        /// Get an student of Hogwarts by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StudentDTO Get(int id);

        /// <summary>
        /// Remove a student by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
