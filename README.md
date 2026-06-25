# AspNetCoreMVCStudy

ASP.NET Core MVC 勉強用プロジェクト。

## DB 定義更新

DB の新規作成、更新に Entity Framework Core を使用する。

* [ツールのインストール](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#installing-the-tools)
* [dotnet ef migrations add InitialCreate --startup-project .\AspNetCoreMVCStudy (最初の移行を作成する)](https://learn.microsoft.com/ja-jp/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli#create-your-first-migration)
* [dotnet ef migrations add AddTableNameColumnName --startup-project .\AspNetCoreMVCStudy (新しい移行を追加する)](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#dotnet-ef-migrations-add)
* [dotnet ef database update --startup-project .\AspNetCoreMVCStudy (データベースを最後の移行または指定された移行に更新)](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#dotnet-ef-database-update)
