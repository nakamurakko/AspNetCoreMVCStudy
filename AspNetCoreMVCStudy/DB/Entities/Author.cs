using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

/// <summary>
/// 著者クラス。
/// </summary>
[Comment("著者")]
public sealed class Author
{

    /// <summary>著者 ID</summary>
    [Comment("著者 ID")]
    public long AuthorId { get; set; }

    /// <summary>著者名</summary>
    [Required]
    [MaxLength(100)]
    [Comment("著者名")]
    public string AuthorName { get; set; } = "";

    public ICollection<Book> Books { get; set; } = new List<Book>();

}
