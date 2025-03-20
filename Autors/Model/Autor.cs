using Autor_Books_Api;
using Autor_Books_Api.Books.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Autor_Books_Api.Autors.Model
{
    [Table("autors")]
    
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set;}

        [Required]
        [Column("name")]
        public string Name { get; set; }


        [Required]
        [Column("email")]
        public string Email { get; set; }


        [Required]
        [Column("age")]
        public int Age { get; set; }



        public virtual List<Book> Books { get; set; } = new();





















    }
}
