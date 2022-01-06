namespace Hogwarts.Application.Services.Implementations
{
    using AutoMapper;
    using Hogwarts.Application.DTOs;
    using Hogwarts.Core.Validator;
    using Hogwarts.Domain.Entities;
    using Hogwarts.Domain.Repositories;
    using System;
    using System.Collections.Generic;

    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IStudentRepository studentRepository,
            IHouseRepository houseRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public StudentDTO Add(StudentDTO student)
        {
            var entity = _mapper.Map<Student>(student);

            entity.House = _houseRepository.Get(student.HouseName);

            if (entity.House == null)
                throw new ValidationException(typeof(Student), "Casa no existe.");
            _studentRepository.Add(entity);

            return student;
        }

        public IEnumerable<StudentDTO> Get()
        {
            var entities = _studentRepository.GetWithForeignKey();
            
            return _mapper.Map<IEnumerable<StudentDTO>>(entities);
        }

        public StudentDTO Get(int id)
        {
            var entity = _studentRepository.GetWithForeignKey(id);

            if (entity == null)
                throw new ValidationException(typeof(Student), "Estudiante no existe.");

            return _mapper.Map<StudentDTO>(entity);
        }

        public StudentDTO Update(int id, StudentDTO studentDTO)
        {
            var entity = _studentRepository.GetWithForeignKey(id);

            if (entity == null)
                throw new ValidationException(typeof(Student), "Estudiante no existe.");

            entity.Name = studentDTO.Name;
            entity.LastName = studentDTO.LastName;
            entity.Age = studentDTO.Age;
            entity.Identification  = studentDTO.Identification;

            if (entity.House.Name.ToLower().Equals(studentDTO.HouseName.ToLower()))
            {
                entity.House = _houseRepository.Get(studentDTO.HouseName);
                if (entity.House == null)
                    throw new ValidationException(typeof(Student), "Casa no existe.");
            }

            _studentRepository.Modify(entity);

            return _mapper.Map<StudentDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _studentRepository.GetWithForeignKey(id);
            if (entity == null)
                throw new ValidationException(typeof(Student), "Estudiante no existe.");

            _studentRepository.Remove(entity);
        }
    }
}
