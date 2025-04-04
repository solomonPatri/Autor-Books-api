using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Books.Dtos;

namespace Autor_Books_Api.Autors.Service
{
    public interface ICommandService
    {

      

        Task<AutorResponse> CreateAutorAsync(AutorRequest request);


        Task<BookResponse> AddBookAsync(BookRequest bookrequest);


        Task<AutorResponse> UpdateAutorAsync(int id, AutorUpdateRequest autor);

        Task<AutorResponse> DeleteAutorAsync(int id);

        Task<BookResponse> DeleteBookAsync(int autoid, int bookid);

















    }
}
