using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreMVCStudy.DB.Entities;

[Table(nameof(Author))]
public class Author
{

    public long AuthorId { get; set; }

    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; } = "";

    [NotMapped]
    public ICollection<Book> Books { get; set; } = new List<Book>();

}
