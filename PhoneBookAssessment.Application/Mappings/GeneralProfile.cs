using AutoMapper;
using PhoneBookAssessment.Application.Dtos;
using PhoneBookAssessment.Domain.Entities;

namespace PhoneBookAssessment.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<PhoneBook, PhoneBookViewModel>().ReverseMap();
        }
    }
}
