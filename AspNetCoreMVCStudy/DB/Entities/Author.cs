using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

[Table(nameof(Author))]
public class Author
{
    public long AuthorId { get; set; }

    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; }
}
