using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Autor_Books_Api.Books.Dtos;
using Autor_Books_Api.Books.Model;
using Autor_Books_Api.Data;
using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Exceptions;
using Autor_Books_Api.Autors.Model;


namespace Autor_Books_Api.Autors.Repository
{
    public interface IAutorRepo
    {

        Task<GetAllAutorDto> GetAllAsync();

        Task<AutorResponse> CreateAutorAsync(AutorRequest request);

        Task<AutorResponse> GetByIdAsyn(int id);

        Task<Autor?> GetEntityByIdAsync(int id);

        Task<AutorResponse> UpdateAsync(int id, AutorUpdateRequest update);


        Task<AutorResponse> FindByNameAutorAsync(string name);

        Task<AutorResponse> FindByIdAsync(int id);
        Task<AutorResponse> DeleteAutorAsync(int id);

        Task UpdateAsync(Autor autor);
         Task<BookResponse> DeleteBookAsync(int idautor, int idbook);






    }
}
