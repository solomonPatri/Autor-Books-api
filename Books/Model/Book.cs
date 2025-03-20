using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Autor_Books_Api;
using Autor_Books_Api.Autors.Model;

namespace Autor_Books_Api.Books.Model
{
    [Table("books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }


        public int AutorId { get; set; }

        [Required]
        [Column("created")]
        public DateTime Created { get; set; }


        public virtual Autor Autor { get; set; } = new();










    }
}
