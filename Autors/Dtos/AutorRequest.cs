using Autor_Books_Api.Books.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autor_Books_Api.Autors.Dtos
{
    public class AutorRequest
    {
      

        [Required]
       
        public string Name { get; set; }


        [Required]
      
        public string Email { get; set; }


        [Required]
        
        public int Age { get; set; }
























    }
}
