using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Repository;
using Autor_Books_Api.Autors.Exceptions;

namespace Autor_Books_Api.Autors.Service
{
    public class QueryService:IQueryService
    {

        private readonly IAutorRepo _repo;
        public QueryService(IAutorRepo repo)
        {
            _repo = repo;


        }



       public async  Task<GetAllAutorDto> GetAllAsync()
        {

            GetAllAutorDto response = await _repo.GetAllAsync();

            if(response != null)
            {
                return response;

            }
            throw new AutorNotFoundException();


        }







    }
}
