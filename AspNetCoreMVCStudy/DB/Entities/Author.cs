using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

public sealed class Author
{

    public long AuthorId { get; set; }

    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; } = "";

    public ICollection<Book> Books { get; set; } = new List<Book>();

}
