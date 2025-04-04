using AutoMapper;
using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Exceptions;
using Autor_Books_Api.Autors.Repository;
using Autor_Books_Api.Books.Dtos;
using Autor_Books_Api.Books.Model;
using System.Data;
using Autor_Books_Api.Autors.Model;
using Autor_Books_Api.Books.Exceptions;

namespace Autor_Books_Api.Autors.Service
{
    public class CommandService:ICommandService
    {
        private readonly IAutorRepo _repo;
        private readonly IMapper _mapper;

        public CommandService(IAutorRepo repo,IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }


       public async  Task<AutorResponse> CreateAutorAsync(AutorRequest request)
        {
            AutorResponse verf = await this._repo.FindByNameAutorAsync(request.Name);

            if(verf == null)
            {
                AutorResponse response = await _repo.CreateAutorAsync(request);

                return response;



            }
            throw new AutorAlreadyException();



        }


       public async  Task<BookResponse> AddBookAsync(BookRequest bookrequest)
        {

            var autor = await _repo.GetEntityByIdAsync(bookrequest.AutorId);

            if (autor == null)
            {
                throw new AutorNotFoundException();
            }

            var book = _mapper.Map<Book>(bookrequest);
            book.Created = DateTime.UtcNow;

            autor.Books.Add(book);
            await _repo.UpdateAsync(autor);
            return _mapper.Map<BookResponse>(book);



        }


       public async  Task<AutorResponse> UpdateAutorAsync(int id, AutorUpdateRequest autor)
        {
            AutorResponse verf = await _repo.FindByIdAsync(id);

            if (verf != null)
            {
                if(verf is AutorRequest)
                {
                    verf.Name = autor.Name ?? verf.Name;
                    verf.Email = autor.Email ?? verf.Email;
                    verf.Age = autor.Age ?? verf.Age;

                    AutorResponse response = await _repo.UpdateAsync(id, autor);

                    return response;



                }
               


            }


            throw new AutorNotFoundException();





        }

       public async  Task<AutorResponse> DeleteAutorAsync(int id)
        {
            AutorResponse verf = await _repo.FindByIdAsync(id);

            if (verf != null)
            {

                AutorResponse response = await _repo.DeleteAutorAsync(id);

                return response;


            }
            throw new AutorNotFoundException();










        }

        public async Task<BookResponse> DeleteBookAsync(int autoid, int bookid)
        {
            Autor autor = await _repo.GetEntityByIdAsync(autoid);

            Book book = autor.Books.FirstOrDefault(s=>s.Id==bookid);

            if (autor != null)
            {
                if (book != null)
                {
                    BookResponse response = await _repo.DeleteBookAsync(autoid, bookid);

                    return response;




                }

                throw new BookNotFoundExceptions();

            }
            throw new AutorNotFoundException();






        }














    }
}
