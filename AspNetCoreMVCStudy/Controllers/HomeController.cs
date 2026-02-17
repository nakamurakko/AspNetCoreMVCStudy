using AspNetCoreMVCStudy.DB;
using AspNetCoreMVCStudy.DB.Entities;
using AspNetCoreMVCStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspNetCoreMVCStudy.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    private readonly IDbContextFactory<ApplicationDbContext> _applicationDbContextFactory;

    public HomeController(ILogger<HomeController> logger, IDbContextFactory<ApplicationDbContext> applicationDbContextFactory)
    {
        this._logger = logger;

        // https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#create-controller-and-views
        this._applicationDbContextFactory = applicationDbContextFactory;
    }

    public async Task<IActionResult> Index()
    {
        using ApplicationDbContext dbContext = await this._applicationDbContextFactory.CreateDbContextAsync();

        HomeModel model = new();

        //model.Books = await dbContext.Books
        //    .GroupJoin(
        //        dbContext.Authors,
        //        book => book.AuthorId,
        //        author => author.AuthorId,
        //        (book, author) => new { book, author }
        //    )
        //    .SelectMany(
        //        bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
        //        (bookAndAuthor, author) =>
        //        new Book()
        //        {
        //            BookId = bookAndAuthor.book.BookId,
        //            Title = bookAndAuthor.book.Title,
        //            AuthorId = bookAndAuthor.book.AuthorId,
        //            Author = author
        //        }
        //    )
        //    .ToListAsync();

        // .NET 10 以降では LeftJoin を使う。(LinqKit に LeftJoin が存在するため注意する。)
        model.Books = await dbContext.Books
            .LeftJoin(
                dbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) =>
                new Book()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Author = author
                }
            )
            .ToListAsync();

        return this.View(model);
    }

    public async Task<IActionResult> Search(HomeModel model)
    {
        using ApplicationDbContext dbContext = await this._applicationDbContextFactory.CreateDbContextAsync();

        // Where 以外は Index() メソッドと同じ。
        //model.Books = await dbContext.Books
        //    .GroupJoin(
        //        dbContext.Authors,
        //        book => book.AuthorId,
        //        author => author.AuthorId,
        //        (book, author) => new { book, author }
        //    )
        //    .SelectMany(
        //        bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
        //        (bookAndAuthor, author) =>
        //        new Book()
        //        {
        //            BookId = bookAndAuthor.book.BookId,
        //            Title = bookAndAuthor.book.Title,
        //            AuthorId = bookAndAuthor.book.AuthorId,
        //            Author = author
        //        }
        //    )
        //    .Where(book => book.Title.Contains(model.SearchTitle))
        //    .ToListAsync();

        LinqKit.ExpressionStarter<Book> predicateBuilder = LinqKit.PredicateBuilder.New<Book>(true);
        if (!string.IsNullOrWhiteSpace(model.SearchTitle))
        {
            predicateBuilder.Or(x => x.Title.Contains(model.SearchTitle));
        }

        model.Books = await dbContext.Books
            .LeftJoin(
                dbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) =>
                new Book
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Author = author
                }
            )
            .Where(predicateBuilder)
            .ToListAsync();

        return this.View(nameof(HomeController.Index), model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }

}