using Autor_Books_Api.Autors.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autor_Books_Api.Books.Dtos
{
    public class BookResponse
    {
        public int Id { get; set; }

        
        public string Name { get; set; }


        public int AutorId { get; set; }

        public DateTime Created { get; set; }


        public virtual Autor Autor { get; set; } = new();










    }
}
