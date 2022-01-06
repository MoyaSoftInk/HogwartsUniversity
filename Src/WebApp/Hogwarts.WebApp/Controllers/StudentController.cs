// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hogwarts.WebApp.Controllers
{
    using Hogwarts.Application.DTOs;
    using Hogwarts.Application.Services;
    using Hogwarts.Core.Model;
    using Hogwarts.Core.Validator;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(
            IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public ApiResponse<IEnumerable<StudentDTO>> Get()
        {
            try
            {
                var studentDTOs = _studentService.Get();

                return new ApiResponse<IEnumerable<StudentDTO>>()
                {
                    Code = studentDTOs.Any() ? HttpStatusCode.OK : HttpStatusCode.NoContent,
                    Description = string.Empty,
                    Structure = studentDTOs
                };
            }
            catch (ValidationException ex)
            {
                return new ApiResponse<IEnumerable<StudentDTO>>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Description = ex.Message,
                    Structure = null
                };
            }
        }

        [HttpGet("{id}")]
        public ApiResponse<StudentDTO> Get(int id)
        {
            try
            {
                var studentDTO = _studentService.Get(id);

                return new ApiResponse<StudentDTO>()
                {
                    Code = studentDTO is null ? HttpStatusCode.NoContent : HttpStatusCode.OK,
                    Description = string.Empty,
                    Structure = studentDTO
                };
            }
            catch (ValidationException ex)
            {
                return new ApiResponse<StudentDTO>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Description = ex.Message,
                    Structure = null
                };
            }
        }


        [HttpPost]
        public ApiResponse<StudentDTO> Post([FromBody] StudentDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentDTO = _studentService.Add(dto);

                    return new ApiResponse<StudentDTO>()
                    {
                        Code = HttpStatusCode.OK,
                        Description = string.Empty,
                        Structure = studentDTO
                    };
                }
                else
                {

                    List<string> errorMessages = ModelState.Values.SelectMany(c => c.Errors).Select(k => k.ErrorMessage).ToList();
                    string allErrors = errorMessages.Any() ? errorMessages.Aggregate((c, n) => c + "\n*" + n) : string.Empty;

                    return new ApiResponse<StudentDTO>()
                    {
                        Code = HttpStatusCode.NotAcceptable,
                        Description = allErrors,
                        Structure = null
                    };
                }                
            }
            catch (ValidationException ex)
            {
                return new ApiResponse<StudentDTO>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Description = ex.Message,
                    Structure = null
                };
            }
        }


        [HttpPut("{id}")]
        public ApiResponse<StudentDTO> Put(int id, [FromBody] StudentDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentDTO = _studentService.Update(id, dto);

                    return new ApiResponse<StudentDTO>()
                    {
                        Code = HttpStatusCode.OK,
                        Description = string.Empty,
                        Structure = studentDTO
                    };
                }
                else
                {

                    List<string> errorMessages = ModelState.Values.SelectMany(c => c.Errors).Select(k => k.ErrorMessage).ToList();
                    string allErrors = errorMessages.Any() ? errorMessages.Aggregate((c, n) => c + "\n*" + n) : string.Empty;

                    return new ApiResponse<StudentDTO>()
                    {
                        Code = HttpStatusCode.NotAcceptable,
                        Description = allErrors,
                        Structure = null
                    };
                }
            }
            catch (ValidationException ex)
            {
                return new ApiResponse<StudentDTO>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Description = ex.Message,
                    Structure = null
                };
            }
        }

        [HttpDelete]
        public ApiResponse<StudentDTO> Delete(int id)
        {
            try
            {
                _studentService.Delete(id);

                return new ApiResponse<StudentDTO>()
                {
                    Code = HttpStatusCode.OK,
                    Description = "Deleted",
                    Structure = null
                };
            }
            catch (ValidationException ex)
            {
                return new ApiResponse<StudentDTO>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Description = ex.Message,
                    Structure = null
                };
            }
        }

    }
}
