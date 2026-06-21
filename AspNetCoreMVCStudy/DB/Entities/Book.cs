using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

public sealed class Book
{

    public long BookId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    public long? AuthorId { get; set; }

    public Author? Author { get; set; }

}
