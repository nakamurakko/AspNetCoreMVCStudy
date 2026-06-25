using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMVCStudy.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCommentsAndColumnComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Books",
                comment: "書籍");

            migrationBuilder.AlterTable(
                name: "Authors",
                comment: "著者");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "書籍名",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Books",
                type: "bigint",
                nullable: true,
                comment: "著者 ID",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                table: "Books",
                type: "bigint",
                nullable: false,
                comment: "書籍 ID",
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "著者名",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Authors",
                type: "bigint",
                nullable: false,
                comment: "著者 ID",
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Books",
                oldComment: "書籍");

            migrationBuilder.AlterTable(
                name: "Authors",
                oldComment: "著者");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "書籍名");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Books",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "著者 ID");

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                table: "Books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "書籍 ID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "著者名");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Authors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "著者 ID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
