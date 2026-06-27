# AspNetCoreMVCStudy

ASP.NET Core MVC 勉強用プロジェクト。

## DB 定義更新

DB の新規作成、更新に Entity Framework Core を使用する。

* [ツールのインストール](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#installing-the-tools)
* [dotnet ef migrations add InitialCreate](https://learn.microsoft.com/ja-jp/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli#create-your-first-migration) --startup-project .\AspNetCoreMVCStudy (最初の移行を作成する)
* [dotnet ef migrations add AddTableNameColumnName](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#dotnet-ef-migrations-add) --startup-project .\AspNetCoreMVCStudy (新しい移行を追加する)
* [dotnet ef database update](https://learn.microsoft.com/ja-jp/ef/core/cli/dotnet#dotnet-ef-database-update) --startup-project .\AspNetCoreMVCStudy (データベースを最後の移行または指定された移行に更新)
