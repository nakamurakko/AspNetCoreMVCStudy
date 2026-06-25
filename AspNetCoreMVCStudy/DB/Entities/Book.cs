using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCStudy.DB.Entities;

/// <summary>
/// 書籍クラス。
/// </summary>
[Comment("書籍")]
public sealed class Book
{

    [Comment("書籍 ID")]
    public long BookId { get; set; }

    [Required]
    [MaxLength(100)]
    [Comment("書籍名")]
    public string Title { get; set; } = "";

    [Comment("著者 ID")]
    public long? AuthorId { get; set; }

    public Author? Author { get; set; }

}
