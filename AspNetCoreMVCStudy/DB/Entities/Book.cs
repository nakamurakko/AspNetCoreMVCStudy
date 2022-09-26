using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

[Table(nameof(Book))]
public class Book
{
    public long BookId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public long? AuthorId { get; set; }

    [NotMapped]
    public Author Author { get; set; }
}
