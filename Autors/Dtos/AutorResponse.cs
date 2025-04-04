using Autor_Books_Api.Books.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autor_Books_Api.Autors.Dtos
{
    public class AutorResponse
    {


        public int Id { get; set; }

        public string Name { get; set; }


       
        public string Email { get; set; }


        
        public int Age { get; set; }



        public virtual List<Book> Books { get; set; } = new();






















    }
}
