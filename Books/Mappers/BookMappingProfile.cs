using AutoMapper;
using Autor_Books_Api.Books.Dtos;
using Autor_Books_Api.Books.Model;

namespace Autor_Books_Api.Books.Mappers
{
    public class BookMappingProfile:Profile
    {
        public BookMappingProfile()
        {

            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();
            CreateMap<Book, BookResponse>();



        }







    }
}
