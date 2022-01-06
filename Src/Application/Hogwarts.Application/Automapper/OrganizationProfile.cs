namespace Hogwarts.Application.Automapper
{
    using AutoMapper;
    using Hogwarts.Application.DTOs;
    using Hogwarts.Domain.Entities;

    public class OrganizationProfile : Profile
	{
		public OrganizationProfile()
		{
			CreateMap<Student, StudentDTO>()
				.ForMember(x => x.HouseName, x => x.MapFrom(y => y.House.Name));

			CreateMap<House, HouseDTO>();


			CreateMap<StudentDTO, Student>();

			CreateMap<HouseDTO, House>();
		}
	}
}
