using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Exceptions;
using Autor_Books_Api.Autors.Model;

namespace Autor_Books_Api.Autors.Service
{
    public interface IQueryService
    {
        Task<GetAllAutorDto> GetAllAsync();









    }
}
