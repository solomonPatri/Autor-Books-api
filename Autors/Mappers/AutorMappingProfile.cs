using AutoMapper;
using Autor_Books_Api.Autors.Repository;
using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Model;

namespace Autor_Books_Api.Autors.Mappers
{
    public class AutorMappingProfile:Profile
    {

        public AutorMappingProfile()
        {

            CreateMap<AutorRequest, Autor>();
            CreateMap<Autor, AutorResponse>();
            CreateMap<AutorUpdateRequest, Autor>();

            CreateMap<Autor, AutorResponse>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));




        }












    }
}
