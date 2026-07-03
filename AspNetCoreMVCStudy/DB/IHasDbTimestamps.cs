namespace AspNetCoreMVCStudy.DB;

/// <summary>
/// DB 更新日時用インターフェイス。
/// </summary>
/// <remarks>
/// https://learn.microsoft.com/ja-jp/ef/core/logging-events-diagnostics/events
/// </remarks>
public interface IHasDbTimestamps
{

    /// <summary>作成日時</summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>更新日時</summary>
    public DateTime? UpdatedAt { get; set; }

}
