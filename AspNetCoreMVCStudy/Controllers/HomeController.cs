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

    private readonly ApplicationDbContext _applicationDbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
    {
        this._logger = logger;

        // https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#create-controller-and-views
        this._applicationDbContext = applicationDbContext;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeModel();

        model.Books = await this._applicationDbContext.Books
            .GroupJoin(
                this._applicationDbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) => new { book, author }
            )
            .SelectMany(
                bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
                (bookAndAuthor, author) =>
                new Book()
                {
                    BookId = bookAndAuthor.book.BookId,
                    Title = bookAndAuthor.book.Title,
                    AuthorId = bookAndAuthor.book.AuthorId,
                    Author = author
                }
            )
            .ToListAsync();

        return this.View(model);
    }

    public async Task<IActionResult> Search(HomeModel model)
    {
        // Where 以外は Index() メソッドと同じ。
        model.Books = await this._applicationDbContext.Books
            .GroupJoin(
                this._applicationDbContext.Authors,
                book => book.AuthorId,
                author => author.AuthorId,
                (book, author) => new { book, author }
            )
            .SelectMany(
                bookAndAuthor => bookAndAuthor.author.DefaultIfEmpty(),
                (bookAndAuthor, author) =>
                new Book()
                {
                    BookId = bookAndAuthor.book.BookId,
                    Title = bookAndAuthor.book.Title,
                    AuthorId = bookAndAuthor.book.AuthorId,
                    Author = author
                }
            )
            .Where(book => book.Title.Contains(model.SearchTitle))
            .ToListAsync();

        return this.View(nameof(HomeController.Index), model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}