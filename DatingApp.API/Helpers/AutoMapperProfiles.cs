using System.Linq;
using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        // Helper class to Map the source and destination. 
        public AutoMapperProfiles()
        {
                        //source  .. destination
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoURL,
                     opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url))
                .ForMember(dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())); // Create a MAP for UserForListDTO
            CreateMap<User, UserForDetailDTO>()
                .ForMember(dest => dest.PhotoURL, 
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(predicate=> predicate.isMain).Url))
                .ForMember(dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));    // Create a MAp for UserForDetailDTO. 
            CreateMap<Photo, PhotosForDetailedDTO>();  //Create a MAP for PhotoFordetailedDTO
            CreateMap<UserForUpdateDTO, User>();
            


        }
    }
}