using Autor_Books_Api.Autors.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autor_Books_Api.Books.Dtos
{
    public class BookRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AutorId { get; set; }

        [Required]
        
        public DateTime Created { get; set; }

        [Required]
        public virtual Autor Autor { get; set; } = new();










    }
}
