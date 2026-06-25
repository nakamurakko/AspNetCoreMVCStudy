using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

/// <summary>
/// 著者クラス。
/// </summary>
[Comment("著者")]
public sealed class Author
{

    [Comment("著者 ID")]
    public long AuthorId { get; set; }

    [Required]
    [MaxLength(100)]
    [Comment("著者名")]
    public string AuthorName { get; set; } = "";

    public ICollection<Book> Books { get; set; } = new List<Book>();

}
